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
    public MeshRenderer[] childs;
    [SerializeField] private CameraController camera;


    private void FixedUpdate()
    {
        tankController.MoveTurn();
        SetCamera();
    }
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        characterController = GetComponent<CharacterController>();
    }
    private void SetCamera()
    {
        CameraController.Instance.SetPosition(transform.position);
    }
    public void ChangeColor(Material material)
    {
        for (int i = 0; i < childs.Length; i++)
        {
            childs[i].material = material;
        }
    }
    public void ShootBullet()
    {
        tankController.ShootBullet();
    }

    private void Update()
    {
        tankController.UpdateTank();
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
