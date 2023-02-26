using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    GameObject[] players;
    public float speed;
    
    private Vector3 oldPos;
    private Camera cameraComponent;
    public float screenAspect, camHalfHeight, camHalfWidth;

    public float timeToStart;
    float timer = 0f;

    private void Awake()
    {
        cameraComponent = GetComponent<Camera>();
        screenAspect = (float)Screen.width / (float)Screen.height;
        camHalfHeight = cameraComponent.orthographicSize;
        camHalfWidth = screenAspect * camHalfHeight;
    }

    void Start(){
        players = GameObject.FindGameObjectsWithTag("Player");
    }

    bool NotReadyToCull(){
        return timer < timeToStart;
    }
    // Update is called once per frame
    void LateUpdate()
    {
        if (NotReadyToCull()){
            timer += Time.deltaTime;
        }

        oldPos = transform.position;
        players = GameObject.FindGameObjectsWithTag("Player");
/*        float avgHeight = GetHeightOfFirstPlace();*/
        float avgHeight = CalculateAvgHeight();
        float avgLead = CalculateAvgLead();

        transform.position = new Vector3(oldPos.x + Mathf.Max(speed, (avgLead - camHalfWidth)) * Time.deltaTime ,oldPos.y + (avgHeight - oldPos.y) * Time.deltaTime, oldPos.z);
    }

    float CalculateAvgHeight(){
        float height = 0;
        int count = 0;
        foreach (GameObject player in players){
            float yPos = player.transform.position.y;
            if (player.activeSelf){  
                if (yPos < oldPos.y - 5*camHalfHeight && !NotReadyToCull())
                {
                    player.GetComponent<PoolItem>().DestroyToPool();
                } else
                {
                    height += yPos;
                    count += 1;
                }
            }
        }
        if (count == 0) return 0;
        return height / count;
    }

    float CalculateAvgLead()
    {
        float xLeft = gameObject.transform.position.x - camHalfWidth;
        float sum = 0;
        int count = 0;
        foreach (GameObject player in players)
        {
            float xPos = player.transform.position.x;
            if (player.activeSelf)
            {
                if ((xPos < xLeft - 0.1*camHalfWidth || xPos > xLeft + 4 * camHalfWidth) && !NotReadyToCull())
                {
                    player.GetComponent<PoolItem>().DestroyToPool();
                }
                else
                {
                    sum += xPos - xLeft;
                    count += 1;
                }
            }
        }
        if (count == 0) return 0;
        return sum / count;
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
