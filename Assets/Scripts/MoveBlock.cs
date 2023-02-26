using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class MoveBlock : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    bool isDragging = false;
    bool isCursorOnObject = false;

    Vector2 offset;
    Mouse mouse;
    public float defaultGravity;
    
    // Start is called before the first frame update
    void Start()
    {
        mouse = Mouse.current;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDragging)
        {
            if (Input.GetMouseButton(0))
            {
                Debug.Log("Mouse down");
                if(isCursorOnObject)
                {
                    Debug.Log("Selected");
                    isDragging = true;
                    offset = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
                    GetComponent<Rigidbody2D>().gravityScale = 0;
                }
            }
        }
        else
        {
            if (Input.GetMouseButtonUp(0))
            {
                isDragging = false;
                GetComponent<Rigidbody2D>().gravityScale = defaultGravity;
            }
            else
            {
                Vector2 currentMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                transform.position = currentMousePos - offset;
            }
        }
    }

    //Detect if the Cursor starts to pass over the GameObject
    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        isCursorOnObject = true;
    }

    //Detect when Cursor leaves the GameObject
    public void OnPointerExit(PointerEventData pointerEventData)
    {
        isCursorOnObject = false;
    }

}
