using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DockingPortBehaviour : MonoBehaviour
{
    public GameObject fan;
    public float offsetFlibble;
    bool isFanPresent = true;
    Image fanImage;
    Image buttonImage;
    Button button;
    // Start is called before the first frame update
    void Awake()
    {
        fanImage = transform.GetChild(0).GetComponent<Image>();
        button = GetComponent<Button>();
        buttonImage = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void RespawnFan(){
        fanImage.color = Color.white;
        button.interactable = true;
        isFanPresent = true;
        buttonImage.raycastTarget = true;
    }

    public void BuildFan(){
        if (isFanPresent){
            Debug.Log("Building a fan");
            fanImage.color = Color.clear;
            button.interactable = false;
            isFanPresent = false;
            buttonImage.raycastTarget = false;
            //Vector3 centre = Camera.main.transform.position;
            Vector3 mousePos =  Camera.main.ScreenToWorldPoint(Input.mousePosition) + Vector3.left * offsetFlibble;
            Vector3 spawnPoint = new Vector3(mousePos.x, mousePos.y, 0);
            GameObject newFan = Instantiate(fan, spawnPoint, Quaternion.identity);
            newFan.GetComponent<PushStuffAway>().SetDocker(this);
            Debug.Log(newFan.transform.position);

        }
    }
}
