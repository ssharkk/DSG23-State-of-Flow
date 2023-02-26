using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
public class StateSummariser : MonoBehaviour
{

    ParamRef prarameter;
    public float waitTime;
    public States majorityState = States.LIQUID;
    private FMOD.Studio.EventInstance instance;

    public FMODUnity.EventReference fmodEvent;
    public float stateMusic;
    // Start is called before the first frame update
    void Awake()
    {
        instance = FMODUnity.RuntimeManager.CreateInstance(fmodEvent);
        instance.start();
    }

    void Start(){

        StartCoroutine(RepeatedlySummariseState());
    }

    // Update is called once per frame
    void Update()
    {
        switch(majorityState){
            case States.LIQUID:
                stateMusic = 0.9f;
                break;
            case States.SOLID:
                stateMusic = 1.6f;
                break;
            default:
                stateMusic = 2.4f;
                break;
        }
        instance.setParameterByName("State", stateMusic);
    }

    IEnumerator RepeatedlySummariseState(){
        while (true){
            SummariseState();
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
