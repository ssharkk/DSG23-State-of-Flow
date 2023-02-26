using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroSceneLoader : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
                Debug.Log("Load menu scene");
        //SceneManager.LoadScene(1);
    }
}
