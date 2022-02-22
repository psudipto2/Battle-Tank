using UnityEngine;

namespace tankView
{
    [CreateAssetMenu(fileName = "TankSOList", menuName = "ScriptableObject/Tank/TankScriptableObjectList")]
    public class TankScriptableObjectList : ScriptableObject
    {
        public TankScriptableObject[] tanks;
    }
}