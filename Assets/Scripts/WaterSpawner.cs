using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class WaterSpawner : MonoBehaviour
{
    public int spawnCount = 1000;
    public float spawn_velocity = 0f, spawner_width = 1f;
    public PoolType itemSpawner;


    // Update is called once per frame
    void FixedUpdate()
    {
        Color color = new Color(0.5f, 0.5f, 1.0f);
        Debug.DrawLine(Vector3.zero, new Vector3(0, 5, 0), color);

        if (spawnCount > 0)
        {
            GameObject tmp = itemSpawner.sharedInstance.GetPooledObject();
            tmp.gameObject.transform.position = transform.position + transform.right * Random.Range(-0.5f, 0.5f) * spawner_width;
            Rigidbody2D rb = tmp.gameObject.GetComponent<Rigidbody2D>();
            rb.velocity = transform.up * (-spawn_velocity);
            spawnCount -= 1;
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
