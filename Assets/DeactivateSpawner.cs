using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateSpawner : MonoBehaviour
{
    public float timeUntilActive = 10f;
    bool active;
    float time = 0f;
    GameObject spawner;
    Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        spawner = GameObject.FindGameObjectWithTag("Spawner");
/*        cam = Camera.main;*/
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (time < timeUntilActive){
            time += Time.deltaTime;
            return;
        }
        Debug.Log("camera" + cam);
        Debug.Log("spawner" + spawner);
        Vector3 viewPos = cam.WorldToViewportPoint(spawner.transform.position);
        if (viewPos.x >= 0 && viewPos.x <= 1 && viewPos.y >= 0 && viewPos.y <= 1 && viewPos.z > 0){
            
        } else {
            spawner.SetActive(false);
            this.enabled = false;
        }
    }
}
