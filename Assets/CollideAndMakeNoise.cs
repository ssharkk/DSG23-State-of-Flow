using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideAndMakeNoise : MonoBehaviour
{

    public bool audioDude = false;
    AudioManager manager;
    // Start is called before the first frame update
    void Start()
    {
        manager = AudioManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D c){
        if (audioDude){
            manager.PlayOneShot(FMOD_Events.instance.Liquid_Hit, transform.position);
        }
        
    }


}
