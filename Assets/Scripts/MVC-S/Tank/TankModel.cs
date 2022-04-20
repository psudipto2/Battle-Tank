using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using tankView;

public class TankModel 
{
    public float movementSpeed { get; private set; }
    public float rotationSpeed { get; private set; }
    public float fireRate { get; private set; }
    public int bulletsFired { get; set; }
    public BulletScriptableObject bullet { get; private set; }
    private TankController tankController;

    public TankModel(TankScriptableObject tankScriptable, TankScriptableObjectList tankList)
    {
        movementSpeed = tankScriptable.movementSpeed;
        rotationSpeed = tankScriptable.rotationSpeed;
        bullet = tankScriptable.bulletType;
        fireRate = 1/tankScriptable.fireRate;
    }
    public void SetTankController(TankController _tankController)
    {
        tankController = _tankController;
    }
}
