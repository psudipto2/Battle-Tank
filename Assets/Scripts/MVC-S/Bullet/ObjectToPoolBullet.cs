using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class ObjectToPoolBullet : ObjectPooler<BulletController>
{
    private BulletView bulletView;
    private BulletModel bulletModel;
    private Vector3 firePosition;
    private Quaternion rotation;
    public BulletController GetBullet(BulletView bulletView,BulletModel bulletModel,Vector3 firePosition,Quaternion rotation)
    {
        this.bulletView = bulletView;
        this.bulletModel = bulletModel;
        this.firePosition = firePosition;
        this.rotation = rotation;
        return CreateItem();
    }
    protected override BulletController CreateItem()
    {
        BulletController bulletController = new BulletController(bulletView, bulletModel, firePosition, rotation);
        return bulletController;
    }
}
