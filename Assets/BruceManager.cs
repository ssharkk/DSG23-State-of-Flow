using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BruceManager : MonoBehaviour
{
    Image[] bruces;
    public int[] timeThresholds;
    public int bruceToDisplay;
    public Timer time;
    // Start is called before the first frame update

    void Awake(){
        bruces = GetComponentsInChildren<Image>();
        ChangeBruceState(0);
        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (time.GetTime() > timeThresholds[bruceToDisplay]){
            bruceToDisplay += 1;
            bruceToDisplay %= bruces.Length;
            ChangeBruceState(bruceToDisplay);

        }
    }

    public void ChangeBruceState(int bruceState){
        if (bruceState > bruces.Length){
            return;
        }
        foreach (Image bruce in bruces){
            bruce.color = Color.clear;
        }
        bruces[bruceState].color = Color.white;
    }
}
