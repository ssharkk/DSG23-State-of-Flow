using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System.Linq;

public class LevelGenerator : MonoBehaviour
{
    public Tilemap[] chunkPrefabs;
    int index = 0;
    Queue<Tilemap> aliveChunks;

    Tilemap currentChunk;
    // Start is called before the first frame update

    void Awake(){
        aliveChunks = new Queue<Tilemap>();
    }
    void Start()
    {
        GameObject current = Instantiate(chunkPrefabs[0].gameObject);
        current.transform.SetParent(transform);
        currentChunk = current.GetComponent<Tilemap>();
        currentChunk.gameObject.name = "First";
        aliveChunks.Enqueue(currentChunk);
        
        GenerateChunk();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static int GetNumberOfTiles(Tilemap tilemap)
    {
        tilemap.CompressBounds();
        TileBase[] tiles = tilemap.GetTilesBlock(tilemap.cellBounds);
        return tiles.Where(x => x != null).ToArray().Length;
    }


    Vector3Int GetInitPosition(Tilemap chunk){
         foreach (Vector3Int position in chunk.cellBounds.allPositionsWithin){
            if (chunk.HasTile(position)){
                return position;
            }
         }
            return Vector3Int.zero;
    }
    public Vector3Int GetStartPosition(Tilemap chunk){
        chunk.CompressBounds();
        Vector3Int smallest = GetInitPosition(chunk);
        foreach (Vector3Int position in chunk.cellBounds.allPositionsWithin){
            if (position.x < smallest.x && chunk.HasTile(position)){
                smallest = position;
            }
        }
        return smallest;
    }

    public Vector3Int GetEndPosition(Tilemap chunk){
        chunk.CompressBounds();
        Vector3Int largest = GetInitPosition(chunk);
        foreach (Vector3Int position in chunk.cellBounds.allPositionsWithin){
            if (position.x > largest.x && chunk.HasTile(position)){
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
        endPos = new Vector3Int(endPos.x, endPos.y, endPos.z);
        Vector3 endPosWorld = currentChunk.GetCellCenterLocal(endPos);
        
        Tilemap newChunkPrefab = PickChunk();
        GameObject newObj = Instantiate(newChunkPrefab.gameObject);
        newObj.transform.SetParent(transform);

        Tilemap newChunk = newObj.GetComponent<Tilemap>();
        Vector3Int startPos = GetStartPosition(newChunk);
        Vector3 startPosWorld = currentChunk.GetCellCenterLocal(startPos);

        Vector3 offset = endPosWorld - startPosWorld;
        Vector3 original = newChunk.transform.position;
        newChunk.transform.localPosition = original + offset;
        aliveChunks.Enqueue(newChunk);

    }

     public void MoveChunk(Tilemap chunk, Vector3Int offset){
       
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
