using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "My Assets/Pool Type")]
public class PoolType : ScriptableObject
{
    [HideInInspector]
    public PoolManager sharedInstance;
    public GameObject objectToPool;
    public int poolCountLimit;

    [HideInInspector]
    public int activeCount;
}
