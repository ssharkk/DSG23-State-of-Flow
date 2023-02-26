using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    // Start is called before the first frame update
    float time = 0;

    float unResettableTime = 0;
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        unResettableTime += Time.deltaTime;
    }

    public int GetTime(){
        return (int) time;
    }

    public float GetUnResettableTime(){
        return Mathf.Round(unResettableTime);
    }

    public void ResetTime(){
        time = 0;
    }
}
