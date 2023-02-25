using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolItem : MonoBehaviour
{
    public PoolType type;


    public void DestroyToPool()
    {
        Debug.Log(type.sharedInstance);
        type.sharedInstance.AddToPool(this.gameObject);
        this.gameObject.SetActive(false);
        
    }
}
