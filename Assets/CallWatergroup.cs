using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallWatergroup : MonoBehaviour
{
    TemperatureButtons buttons;
    // Start is called before the first frame update
    void Awake()
    {
        buttons = GameObject.FindGameObjectWithTag("Essential").GetComponent<TemperatureButtons>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PressHot(){
        buttons.HeatUp();
    }

    public void PressCold(){
        buttons.CoolDown();
    }
}
