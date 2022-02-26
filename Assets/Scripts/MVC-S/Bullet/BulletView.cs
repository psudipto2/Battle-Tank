using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletView : MonoBehaviour
{
    private BulletController bulletController;
    public Rigidbody rigidbody;
    public void SetBulletController(BulletController _bulletController)
    {
        bulletController = _bulletController;
    }
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        //Debug.Log("BulletView");
        bulletController.Movement();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (bulletController != null)
        {
            IDamagable iDamagable = other.gameObject.GetComponent<IDamagable>();
            if (iDamagable != null)
            {
                iDamagable.TakeDamage(bulletController.BulletModel.damage);
            }
            BulletService.Instance.DestroyBullet(bulletController);
        }

    }
    public void DestroyView()
    {
        if (this != null)
        {
            bulletController = null;
            Destroy(this.gameObject);
        }
        
    }
}
