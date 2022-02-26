using System;
using UnityEngine;

    [CreateAssetMenu(fileName = "BulletSOList", menuName = "ScriptableObject/Bullet/NewBulletScriptableObjectList")]
    public class BulletScritableObjectList: ScriptableObject
    {
        public BulletScriptableObject[] bulletsTypes;
    }
