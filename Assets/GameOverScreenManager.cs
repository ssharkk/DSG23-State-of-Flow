using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScreenManager : MonoBehaviour
{
    public PoolType pooledStuff;
    Transform[] children;
    // Start is called before the first frame update
    void Awake()
    {
        children = transform.GetComponentsInChildren<Transform>();
    }

    void Start(){
        foreach (Transform child in children){
            child.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (pooledStuff.activeCount <= 0){
            foreach(Transform child in children){
                child.gameObject.SetActive(true);
            }
        }
    }


}
