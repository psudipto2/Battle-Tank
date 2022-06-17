using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChasingState : State
{
    public override void OnStateEnter()
    {
        base.OnStateEnter();
        enemyView.activeState = EnemyStates.Chasing;
        Debug.Log("Chasing Started");
        //ChasePlayer();
    }

    public override void OnStateExit()
    {
        base.OnStateExit();
    }
    private void FixedUpdate()
    {
        ChasePlayer();
    }
    private void ChasePlayer()
    {
        faceTarget();
        navMeshAgent.SetDestination(enemyView.target);
        if (GetDistance() >= enemyModel.chaseRadius)
        {
            ChangeState(enemyView.patrolingState);
        }
        else if (GetDistance() <= enemyModel.attackRaius)
        {
            ChangeState(enemyView.attackingState);
        }
        
    }
}
