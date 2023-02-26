using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

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
        
        Keyboard keyboard = Keyboard.current;
        Mouse mouse = Mouse.current;
        if (keyboard.zKey.wasPressedThisFrame){
            tempControl.CoolDown();
        }
        if (keyboard.xKey.wasPressedThisFrame ){
            tempControl.HeatUp();
        }
        
    }
}
