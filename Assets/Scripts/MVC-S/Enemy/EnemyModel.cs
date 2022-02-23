using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyModel
{
    public float movementSpeed { get; private set; }
    public float rotationSpeed { get; private set; }
    private EnemyController enemyController;

    public EnemyModel(EnemyScriptableObject enemyScriptable, EnemyScriptableObjectList enemyList)
    {
        movementSpeed = enemyScriptable.movementSpeed;
        rotationSpeed = enemyScriptable.rotationSpeed;
    }


    public void SetEnemyController(EnemyController _enemyController)
    {
        enemyController = _enemyController;
    }

}
