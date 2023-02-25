using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSpawner : MonoBehaviour
{
    public int spawnCount = 1000;
    public PoolType itemSpawner;


    // Update is called once per frame
    void Update()
    {
        if (spawnCount > 0)
        {
            GameObject tmp = itemSpawner.sharedInstance.GetPooledObject();
            tmp.gameObject.transform.position = transform.position;
            spawnCount -= 1;
        }
    }
}
