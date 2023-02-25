using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolItem : MonoBehaviour
{
    PoolType type;


    public void DestroyToPool()
    {
        this.gameObject.SetActive(false);
        type.sharedInstance.AddToPool(this.gameObject);
    }
}
