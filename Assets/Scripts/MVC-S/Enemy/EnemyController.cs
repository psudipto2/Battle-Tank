using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController
{
    private EnemyModel EnemyModel { get; }
    private EnemyView enemyView { get; }
    private Rigidbody rigidbody;
    public EnemyService EnemyService { get; }

    public EnemyController(EnemyModel enemyModel, EnemyView enemyPrefab)
    {
        EnemyModel = enemyModel;
        enemyView = GameObject.Instantiate<EnemyView>(enemyPrefab);
        rigidbody = enemyView.GetComponent<Rigidbody>();
        enemyView.SetEnemyController(this);
        EnemyModel.SetEnemyController(this);
        Debug.Log("EnemyView Created");
    }
    public Vector3 GetCurrentTankPosition()
    {
        return enemyView.transform.position;
    }

}
