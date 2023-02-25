using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerBuild : MonoBehaviour
{
    bool hasTriggered = false;
    public UnityEvent triggerBuild;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Init(UnityEvent startEvent){
        triggerBuild = startEvent;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D c){
        if (c.CompareTag("Player") && !hasTriggered){
            hasTriggered = true;
            Debug.Log("We made it");
            triggerBuild.Invoke();
        }
    }
}
