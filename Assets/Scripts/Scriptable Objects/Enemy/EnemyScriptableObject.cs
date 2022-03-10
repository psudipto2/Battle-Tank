using UnityEngine;

[CreateAssetMenu(fileName = "EnemyScriptableObject", menuName = "ScriptableObject/Enemy/NewEnemyScriptableObject")]
public class EnemyScriptableObject : ScriptableObject
{
    public EnemyType enemyType;
    public BulletScriptableObject bulletType;
    public EnemyView enemyView;
    public float health;
    public float movementSpeed;
    public float rotationSpeed;
    public float fireRate;
    public float patrolingRadius;
    public float ChaseRadius;
    public float AttackRadius;
    public Material material;
}