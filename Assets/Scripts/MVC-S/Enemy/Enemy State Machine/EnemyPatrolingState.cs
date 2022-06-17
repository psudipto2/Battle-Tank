using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrolingState : State
{
    private float timer;
    public override void OnStateEnter()
    {
        base.OnStateEnter();
        enemyView.activeState = EnemyStates.Patroling;
        SetPatrolingDestination();
    }
    private void Start()
    {
        base.Start();
    }
    public override void OnStateExit()
    {
        base.OnStateExit();
    }
    private void Update()
    {
        base.Update();
        PatrolPlayer();
    }
    private void PatrolPlayer()
    {
        Patroling();
        if (GetDistance() <= enemyModel.chaseRadius && GetDistance() >= enemyModel.attackRaius)
        {
            ChangeState(enemyView.chasingState);
            Debug.Log("Changing State");
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
    private Vector3 GetRandomPosition()
    {
        Vector3 randDir = UnityEngine.Random.insideUnitSphere * enemyModel.PatrolRaius;
        randDir += EnemyService.Instance.enemyScriptable.enemyView.transform.position;
        NavMeshHit navHit;
        NavMesh.SamplePosition(randDir, out navHit, enemyModel.PatrolRaius, NavMesh.AllAreas);
        return navHit.position;
    }
}
