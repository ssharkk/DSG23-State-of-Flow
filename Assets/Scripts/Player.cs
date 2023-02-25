using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField]
    float maxHorizontalVelocity = 5f;
    
    [SerializeField]
    float moveRightSpeed = 10f; //For test purpose, delete later.

    [SerializeField]
    float startTemperature = 30f;

    [SerializeField]
    float coolDownSpeed = 5f;

    [SerializeField]
    float heatUpAmount = 10f;

    [SerializeField]
    float coolDownAmount = 10f;

    [SerializeField]
    float heatZoneSpeed = 10f;

    [SerializeField]
    float coolZoneSpeed = 10f;

    [Range(-20f, 120f)]
    float currentTemperature;

    private float moveUpSpeed = 3f;

    bool isAlive = true;

    bool isOnWind = false;

    bool inHeatZone = false;

    bool inCoolZone = false;

    States currentState;



    // Start is called before the first frame update
    void Start()
    {
        currentTemperature = startTemperature;
        currentState = States.LIQUID;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAlive)
        {
            return;
        }
        TestMove(); //For test purpose, delete later.
        NaturallyCoolDown();
        if (isOnWind)
        {
            ApplyWindForceToPlayer();
        }
        if (inHeatZone)
        {
            ApplyZoneTemperatureChange(heatZoneSpeed);
        }
        if (inCoolZone)
        {
            ApplyZoneTemperatureChange(-coolZoneSpeed);
        }
    }

    private void ApplyZoneTemperatureChange(float temperatureChange)
    {
        currentTemperature += temperatureChange * Time.deltaTime;
    }

    private void ApplyWindForceToPlayer()
    {
        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.AddForce(Vector2.up * moveUpSpeed * Time.deltaTime);
    }

    internal void SetPlayerEnterDeathZone()
    {
        isAlive = false;
        Debug.Log("Player died.");
    }

    internal void SetPlayerOnWind(bool onWind, float windSpeed)
    {
        isOnWind = onWind;
        moveUpSpeed = windSpeed;
    }

    //For test purpose, delete later.
    private void TestMove()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.AddForce(Vector2.right * moveRightSpeed * Time.deltaTime);
        if(rb.velocity.x > maxHorizontalVelocity)
        {
            rb.velocity = new Vector2(maxHorizontalVelocity, rb.velocity.y);
        }
    }

    internal void HeatUp()
    {
        currentTemperature += heatUpAmount;
        if (currentTemperature >= 100f)
        {
            currentState = States.GAS;
            Debug.Log(currentState);
        }
        else if(currentTemperature < 100f && currentTemperature > 0f)
        {
            currentState = States.LIQUID;
            Debug.Log(currentState);
        }
        if (currentTemperature > 120f)
        {
            currentTemperature = 120f;
        }
    }

    internal void CoolDown()
    {
        currentTemperature -= coolDownAmount;
        if (currentTemperature <= 0f)
        {
            currentState = States.SOLID;
            Debug.Log(currentState);
        }
        else if (currentTemperature < 100f && currentTemperature > 0f)
        {
            currentState = States.LIQUID;
            Debug.Log(currentState);
        }
        if (currentTemperature < -20f)
        {
            currentTemperature = -20f;
        }
    }

    private void NaturallyCoolDown()
    {
        currentTemperature -= coolDownSpeed * Time.deltaTime;
        if(currentTemperature <= 0f)
        {
            currentState = States.SOLID;
            Debug.Log(currentState);
        }
        else if (currentTemperature < 100f && currentTemperature > 0f)
        {
            currentState = States.LIQUID;
            Debug.Log(currentState);
        }
        if (currentTemperature < -20f)
        {
            currentTemperature = -20f;
        }
    }

    internal void ChangeHeatZoneState(bool inZone)
    {
        inHeatZone = inZone;
    }

    internal void ChangeCoolZoneState(bool inZone)
    {
        inCoolZone = inZone;
    }
}
