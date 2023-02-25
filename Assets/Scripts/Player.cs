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

    public float yVelocityActivationThreshold = 1f;



    [Range(-20f, 120f)]
    float currentTemperature;

    bool isInAir = true;

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

        if (isOnWind)
        {
            ApplyWindForceToPlayer();
        }
        if (inHeatZone)
        {
            ApplyZoneTemperatureChange(heatZoneSpeed);
        }
        else if (inCoolZone)
        {
            ApplyZoneTemperatureChange(-coolZoneSpeed);
        }
        else
        {
            NaturallyCoolDown();
        }
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if(rb.velocity.y > 0.01f * yVelocityActivationThreshold || rb.velocity.y < -0.01f * yVelocityActivationThreshold)
        {
            isInAir = true;
        } else
        {
            isInAir = false;
        }

        if (!isInAir && rb.velocity.x < 1f)
        {
            TestMove(); //For test purpose, delete later.
        }
    }

    private void ApplyZoneTemperatureChange(float temperatureChange)
    {
        currentTemperature += temperatureChange * Time.deltaTime;
        if(currentTemperature > 120f)
        {
            currentTemperature = 120f;
        }else if(currentTemperature < -20f)
        {
            currentTemperature = -20f;
        }
        StateChange();
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
        if (currentTemperature > 120f)
        {
            currentTemperature = 120f;
        }
        StateChange();
    }

    private void StateChange()
    {
        if (currentTemperature <= 0f)
        {
            currentState = States.SOLID;
            // Debug.Log(currentTemperature);
        }
        else if (currentTemperature >= 100f)
        {
            currentState = States.GAS;
            // Debug.Log(currentTemperature);
        }
        else
        {
            currentState = States.LIQUID;
            // Debug.Log(currentTemperature);
        }
    }

    internal void CoolDown()
    {
        currentTemperature -= coolDownAmount;
        
        if (currentTemperature < -20f)
        {
            currentTemperature = -20f;
        }
        StateChange();
    }

    private void NaturallyCoolDown()
    {
        currentTemperature -= coolDownSpeed * Time.deltaTime;
        
        if (currentTemperature < -20f)
        {
            currentTemperature = -20f;
        }
        StateChange();
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
