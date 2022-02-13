using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankService :MonoBehaviour
{
    public TankView tankView;
    private void Start()
    {
        StartGame();
    }
    public void StartGame()
    {
        for(int i = 0; i < 3; i++)
        {
            CreateNewTank();
        }
    }

    private TankController CreateNewTank()
    {
        TankModel tankModel = new TankModel(5, 1000);
        TankController tankController = new TankController(tankModel, tankView);
        return tankController;
    }
}
