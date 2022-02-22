using System;
using UnityEngine;

namespace Bullet
{
    [CreateAssetMenu(fileName = "BulletSOList", menuName = "ScriptableObject/Bullet/NewBulletScriptableObjectList")]
    public class BulletScritableObjectList: ScriptableObject
    {
        public BulletScriptableObject[] bulletsTypes;
    }
}
