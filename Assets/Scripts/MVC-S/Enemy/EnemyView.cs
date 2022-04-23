using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class EnemyView : MonoBehaviour,IDamagable
{
    public NavMeshAgent navMeshAgent { get;  set; }
    public GameObject TankDestroyVFX;
    private EnemyController enemyController;
    public Rigidbody rigidbody;
    private GameObject Tank;
    public Transform target;
    public Transform BulletShootPoint;
    private float timer;
    bool alreadyAttacked;
    public bool playerInSightRange, playerInAttackRange;
    public MeshRenderer[] childs;
    [HideInInspector] public TankView tankView;
    public void SetEnemyController(EnemyController _enemyController)
    {
        enemyController = _enemyController;
    }
    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        Tank = GameObject.Find("Tank(Clone)");
        target = tankView.GetComponent<Transform>();
        navMeshAgent.angularSpeed = enemyController.EnemyModel.rotationSpeed;
        navMeshAgent.speed = enemyController.EnemyModel.movementSpeed;
        navMeshAgent.stoppingDistance = enemyController.EnemyModel.attackRaius;
    }
    private void Update()
    {
        enemyController.EnemyStateController();
    }
    public void ChangeColor(Material material)
    {
        for (int i = 0; i < childs.Length; i++)
        {
            childs[i].material = material;
        }
    }

    /* private void AttackPlayer()
     {
         //Make sure enemy doesn't move
         navMeshAgent.SetDestination(transform.position);

         transform.LookAt(target);

         if (!alreadyAttacked)
         {
             ///Attack code here
             BulletService.Instance.CreateNewBullet(BulletShootPoint.position, transform.rotation, enemyController.EnemyModel.bullet);
             ///End of attack code

             alreadyAttacked = true;
             Invoke(nameof(ResetAttack), 2f);
         }
     }

     private void ResetAttack()
     {
         alreadyAttacked = false;
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
         transform.LookAt(newDestination);
         navMeshAgent.SetDestination(newDestination);
     }
     public Vector3 GetRandomPosition()
     {
         Vector3 randDir = UnityEngine.Random.insideUnitSphere * enemyController.EnemyModel.PatrolRaius;
         randDir += EnemyService.Instance.enemyScriptable.enemyView.transform.position;
         NavMeshHit navHit;
         NavMesh.SamplePosition(randDir, out navHit, enemyController.EnemyModel.PatrolRaius, NavMesh.AllAreas);
         return navHit.position;
     }

     private void BulletShoot()
     {
         float distance = Vector3.Distance(target.position, transform.position);
         if (distance <= enemyController.EnemyModel.chaseRadius)
         {
             faceTarget();
             navMeshAgent.SetDestination(target.position);
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
         Vector3 direction = (target.position - transform.position).normalized;
         Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
         transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * enemyController.EnemyModel.rotationSpeed);
     }*/
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
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, enemyController.EnemyModel.PatrolRaius);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, enemyController.EnemyModel.chaseRadius);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, enemyController.EnemyModel.attackRaius);
    }
}
