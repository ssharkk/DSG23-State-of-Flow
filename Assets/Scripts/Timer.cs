using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    // Start is called before the first frame update
    float time = 0;
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
    }

    public int GetTime(){
        return (int) time;
    }

    public void ResetTime(){
        time = 0;
    }
}
