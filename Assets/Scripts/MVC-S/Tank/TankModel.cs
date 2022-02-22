using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using tankView;

public class TankModel 
{
    public float movementSpeed { get; private set; }
    public float rotationSpeed { get; private set; }
    private TankController tankController;

    public TankModel(TankScriptableObject tankScriptable, TankScriptableObjectList tankList)
    {
        movementSpeed = tankScriptable.movementSpeed;
        rotationSpeed = tankScriptable.rotationSpeed;
    }
    public void SetTankController(TankController _tankController)
    {
        tankController = _tankController;
    }
}
