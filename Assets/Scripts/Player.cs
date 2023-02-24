using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField]
    float health = 100f;

    [SerializeField]
    float healthChangeSpeed = 5f;

    
    [SerializeField]
    float moveRightSpeed = 10f; //For test purpose, delete later.


    private float moveUpSpeed = 3f;

    bool isAlive = true;

    bool isOnWind = false;


    bool isEnteringDeathZone = false;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAlive)
        {
            return;
        }
        TestMove(); //For test purpose, delete later.
        if (isEnteringDeathZone)
        {
            DecreaseHealth();
        }
        if (isOnWind)
        {
            ApplyWindForceToPlayer();
        }
    }

    private void ApplyWindForceToPlayer()
    {
        this.gameObject.transform.Translate(Vector3.up * moveUpSpeed * Time.deltaTime);
    }

    private void DecreaseHealth()
    {
        health -= healthChangeSpeed * Time.deltaTime;
        if(health <= 0)
        {
            health = 0;
            isAlive = false;
            Debug.Log("Player died.");
        }
    }

    internal void SetPlayerEnterDeathZone(bool inDeathZone)
    {
        isEnteringDeathZone = inDeathZone;
    }

    internal void SetPlayerOnWind(bool onWind, float windSpeed)
    {
        isOnWind = onWind;
        moveUpSpeed = windSpeed;
    }

    //For test purpose, delete later.
    private void TestMove()
    {
        this.gameObject.transform.Translate(Vector3.right * moveRightSpeed * Time.deltaTime);
    }
}
