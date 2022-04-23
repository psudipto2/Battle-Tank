using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoSingletonGeneric<CameraController>
{
    public float damp_time = 0.2f;
    private Camera game_camera;
    private Vector3 move_velocity;
    private Vector3 desiredPosition;

    private void Awake()
    {
        base.Awake();
        game_camera = GetComponentInChildren<Camera>();
    }
    private void FixedUpdate()
    {
        Move();
    }
    private void Move()
    {
        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref move_velocity, damp_time);
    }
    public void SetPosition(Vector3 tankPosition)
    {
        
        Vector3 new_Position = new Vector3();
        new_Position = tankPosition;
        new_Position.y = transform.position.y;
        desiredPosition = new_Position;
    }
}