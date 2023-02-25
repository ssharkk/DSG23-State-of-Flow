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
    }

    void Start()
    {
        pooledObjects = new Stack<GameObject>();
    }

    public GameObject GetPooledObject()
    {
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
