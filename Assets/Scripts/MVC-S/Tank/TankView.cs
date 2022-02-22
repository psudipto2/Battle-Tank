using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankView : MonoBehaviour
{
    private TankController tankController;
 
    private FixedJoystick joystick;
    private float movement;
    private float rotation;
    private CharacterController characterController;
    public Rigidbody rigidbody;

   
    private void FixedUpdate()
    {
        /*tankController.Move();  
        tankController.Turn();*/
        tankController.MoveTurn();
    }
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        characterController = GetComponent<CharacterController>();
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
    public void setJoysticks(FixedJoystick movementJoystick)
    {
        tankController.joystick = joystick;
    }

    public void SetTankController(TankController _tankController)
    {
        tankController = _tankController;
    }
    
}
