using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateSummariser : MonoBehaviour
{
    public int waitTime;
    public States majorityState = States.LIQUID;
    // Start is called before the first frame update
    void Awake()
    {
        
    }

    void Start(){
        StartCoroutine(RepeatedlySummariseState());
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator RepeatedlySummariseState(){
        while (true){
            SummariseState();
            Debug.Log(majorityState);
            yield return new WaitForSeconds(waitTime);
        }
    }

    void SummariseState(){
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        Dictionary<States, int> stateCount = new Dictionary<States, int>();
        stateCount.Add(States.GAS, 0);
        stateCount.Add(States.LIQUID, 0);
        stateCount.Add(States.SOLID, 0);
        foreach (GameObject player in players){
            if (player.activeSelf){
                States newState = player.GetComponent<Player>().GetStates();
                stateCount[newState] +=1;
                
            }
        }
        States maxState = States.LIQUID;
        int biggestState = 0;
        foreach (States key in stateCount.Keys){
            if (stateCount[key] > biggestState){
                maxState = key;
                biggestState = stateCount[key];
            }
        }

        majorityState = maxState;

    }
}
