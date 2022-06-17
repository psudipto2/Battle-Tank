using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackingState : State
{
    private float canfire;
    public override void OnStateEnter()
    {
        base.OnStateEnter();
        enemyView.activeState = EnemyStates.Attacking;
        Debug.Log("Shooting");
        //AttackPlayer();
    }
    public override void OnStateExit()
    {
        base.OnStateExit();
    }
    private void FixedUpdate()
    {
        AttackPlayer();
    }
    private void Attack()
    {
        navMeshAgent.SetDestination(enemyView.transform.position);

        enemyView.transform.LookAt(enemyView.target);

        if (canfire < Time.time)
        {

            BulletService.Instance.CreateNewBullet(enemyView.BulletShootPoint.position, enemyView.transform.rotation, enemyModel.bullet);
            Debug.Log("Shoot");

            canfire = enemyModel.fireRate + Time.time;
        }
    }
    private void AttackPlayer()
    {
        
        if (GetDistance() >= enemyModel.attackRaius)
        {
            ChangeState(enemyView.chasingState);
        }
        faceTarget();
        Attack();
    }
}
