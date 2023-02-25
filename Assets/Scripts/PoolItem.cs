using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolItem : MonoBehaviour
{
    public PoolType type;


    public void DestroyToPool()
    {
        if (!gameObject.activeSelf){
            return;
        }
        type.sharedInstance.AddToPool(this.gameObject);
        this.gameObject.SetActive(false);
        
    }
}
