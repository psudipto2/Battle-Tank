using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class EnemyView : MonoBehaviour,IDamagable
{
    [HideInInspector] public NavMeshAgent navMeshAgent { get;  set; }
    [HideInInspector] public GameObject TankDestroyVFX;
    public EnemyController enemyController;
    public Rigidbody rigidbody;
    [SerializeField] public Vector3 target;
    public Transform BulletShootPoint;
    public MeshRenderer[] childs;
    [SerializeField] public TankView tankView;
    public State currentState;
    [SerializeField] public EnemyStates initialState;
    [SerializeField] public EnemyStates activeState;
    public EnemyPatrolingState patrolingState;
    public EnemyChasingState chasingState;
    public EnemyAttackingState attackingState;
    public void SetEnemyController(EnemyController _enemyController)
    {
        enemyController = _enemyController;
    }
    private void Start()
    {

        
        target = TankService.Instance.tankController.tankView.GetCurrentTankPosition();
        enemyController.InitialEnemyState();
        InitializeState();
    }
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }
    private void FixedUpdate()
    {
        //target = TankService.Instance.tankController.tankView.GetCurrentTankPosition();
    }
    public void ChangeColor(Material material)
    {
        for (int i = 0; i < childs.Length; i++)
        {
            childs[i].material = material;
        }
    }
    private void InitializeState()
    {
        switch (initialState)
        {
            case EnemyStates.Attacking:
                currentState = attackingState;
                break;
            case EnemyStates.Chasing:
                currentState = chasingState;
                break;
            case EnemyStates.Patroling:
                currentState = patrolingState;
                break;
            default:
                currentState = null;
                break;
        }
        Debug.Log("Entering State");
        ChangeState(currentState);
    }


    public Vector3 GetCurrentEnemyPosition()
    {
        return transform.position;
    }
    public void TakeDamage(float damage)
    {
        enemyController.ApplyDamage(damage);
    }

    public void DestroyView()
    {
        Destroy(this.gameObject);
        BulletShootPoint = null;
        enemyController = null;
        navMeshAgent = null;
    }
    public void ChangeState(State newState)
    {
        if (currentState != null)
        {
            currentState.OnStateExit();
        }

        currentState = newState;
        currentState.OnStateEnter();
    }
}
