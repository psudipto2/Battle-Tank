using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyService : MonoSingletonGeneric<EnemyService>
{
    public EnemyView enemyView;
    public EnemyScriptableObjectList enemyList;
    private EnemyModel currentenemyModel;
    private EnemyController enemyController;
    public EnemyScriptableObject enemyScriptable { get;  private set; }
    private List<EnemyController> enemies = new List<EnemyController>();
    private void Start()
    {
        CreateNewEnemy();
    }
    public void CreateNewEnemy()
    {
        int rand = Random.Range(0, enemyList.enemies.Length);
        enemyScriptable = enemyList.enemies[rand];

        EnemyModel enemyModel = new EnemyModel(enemyScriptable, enemyList);
        currentenemyModel = enemyModel;
        enemyController = new EnemyController(enemyModel, enemyScriptable.enemyView);
        enemies.Add(enemyController);
    }

    public void DestroyEnemy(EnemyController enemyController)
    {
        enemyController.DestoryController();
    }

    public void SetEnemyController(EnemyController _enemyController)
    {
        enemyController = _enemyController;
    }
    public EnemyModel GetCurrentEnemyModel()
    {
        return currentenemyModel;
    }
    public EnemyController GetEnemyController(int index = 0)
    {
        return enemies[index];
    }
}
