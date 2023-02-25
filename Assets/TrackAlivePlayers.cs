using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TrackAlivePlayers : MonoBehaviour
{
    TMP_Text text;
    int totalPooled;
    public PoolType playerDeets;
    
    // Start is called before the first frame update
    void Awake()
    {
        text = GetComponent<TMP_Text>();
    }

    void Start(){
        totalPooled = playerDeets.maxToSpawn;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        text.text = CountActivePlayers().ToString() + " / " + totalPooled.ToString();
    }

    int CountAllPlayers(){
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        return players.Length;

    }

    int CountActivePlayers(){
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        int count = 0;
        foreach (GameObject player in players){
            if (player.activeInHierarchy){
                count += 1;
            }
        }
        return count;

    }
}
