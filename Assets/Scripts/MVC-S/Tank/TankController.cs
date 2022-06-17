using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankController 
{
    public TankModel TankModel { get; }
    public TankView tankView { get; }
    public TankService TankService { get; }
    private Rigidbody rigidbody;
    public float InputX;
    public float InputZ;
    private CharacterController characterController;
    public FixedJoystick joystick;
    private Vector3 movement;
    private float canfire;
    public TankController(TankModel tankModel, TankView tankPrefab)
    {
        TankModel = tankModel;
        tankView = GameObject.Instantiate<TankView>(tankPrefab);
        rigidbody = tankView.GetComponent<Rigidbody>();
        characterController = tankView.GetComponent<CharacterController>();
        tankView.SetTankController(this);
        tankView.ChangeColor(TankModel.material);
        TankModel.SetTankController(this);
        SubscribeEvent();
    }


    private BulletScriptableObject GetBullet()
    {
        return TankModel.bullet;
    }

    public void ShootBullet()
    {
        Debug.Log("Shoot");
        if (canfire < Time.time)
        {
            BulletService.Instance.CreateNewBullet(GetFiringPosition(), GetFiringAngle(), GetBullet());
            canfire = TankModel.fireRate + Time.time;
            EventServices.Instance.InvokeOnPlayerFiredBulletEvent();
        }
        
        
    }

    private Quaternion GetFiringAngle()
    {
        return tankView.transform.rotation;
    }

    private Vector3 GetFiringPosition()
    {
        return tankView.BulletShootPoint.position;
    }

    public Vector3 GetCurrentTankPosition()
    {
        return tankView.transform.position;
    }

    public void setJoysticks(FixedJoystick movemenetJoystick)
    {
        joystick = movemenetJoystick;
    }

    public void MoveTurn()
    {
        movement = new Vector3(InputX * TankModel.movementSpeed, 0, InputZ * TankModel.rotationSpeed);
        characterController.Move(movement);
        if (InputX != 0f || InputZ != 0f)
        {
            if (tankView.rigidbody.isKinematic == false)
            {
                tankView.OnDisable();
            }
            Vector3 changeDirection = new Vector3(movement.x, 0, movement.z);
            tankView.transform.rotation = Quaternion.LookRotation(changeDirection);
        }
        else
        {
            if (tankView.rigidbody.isKinematic == true)
            {
                tankView.OnEnable();
            }
        }
    }
    public void UpdateTank()
    {
        InputX = joystick.Horizontal;
        InputZ = joystick.Vertical;
    }
    private void UpdateBulletsFiredCount()
    {
        TankModel.bulletsFired += 1;
        PlayerPrefs.SetInt("BulletsFired", TankModel.bulletsFired);
        AcivementService.Instance.GetAchievementController().CheckForBulletFiredAchievement();
    }
    private void SubscribeEvent()
    {
        EventServices.Instance.PlayerFiredBullet += UpdateBulletsFiredCount;
    }

    private void UnsubscribeEvents()
    {
        EventServices.Instance.PlayerFiredBullet -= UpdateBulletsFiredCount;
    }

}
