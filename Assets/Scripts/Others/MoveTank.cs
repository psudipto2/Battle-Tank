using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTank : MonoBehaviour
{
    private CharacterController characterController;
    private ManageJoystick manageJoystick;
    private Transform Tank;
    private float InputX;
    private float InputZ;
    private float moveSpeed;
    private float gravity;
    private Vector3 movement;
    private void Start()
    {
        moveSpeed = 0.1f;
        gravity = 0.5f;
        GameObject playerTank = GameObject.FindGameObjectWithTag("Tank");
        Tank = playerTank.transform.GetChild(0);
        characterController = playerTank.GetComponent<CharacterController>();
        manageJoystick = GameObject.Find("Joystick Out").GetComponent<ManageJoystick>();
    }
    private void Update()
    {
        InputX = manageJoystick.InputHorizontal();
        InputZ = manageJoystick.InputVertical();
    }
    private void FixedUpdate()
    {
        if (characterController.isGrounded)
        {
            movement.y = 0f;
        }
        else
        {
            movement.y = gravity * Time.deltaTime;
        }
        movement = new Vector3(InputX*moveSpeed, 0, InputZ*moveSpeed);
        characterController.Move(movement);
        if (InputX != 0 || InputZ != 0)
        {
            Vector3 changeDirection = new Vector3(movement.x, 0, movement.z);
            Tank.rotation = Quaternion.LookRotation(changeDirection);
        }
        
    }
}
