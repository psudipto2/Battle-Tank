using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletModel
{
    public BulletScriptableObject bullet;
    private BulletController bulletController;
    public float speed;
    public float damage;

    public BulletModel(BulletScriptableObject bullet)
    {
        speed = bullet.speed;
        damage = bullet.damage;
    }

    public void SetBulletController(BulletController _bulletController)
    {
        bulletController = _bulletController;
    }
    public void DestroyModel()
    {
        bulletController = null;
    }
}
