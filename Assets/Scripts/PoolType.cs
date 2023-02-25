using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "My Assets/Pool Type")]
public class PoolType : ScriptableObject
{
    public PoolManager sharedInstance;
    public GameObject objectToPool;
    public int maxToSpawn;
}
