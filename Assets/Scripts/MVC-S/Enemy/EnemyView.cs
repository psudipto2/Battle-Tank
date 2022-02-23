using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyView : MonoBehaviour
{
    private EnemyController enemyController;
    public Rigidbody rigidbody;
    public void SetEnemyController(EnemyController _enemyController)
    {
        enemyController = _enemyController;
    }
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }
    public Vector3 GetCurrentEnemyPosition()
    {
        return transform.position;
    }
}
