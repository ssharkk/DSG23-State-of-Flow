using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FluidCameraTextureGenerate : MonoBehaviour
{
    public RenderTexture rt;
    public RawImage target;

    // Start is called before the first frame update
    void Start()
    {
        Camera camera = gameObject.GetComponent<Camera>();
        int resWidth = Screen.width;
        int resHeight = Screen.height;
        /*
                rt = new RenderTexture(resWidth/6, resHeight/6, 24);*/
        rt = new RenderTexture((int)(((float)resWidth) / ((float)resHeight) * 128f), 128, 24);

        camera.targetTexture = rt; //Create new renderTexture and assign to camera
        target.texture = rt;
    }

}
