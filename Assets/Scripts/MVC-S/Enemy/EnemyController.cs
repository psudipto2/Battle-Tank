using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class EnemyController 
{
    public EnemyModel EnemyModel { get; set; }
    private EnemyView enemyView { get; set; }
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
        EnemyModel.SetEnemyController(this);
        Debug.Log("EnemyView Created");
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
    public void EnemyStateController()
    {
        float distance = Vector3.Distance(enemyView.target.position, enemyView.transform.position);
        if (distance <= EnemyModel.chaseRadius)
        {
            faceTarget();
            navMeshAgent.SetDestination(enemyView.target.position);
            if (distance <= navMeshAgent.stoppingDistance)
            {
                AttackPlayer();
            }
        }
        else
        {
            Patroling();
        }
    }
    private void faceTarget()
    {
        Vector3 direction = (enemyView.target.position - enemyView.transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        enemyView.transform.rotation = Quaternion.Slerp(enemyView.transform.rotation, lookRotation, Time.deltaTime * EnemyModel.rotationSpeed);
    }
    private void AttackPlayer()
    {
        //Make sure enemy doesn't move
        navMeshAgent.SetDestination(enemyView.transform.position);

        enemyView.transform.LookAt(enemyView.target);

        if (canfire<Time.time)
        {
            ///Attack code here
            BulletService.Instance.CreateNewBullet(enemyView.BulletShootPoint.position, enemyView.transform.rotation, EnemyModel.bullet);
            ///End of attack code

            canfire = EnemyModel.fireRate+Time.time;
        }
    }

    private void Patroling()
    {
        timer += Time.deltaTime;
        if (timer > 2f)
        {
            SetPatrolingDestination();
            timer = 0;
        }
    }
    private void SetPatrolingDestination()
    {
        Vector3 newDestination = GetRandomPosition();
        enemyView.transform.LookAt(newDestination);
        navMeshAgent.SetDestination(newDestination);
    }
    public Vector3 GetRandomPosition()
    {
        Vector3 randDir = UnityEngine.Random.insideUnitSphere * EnemyModel.PatrolRaius;
        randDir += EnemyService.Instance.enemyScriptable.enemyView.transform.position;
        NavMeshHit navHit;
        NavMesh.SamplePosition(randDir, out navHit, EnemyModel.PatrolRaius, NavMesh.AllAreas);
        return navHit.position;
    }
}
