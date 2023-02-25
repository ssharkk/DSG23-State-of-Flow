using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileData : MonoBehaviour
{
    public Direction direction;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Rotation(){

    }

    public void SetDirection(Direction newDirection){
        direction = newDirection;
    }
}
