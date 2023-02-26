using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class IntroCameraMover : MonoBehaviour
{
    [SerializeField]
    float CameraMoveSpeed  =1f;
    GameObject camera;
    // Start is called before the first frame update
    private void Awake()
    {
        Camera cam = FindObjectOfType<Camera>();
        camera = cam.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        MoveCamera();
    }

    private void MoveCamera()
    {
        Vector3 currentCameraPos = camera.transform.position;
        Vector3 newPos = new Vector3(currentCameraPos.x, currentCameraPos.y - Time.deltaTime * CameraMoveSpeed, currentCameraPos.z);
        camera.transform.position = newPos;
    }

}
