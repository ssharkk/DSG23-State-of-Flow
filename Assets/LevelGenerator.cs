using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LevelGenerator : MonoBehaviour
{
    public Tilemap[] chunkPrefabs;
    int index = 0;
    Queue<GameObject> aliveChunks;

    Tilemap currentChunk;
    // Start is called before the first frame update

    void Awake(){
        aliveChunks = new Queue<GameObject>();
    }
    void Start()
    {
        GameObject current = Instantiate(chunkPrefabs[0].gameObject);
        current.transform.SetParent(transform);
        aliveChunks.Enqueue(current);
        currentChunk = current.GetComponent<Tilemap>();
        GenerateChunk();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public Vector3Int GetStartPosition(Tilemap chunk){
        Vector3Int smallest = chunk.cellBounds.allPositionsWithin.Current;
        foreach (Vector3Int position in chunk.cellBounds.allPositionsWithin){
            if (position.x < smallest.x){
                smallest = position;
            }
        }
        return smallest;
    }

    public Vector3Int GetEndPosition(Tilemap chunk){
         Vector3Int largest = chunk.cellBounds.allPositionsWithin.Current;
        foreach (Vector3Int position in chunk.cellBounds.allPositionsWithin){
            if (position.x > largest.x){
                largest = position;
            }
        }
        return largest;
    }
    public void GenerateChunk(){
        //get start
        //get end
        //go to pos before start, pos after end
        //pick chunk
        //problem: gameobject doesn't move properly
        
        Vector3Int endPos = GetEndPosition(currentChunk);
        endPos = new Vector3Int(endPos.x + 1, endPos.y, endPos.z);
        
        Tilemap newChunk = PickChunk();
        Vector3Int newStart = GetStartPosition(newChunk);
        Vector3Int offset = new Vector3Int (endPos.x - newStart.x, endPos.y - newStart.y, endPos.z - newStart.z);
        Debug.Log(newChunk);
        Debug.Log(offset);
        MoveChunk(newChunk, offset);
        var block = newChunk.GetTilesBlock(newChunk.cellBounds);
        BoundsInt newBounds = currentChunk.cellBounds;
        newBounds.size = newBounds.size + newChunk.cellBounds.size;
        currentChunk.SetTilesBlock(newBounds, block);


    }

     public void MoveChunk(Tilemap chunk, Vector3Int offset){
        foreach (Vector3Int position in chunk.cellBounds.allPositionsWithin){
            Tile tileToMove = chunk.GetTile<Tile>(position);
            Debug.Log(tileToMove);
            if (tileToMove != null){
                Vector3Int newPosition = new Vector3Int(position.x + offset.x, position.y + offset.y, position.z + offset.z);
                tileToMove.transform.MultiplyPoint(newPosition);
            }
            //
        }
    }


    Tilemap PickChunk(){
        int newIndex = Random.Range(0, chunkPrefabs.Length);
        while (newIndex == index && chunkPrefabs.Length > 1){
            newIndex = Random.Range(0, chunkPrefabs.Length);
        }
        index = newIndex;
        return chunkPrefabs[index];
    }
}
