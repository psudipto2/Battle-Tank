using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class State : MonoBehaviour
{
    [SerializeField] protected EnemyView enemyView;
    protected EnemyModel enemyModel;
    protected NavMeshAgent navMeshAgent { get; set; }
    public void Start()
    {
        enemyView = EnemyService.Instance.GetEnemy();
        navMeshAgent = enemyView.navMeshAgent;
        enemyModel = enemyView.enemyController.EnemyModel;
        navMeshAgent.angularSpeed = enemyView.enemyController.EnemyModel.rotationSpeed;
        navMeshAgent.speed = enemyView.enemyController.EnemyModel.movementSpeed;
        navMeshAgent.stoppingDistance = enemyView.enemyController.EnemyModel.attackRaius;
    }
    public virtual void OnStateEnter()
    {
        this.enabled = true;
    }
    public virtual void OnStateExit()
    {
        this.enabled = false;
    }
    public void Update()
    {
        enemyView.target = TankService.Instance.tankController.tankView.GetCurrentTankPosition();
    }
    public void ChangeState(State newState)
    {
        if (enemyView.currentState != null)
        {
            enemyView.currentState.OnStateExit();
        }

        enemyView.currentState = newState;
        enemyView.currentState.OnStateEnter();
    }
    protected void faceTarget()
    {
        Vector3 direction = (enemyView.target - enemyView.transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        enemyView.transform.rotation = Quaternion.Slerp(enemyView.transform.rotation, lookRotation, Time.deltaTime * enemyModel.rotationSpeed);
    }
    protected float GetDistance()
    {
        float distance = Vector3.Distance(enemyView.target, enemyView.transform.position);
        return distance;
    }
}
