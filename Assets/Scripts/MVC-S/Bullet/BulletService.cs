using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletService : MonoSingletonGeneric<BulletService>
{
    private List<BulletController> bullets = new List<BulletController>();
    private BulletController bulletController;
    private ObjectToPoolBullet poolBullet;
    private void Start()
    {
        poolBullet = GetComponent<ObjectToPoolBullet>();
    }
    public void CreateNewBullet(Vector3 position, Quaternion rotation, BulletScriptableObject type)
    {
        BulletScriptableObject bullet = type;
        BulletModel bulletModel = new BulletModel(bullet);
        //BulletController bulletController = new BulletController(bullet.bulletView, bulletModel, position, rotation);
        bulletController = poolBullet.GetBullet(bullet.bulletView, bulletModel, position, rotation);
        bullets.Add(bulletController);
        //Debug.Log("Bullet");
        
    }

     public void ReturnBullet(BulletController _bulletController)
    {
        poolBullet.ReturnItem(_bulletController);
    }
    public void DestroyBullet(BulletController bulletController)
    {
        if (bulletController != null)
        {
            bulletController.DestroyController();
        }
            

        for (int i = 0; i < bullets.Count; i++)
        {
            if (bullets[i] == bulletController)
            {
                bullets[i] = null;
                bullets.Remove(bullets[i]);
            }
        }
    }
}
