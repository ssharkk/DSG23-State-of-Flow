using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinFan : MonoBehaviour
{
    public float speed;
    Transform child;
    // Start is called before the first frame update
    void Awake()
    {
        child = transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        child.eulerAngles += Vector3.forward * speed;
    }
}
