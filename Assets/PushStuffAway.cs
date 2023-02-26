using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushStuffAway : MonoBehaviour
{
    public float strength;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D c){
        Rigidbody2D rb = c.GetComponent<Rigidbody2D>();
        if (rb != null){
            rb.AddForce(transform.right * strength * Time.fixedDeltaTime);
        }
    }
}
