using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayWaterMusic : MonoBehaviour
{
    // Start is called before the first frame update
    float introTime = 12f;
    float timer = 0f;
    float musicState = 0f;
    bool introDone = false;
    StateSummariser summariser;

    private FMOD.Studio.EventInstance instance;

    public FMODUnity.EventReference fmodEvent;
    void Awake()
    {
        summariser = GetComponent<StateSummariser>();
        instance = FMODUnity.RuntimeManager.CreateInstance(fmodEvent);
        instance.start();
    }

    public void StopMusic(){
        instance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        instance.release();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < introTime){
            timer += Time.deltaTime;
        } else{
            musicState = summariser.stateMusic + 1;
            instance.setParameterByName("Music_pick", musicState);
        }
    }
}
