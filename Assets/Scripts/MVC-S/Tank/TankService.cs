using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using tankView;
using Random = UnityEngine.Random;

public class TankService : MonoSingletonGeneric<TankService>
{
    public TankView tankView;
    public TankScriptableObjectList tankList;
    private TankModel currentTankModel;
    private TankController tankController;
    public FixedJoystick joystick;

    public TankScriptableObject tankScriptable { get; private set; }
    private List<TankController> tanks = new List<TankController>();
    private void Start()
    {
        CreateNewTank();
        setTankJoyStick();
    }


    public void CreateNewTank()
    {
        int rand = Random.Range(0, tankList.tanks.Length);
        tankScriptable = tankList.tanks[rand];

        TankModel tankModel = new TankModel(tankScriptable, tankList);
        currentTankModel = tankModel;
        tankController = new TankController(tankModel, tankScriptable.tankView);
        tanks.Add(tankController);
    }
    public void setTankJoyStick()
    {
        if (tankController != null)
        {
            tankController.setJoysticks(joystick);
        }
    }
    public void SetTankController(TankController _tankController)
    {
        tankController = _tankController;
    }
    public TankModel GetCurrentTankModel()
    {
        return currentTankModel;
    }
    public TankController GetTankController(int index = 0) 
    {
        return tanks[index];
    }
    
}
