using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankView : MonoBehaviour, IDamagable
{
    private TankController tankController;
 
    private FixedJoystick joystick;
    public Transform BulletShootPoint;
    private CharacterController characterController;
    public Rigidbody rigidbody;
    private GameObject FireButton;
    private Button Fire;

   
    private void FixedUpdate()
    {
        tankController.MoveTurn();
    }
    private void Awake()
    {
        FireButton = GameObject.FindGameObjectWithTag("Fire");
        Fire = FireButton.GetComponent<Button>();
        Fire.onClick.AddListener(ShootBullet);
        rigidbody = GetComponent<Rigidbody>();
        characterController = GetComponent<CharacterController>();
    }

    public void ShootBullet()
    {
        tankController.ShootBullet();
    }

    private void Update()
    {
        tankController.UpdateTank();
        //ShootBullet();
    }


    public void OnEnable()
    {
        rigidbody.isKinematic = false;    
    }
    public void OnDisable()
    {
        rigidbody.isKinematic = true;
    }
    public void setJoysticks()
    {
        tankController.joystick = joystick;
    }
    public Vector3 GetCurrentTankPosition()
    {
        return transform.position;
    }
    public void SetTankController(TankController _tankController)
    {
        tankController = _tankController;
    }
    public void TakeDamage(float damage)
    {
        //tankController.ApplyDamage(damage);
    }

}
