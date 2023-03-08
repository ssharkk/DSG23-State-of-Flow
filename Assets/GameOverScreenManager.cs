using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;

public class GameOverScreenManager : MonoBehaviour
{
    public PoolType pooledStuff;
    Transform[] children;
    bool gameOver = false;
    public UnityEvent GameOver;
    public int activeStuff;
    public float introTimer;
    float timer = 0;
    // Start is called before the first frame update
    void Awake()
    {
        children = transform.GetComponentsInChildren<Transform>().Where(c => c != transform).ToArray();
    }

    void Start(){
        foreach (Transform child in children){
            child.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (timer <= introTimer){
            timer += Time.deltaTime;
        }
        if (pooledStuff.activeCount <= 1 && timer >= introTimer && !gameOver){
            Debug.Log("wow!! dead");
            gameOver = true;
            GameOver.Invoke();
            foreach(Transform child in children){
                child.gameObject.SetActive(true);
            }
        }
    }


}
