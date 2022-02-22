using System;
using UnityEngine;

namespace Bullet
{
    [CreateAssetMenu(fileName = "BulletScriptableObject", menuName = "ScriptableObject/Bullet/NewBulletScriptableObject")]
    public class BulletScriptableObject : ScriptableObject
    {
        public float speed;
        public float damage;
        public BulletType bulletType;

    }

}
