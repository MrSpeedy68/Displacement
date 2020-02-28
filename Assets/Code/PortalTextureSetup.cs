using UnityEngine;

public class PortalTextureSetup : MonoBehaviour
{
    public Camera Camera_B;
    public Material CameraTexture_B;

    public Camera Camera_A;
    public Material CameraTexture_A;

    [HideInInspector] public int invisCount = 0;

    // Update is called once per frame
    void Start()
    {
        AssignCams();
        Camera_A.enabled = false;
        Camera_B.enabled = false;
    }

    public void AssignCams()
    {
        if (Camera_A.targetTexture != null)
        {
            Camera_A.targetTexture.Release();
        }
        Camera_A.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        CameraTexture_A.mainTexture = Camera_A.targetTexture;

        if (Camera_B.targetTexture != null)
        {
            Camera_B.targetTexture.Release();
        }
        Camera_B.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        CameraTexture_B.mainTexture = Camera_B.targetTexture;
    }

    //forget for now
    /*
    private void Update()
    {
        if (invisCount >= 2)
        {
            if (!Camera_A.enabled == false)
            {
                Camera_A.enabled = false;
                Camera_B.enabled = false;
            }
        }
        else
        {
            if (!Camera_A.enabled == true)
            {
                Camera_A.enabled = true;
                Camera_B.enabled = true;
            }
        }

        Debug.Log(invisCount);
    }
    */
}
