using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class WaterSpawner : MonoBehaviour
{
    public float spawn_velocity = 0f, spawner_width = 1f, spawn_frequency = 1;
    public PoolType itemType;
    private float time_elapsed = 0, spawn_delta;

    private void Awake()
    {
        spawn_delta = 1f / spawn_frequency;
    }

    void Update(){
        spawn_delta = 1f / spawn_frequency;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        /*        Debug.DrawLine(Vector3.zero, new Vector3(0, 5, 0), color);*/
        /*        Debug.Log(spawnCount);*/
        if (itemType.activeCount >= itemType.poolCountLimit)
        {
            return;
        }
        time_elapsed += Time.fixedDeltaTime;
        while ((itemType.activeCount < itemType.poolCountLimit) && (time_elapsed > spawn_delta)) {
            GameObject tmp = itemType.sharedInstance.GetPooledObject();
            tmp.gameObject.transform.position = transform.position + transform.right * Random.Range(-0.5f, 0.5f) * spawner_width;
            tmp.SetActive(true);
            Rigidbody2D rb = tmp.gameObject.GetComponent<Rigidbody2D>();
            rb.velocity = transform.up * (-spawn_velocity);
            time_elapsed -= spawn_delta;
        }
    }
}

[CustomEditor(typeof(WaterSpawner))]
public class WaterSpawnerEditor : Editor
{
    public void OnSceneGUI()
    {
        var t = target as WaterSpawner;
        var tr = t.transform;
        var position = tr.position;
        Handles.color = Color.yellow;
        Handles.DrawLine(position - tr.right * 0.5f * t.spawner_width, position + tr.right * 0.5f * t.spawner_width, 2);
        Handles.DrawDottedLine(position, position - tr.up * 1.5f, 1);
    }
}
