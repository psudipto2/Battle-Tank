using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController
{
    private Rigidbody rigidbody;

    public BulletView BulletView { get; set; }
    public BulletModel BulletModel { get; set; }

    public BulletController(BulletView bulletView, BulletModel bulletModel, Vector3 position, Quaternion rotation)
    {
        BulletView = GameObject.Instantiate<BulletView>(bulletView, position, rotation); ;
        BulletModel = bulletModel;
        BulletView.SetBulletController(this);
        BulletModel.SetBulletController(this);
        rigidbody = bulletView.GetComponent<Rigidbody>();
    }

    public void Movement()
    {
        Vector3 move = BulletView.transform.transform.position += BulletView.transform.forward * BulletModel.speed * Time.fixedDeltaTime;

        rigidbody.MovePosition(move);
    }
    public void DestroyController()
    {
        BulletView.DestroyView();
        BulletModel.DestroyModel();
        BulletView = null;
        BulletModel = null;
        rigidbody = null;
    }
}
