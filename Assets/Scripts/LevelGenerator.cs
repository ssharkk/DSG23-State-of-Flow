using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.Events;
using System.Linq;

public class LevelGenerator : MonoBehaviour
{
    public Tilemap[] chunkPrefabs;
    public Tilemap startScreen;
    int index = -1;
    Queue<Tilemap> aliveChunks;

    Tilemap currentChunk;
    // Start is called before the first frame update
    UnityEvent triggerNewChunk;

    void Awake(){
        aliveChunks = new Queue<Tilemap>();
        triggerNewChunk = new UnityEvent();
        triggerNewChunk.AddListener(GenerateChunk);
    }
    void Start()
    {
        GameObject current = Instantiate(startScreen.gameObject);
        current.transform.SetParent(transform);
        currentChunk = current.GetComponent<Tilemap>();
        BuildTrigger(currentChunk);
        FixGameObjectPosition(currentChunk);
        currentChunk.gameObject.name = "First";
        aliveChunks.Enqueue(currentChunk);
        GenerateChunk();
        GenerateChunk();
        GenerateChunk();

    }

    void KillChunk(){
        Tilemap soonToDie = aliveChunks.Dequeue();
        Destroy(soonToDie.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void BuildTrigger(Tilemap chunk){
        BoxCollider2D trigger = chunk.gameObject.AddComponent<BoxCollider2D>();
        Vector3 size = chunk.CellToWorld(chunk.cellBounds.size);
        trigger.size = new Vector2(1, size.y);
        trigger.isTrigger = true;
        chunk.gameObject.AddComponent<TriggerBuild>().Init(triggerNewChunk);

    }

    public Vector3 GetChunkMidPoint(Tilemap chunk){
        chunk.CompressBounds();
        return chunk.cellBounds.center;
    }

    Vector3Int FindPositionOfGameObject(Tilemap chunk){
        foreach (Vector3Int position in chunk.cellBounds.allPositionsWithin){
            if (chunk.GetInstantiatedObject(position) != null){
                return position;
            }
        }
        return Vector3Int.zero;
    }

    void FixGameObjectPosition(Tilemap chunk){
        foreach (Vector3Int position in chunk.cellBounds.allPositionsWithin){
            GameObject coolObject = chunk.GetInstantiatedObject(position);
            if (coolObject != null){
                Vector3 localPosition = chunk.GetCellCenterLocal(position);
                coolObject.transform.localPosition = localPosition;
            }
            
        }
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
        Vector3 endPosWorld = currentChunk.GetCellCenterWorld(endPos);
        Debug.Log("EndPos for " +  gameObject.name + " At " + endPosWorld);
        
        Tilemap newChunkPrefab = PickChunk();
        GameObject newObj = Instantiate(newChunkPrefab.gameObject, currentChunk.transform.position, Quaternion.identity);
        newObj.transform.SetParent(transform);

        Tilemap newChunk = newObj.GetComponent<Tilemap>();
        Vector3Int startPos = GetStartPosition(newChunk);
        Vector3 startPosWorld = currentChunk.GetCellCenterWorld(startPos);
        Debug.Log("StartPos for " +  newObj.name + " At " + startPosWorld);

        
        Vector3 offset = endPosWorld - startPosWorld;
        newObj.transform.position += offset;
        Debug.Log(newObj.transform.position);
        FixGameObjectPosition(newChunk);
        aliveChunks.Enqueue(newChunk);
        BuildTrigger(newChunk);
        currentChunk = newChunk;

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
