using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{


    TemperatureButtons tempControl;
    // Start is called before the first frame update
    void Awake()
    {
        tempControl = GetComponent<TemperatureButtons>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetButton("Jump")){
            tempControl.CoolDown();
        }
        if (Input.GetButton("Fire3")){
            tempControl.HeatUp();
        }
        
    }
}
