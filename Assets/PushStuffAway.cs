using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushStuffAway : MonoBehaviour
{
    public float strength;

    public float battery;
    public float timeTilNew;
    [HideInInspector]
    public float timer;
    bool isSpent = false;
    bool isOn = false;
    DockingPortBehaviour behaviour;
    SpinFan spinny;
    // Start is called before the first frame update
    float defaultSpinny;
    MoveBlock clickChecker;
    void Start()
    {
        spinny = GetComponent<SpinFan>();
        clickChecker = GetComponent<MoveBlock>();
        defaultSpinny = spinny.speed;
    }

    // Update is called once per frame
    void Update()
    {   
        if (isOn && !isSpent){
            spinny.speed = defaultSpinny;
        }
        else {
            spinny.speed = 0;
        }


        if (!isSpent && isOn){
        battery -= Time.deltaTime;
        }

        if (battery <= 0){
            isSpent = true;
        }
        
        if (timer < timeTilNew && isSpent){
            timer += Time.deltaTime;
            spinny.speed = 0;
        }
        else if (isSpent) {
            behaviour.RespawnFan();
            Destroy(gameObject);
        }
        isOn = clickChecker.isDragging;

    }

    void OnTriggerStay2D(Collider2D c){
        Rigidbody2D rb = c.GetComponent<Rigidbody2D>();
        if (rb != null && !isSpent && isOn){
            rb.AddForce(transform.right * strength * Time.fixedDeltaTime);
        }
    }
    void OnBecameInvisible() {
        behaviour.RespawnFan();
        Destroy(gameObject);
    }

    public void SetDocker(DockingPortBehaviour behaviour){
        this.behaviour = behaviour;
    }
}
