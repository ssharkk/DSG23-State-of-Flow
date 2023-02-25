using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BruceManager : MonoBehaviour
{
    Animator bruceAnimator;
    public int timeToNextBruce;
    Timer time;
    int bruceIndex;
    public int maxBruce = 6;
    // Start is called before the first frame update

    void Awake(){
       
        bruceAnimator = GetComponent<Animator>();
        bruceIndex = 0;
        
    }
    void Start()
    {
         GameObject waterGroup = GameObject.Find("Watergroup");
        time = waterGroup.GetComponent<Timer>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (time.GetTime() > timeToNextBruce && bruceIndex < maxBruce){
            bruceIndex += 1;
            time.ResetTime();
            bruceAnimator.SetInteger("BruceState", bruceIndex);

        }
    }

 
}
