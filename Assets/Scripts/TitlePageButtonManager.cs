using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitlePageButtonManager : MonoBehaviour
{
    public void LoadGameScene()
    {
        //load the game scene using scene management
        //int index = some index
        //SceneManager.LoadScene(index);
        Debug.Log("Load first game scene");
    }

    public void LoadSettingScene()
    {
        //load the setting scene using scene management
        //int index = some index
        //SceneManager.LoadScene(index);
        Debug.Log("Load setting scene.");
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }



}
