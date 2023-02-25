using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MapGenerator : MonoBehaviour
{
    
    public GameObject tilePrefab;
    public int maxSize;
    float tileSize;
    public Vector3 startLocation;

    TileData currentTileData;
    Queue<GameObject> currentTiles;
    GameObject currentTile;

    // Start is called before the first frame update
    void Awake()
    {
        tileSize = tilePrefab.GetComponent<SpriteRenderer>().size.x;
        currentTiles = new Queue<GameObject>();
        
    }

    void Start(){
        BuildALevel(maxSize);
    }

    void AddFirstTile(){
         currentTile = Instantiate(tilePrefab, startLocation, Quaternion.identity);
         currentTileData = currentTile.GetComponent<TileData>();
         currentTileData.SetDirection(Direction.EAST);
         currentTiles.Enqueue(currentTile);
    }

    void AddTile(Direction direction){
         Vector2 newPosition = GetNewPosition(direction);
         currentTile = Instantiate(tilePrefab, newPosition, Quaternion.identity);
         currentTileData = currentTile.GetComponent<TileData>();
         currentTileData.SetDirection(direction);
         currentTiles.Enqueue(currentTile);
    }

    Vector2 GetNewPosition(Direction direction){
        Vector3 previousPosition = currentTile.transform.position;
        switch (direction){
            case Direction.EAST:
                return new Vector2(previousPosition.x + tileSize, previousPosition.y);
            case Direction.NORTH:
                return new Vector2(previousPosition.x, previousPosition.y + tileSize);
            default:
                return new Vector2(previousPosition.x, previousPosition.y - tileSize);

        }
    
    }

    void AddNewTile(){
        Direction newDirection = PickNewDirection();
        AddTile(newDirection);
    }

    void BuildALevel(int maxSize){
        AddFirstTile();
        for (int i = 1; i < maxSize; i++){
            AddNewTile();
        }
        
    }

    Direction PickNewDirection(){
        Direction last = currentTileData.direction;
        int result;
        switch (last){
            case Direction.EAST:
                result = Random.Range(0, 3);
                return (Direction) result;
            case Direction.NORTH:
                result = Random.Range(1, 3);
                return (Direction) result;
            default:
                result = Random.Range(0, 2);
                return (Direction) result;
                

        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
