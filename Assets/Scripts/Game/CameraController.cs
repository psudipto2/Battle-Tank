using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float damp_time = 0.2f;
    private Camera game_camera;
    private Vector3 move_velocity;
    private Vector3 desiredPosition;
    private TankView tankView;
    private GameObject Tank;

    private void Awake()
    {
        game_camera = GetComponentInChildren<Camera>();
    }
    private void FixedUpdate()
    {
        Move();
    }
    private void Move()
    {
        SetPosition();
        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref move_velocity, damp_time);
    }
    private void SetPosition()
    {
        Tank = GameObject.Find("Tank(Clone)");
        tankView = Tank.GetComponent<TankView>();
        Vector3 new_Position = new Vector3();
        new_Position = tankView.GetCurrentTankPosition();
        new_Position.y = transform.position.y;
        desiredPosition = new_Position;
    }
}