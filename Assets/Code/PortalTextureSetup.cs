using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTextureSetup : MonoBehaviour
{
    public Camera Camera_B;
    public Material CameraTexture_B;

    // Update is called once per frame
    void Start()
    {
        if (Camera_B.targetTexture != null)
        {
            Camera_B.targetTexture.Release();
        }
        Camera_B.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        CameraTexture_B.mainTexture = Camera_B.targetTexture;
    }
}
