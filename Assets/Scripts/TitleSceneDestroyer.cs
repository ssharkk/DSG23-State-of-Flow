using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleSceneDestroyer : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Destroy the water bulb.
        collision.gameObject.GetComponent<PoolItem>().DestroyToPool();
    }
}
