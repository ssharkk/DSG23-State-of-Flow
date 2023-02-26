using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TrackAlivePlayers : MonoBehaviour
{
    TMP_Text text;
    public PoolType playerDeets;
    
    // Start is called before the first frame update
    void Awake()
    {
        text = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        text.text = CountActivePlayers().ToString() + " / " + CountAllPlayers().ToString();
    }

    int CountAllPlayers(){
        return playerDeets.poolCountLimit;
    }

    int CountActivePlayers(){
        return playerDeets.activeCount;
    }
}
