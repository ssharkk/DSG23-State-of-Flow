using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public Stack<GameObject> pooledObjects;
    public PoolType type;

    private void Awake()
    {
        type.sharedInstance = this;
        type.activeCount = 0;
    }

    void Start()
    {
        pooledObjects = new Stack<GameObject>();
    }

    public GameObject GetPooledObject()
    {
        type.activeCount += 1;
        if (pooledObjects.Count > 0)
        {
            return pooledObjects.Pop();
        }
        GameObject go = Instantiate(type.objectToPool);
        go.transform.parent = gameObject.transform;
        return go;
    }
    
    public void AddToPool(GameObject go)
    {
        type.activeCount -= 1;
        pooledObjects.Push(go);
    }

    void OnDestroy()
    {
        foreach (GameObject o in pooledObjects)
        {
            Destroy(o);
        }
        pooledObjects.Clear();
    }

}
