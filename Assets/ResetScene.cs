using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using FMODUnity;


public class ResetScene : MonoBehaviour
{

    public FMODUnity.EventReference musicEvent;
    FMOD.ChannelGroup mcg;
    // Start is called before the first frame update
    public void Reset(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
