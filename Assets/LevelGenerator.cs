using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LevelGenerator : MonoBehaviour
{
    public GameObject[] chunkPrefabs;
    int index = 0;
    Queue<GameObject> aliveChunks;

    Tilemap currentChunk;
    // Start is called before the first frame update

    void Awake(){
        aliveChunks = new Queue<GameObject>();
    }
    void Start()
    {

        GameObject current = Instantiate(chunkPrefabs[0]);
        aliveChunks.Enqueue(current);
        currentChunk = current.GetComponent<Tilemap>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenerateChunk(){

    }

    GameObject pickChunk(){
        int newIndex = Random.Range(0, chunkPrefabs.Length);
        while (newIndex == index){
            newIndex = Random.Range(0, chunkPrefabs.Length);
        }
        index = newIndex;
        return chunkPrefabs[index];
    }
}
