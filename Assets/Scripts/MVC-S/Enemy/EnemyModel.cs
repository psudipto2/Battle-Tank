using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyModel
{
    public float movementSpeed { get; private set; }
    public float rotationSpeed { get; private set; }
    private EnemyController enemyController;
    public float health { get;  set; }
    public float PatrolRaius { get; private set; }
    public float chaseRadius { get; private set; }
    public float attackRaius { get; private set; }
    public BulletScriptableObject bullet { get; private set; }
    public float fireRate { get;  set; }
    public EnemyModel(EnemyScriptableObject enemyScriptable, EnemyScriptableObjectList enemyList)
    {
        movementSpeed = enemyScriptable.movementSpeed;
        rotationSpeed = enemyScriptable.rotationSpeed;
        health = enemyScriptable.health;
        PatrolRaius = enemyScriptable.patrolingRadius;
        chaseRadius = enemyScriptable.ChaseRadius;
        attackRaius = enemyScriptable.AttackRadius;
        bullet = enemyScriptable.bulletType;
        fireRate = 1 / enemyScriptable.fireRate;
    }


    public void SetEnemyController(EnemyController _enemyController)
    {
        enemyController = _enemyController;
    }

    public void DestroyModel()
    {
        
    }
}
