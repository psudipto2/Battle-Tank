using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController 
{
    public TankModel TankModel { get; }
    public TankView TankView { get; }
    public TankController(TankModel tankModel, TankView tankPrefab)
    {
        TankModel = tankModel;
        //GameObject go = GameObject.Instantiate(tankPrefab);
        TankView = GameObject.Instantiate<TankView>(tankPrefab);
        Debug.Log("TankView Created");
    }
}
