using UnityEngine;

    [CreateAssetMenu(fileName = "TankScriptableObject", menuName = "ScriptableObject/Tank/NewTankScriptableObject")]
    public class TankScriptableObject : ScriptableObject
    {
        public TankType tankType;
        public BulletScriptableObject bulletType;
        public TankView tankView;
        public float health;
        public float movementSpeed;
        public float rotationSpeed;
        public float fireRate;
        public Material material;
    }