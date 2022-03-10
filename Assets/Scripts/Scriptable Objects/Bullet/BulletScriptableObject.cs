using System;
using UnityEngine;

    [CreateAssetMenu(fileName = "BulletScriptableObject", menuName = "ScriptableObject/Bullet/NewBulletScriptableObject")]
    public class BulletScriptableObject : ScriptableObject
    {
        public float speed;
        public float damage;
        public BulletType bulletType;
        public BulletView bulletView;
}
