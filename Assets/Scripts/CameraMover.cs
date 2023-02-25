using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    GameObject[] players;
    public float speed;
    public float heightLerpTime;

    // Start is called before the first frame update
    void Awake()
    {
        
    }

    void Start(){
        players = GameObject.FindGameObjectsWithTag("Player");
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float avgHeight = GetHeightOfFirstPlace();
        Vector3 oldPos = transform.position;
        transform.position = new Vector3(oldPos.x + speed,oldPos.y + avgHeight / heightLerpTime, oldPos.z);
    }

    float CalculateAvgHeight(){
        float height = 0;
        int count = 0;
        foreach (GameObject player in players){
            if (player.activeInHierarchy){  
                height += player.transform.position.y;
                count += 1;
            }
        }
        return height / count;
    }

    float GetHeightOfFirstPlace(){
        float furthestForward = 0;
        float height = 0;
        foreach (GameObject player in players){
             if (player.activeInHierarchy && player.transform.position.x > furthestForward){  
                furthestForward = player.transform.position.x;
                height = player.transform.position.y;
            }
        }
        return height;
    }
}
