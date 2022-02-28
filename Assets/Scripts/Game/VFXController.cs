using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXController : MonoSingletonGeneric<VFXController>
{

    public void InstantiateEffects(GameObject Effects, Vector3 position)
    {
        GameObject gameObject = Instantiate(Effects, position, Quaternion.identity);
        Destroy(gameObject, 1f);
    }
}
