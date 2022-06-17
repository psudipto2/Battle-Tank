using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class EnemyController 
{
    public EnemyModel EnemyModel { get; set; }
    public EnemyView enemyView { get; set; }
    private Rigidbody rigidbody;
    bool alreadyAttacked;
    private float timer;
    private float canfire;
    private MonoBehaviour _mb;
    public NavMeshAgent navMeshAgent { get; set; }

    public EnemyService EnemyService { get; }

    public EnemyController(EnemyModel enemyModel, EnemyView enemyPrefab)
    {
        EnemyModel = enemyModel;
        enemyView = GameObject.Instantiate<EnemyView>(enemyPrefab);
        rigidbody = enemyView.GetComponent<Rigidbody>();
        enemyView.SetEnemyController(this);
        enemyView.ChangeColor(enemyModel.material);
        navMeshAgent = enemyView.GetComponent<NavMeshAgent>();
        navMeshAgent.angularSpeed = EnemyModel.rotationSpeed;
        navMeshAgent.speed = EnemyModel.movementSpeed;
        navMeshAgent.stoppingDistance = EnemyModel.attackRaius;
    }

    private void Dead()
    {
        VFXController.Instance.InstantiateEffects(enemyView.TankDestroyVFX, enemyView.transform.position);
        EnemyService.Instance.DestroyEnemy(this);
    }
    public void ApplyDamage(float damage)
    {
        if (EnemyModel.health <= 0) return;

        if (EnemyModel.health - damage <= 0)
        {
            Dead();
        }
        else
        {
            EnemyModel.health -= damage;
        }
            
    }

    public Vector3 GetCurrentTankPosition()
    {
        return enemyView.transform.position;
    }

    public void DestoryController()
    {
        EnemyModel.DestroyModel();
        enemyView.DestroyView();
        EnemyModel = null;
        enemyView = null;

    }
    public void InitialEnemyState()
    {
        float distance = Vector3.Distance(enemyView.target, enemyView.transform.position);
        if (distance <= EnemyModel.chaseRadius)
        {
            enemyView.initialState = EnemyStates.Chasing;
            if (distance <= navMeshAgent.stoppingDistance)
            {
                enemyView.initialState = EnemyStates.Attacking;
            }
        }
        else
        {
            enemyView.initialState = EnemyStates.Patroling;
        }
    }
}
