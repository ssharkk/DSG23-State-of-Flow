using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD;

public class PlayAmbience : MonoBehaviour
{

    // Start is called before the first frame update
    void Awake()
    {
        
    }

    void Start(){
        AudioManager.instance.PlayOneShot(FMOD_Events.instance.Vending_Machine, Vector3.zero);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
