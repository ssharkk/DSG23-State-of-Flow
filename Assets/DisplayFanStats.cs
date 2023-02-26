using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayFanStats : MonoBehaviour
{
    Canvas fanCanvas;
    TMP_Text text; 
    PushStuffAway fanBehaviour;
    // Start is called before the first frame update
    void Awake()
    {
        fanBehaviour = GetComponent<PushStuffAway>();
        fanCanvas = GetComponentInChildren<Canvas>();
        text = GetComponentInChildren<TMP_Text>();

    }

    void Start(){
        fanCanvas.worldCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (fanBehaviour.battery > 0){
            text.text = "Battery " + Mathf.Round(fanBehaviour.battery).ToString();
        }
        else {
            text.text = "Respawning...";
        }

    }
}
