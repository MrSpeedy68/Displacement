using UnityEngine;

public class PortalShooter : MonoBehaviour
{
    //script by sean duggan
    //partially unused? im afraid to touch it
    //like one is afraid to breathe near a house of cards
    //it's an early and important script so hehehe no thanks
    public GameObject portalBall;
    private Transform playerCam;
    private Vector3 camAdjust;
    public float distFromCam = 2f;

    private void Start()
    {
        playerCam = Camera.main.transform;
    }

    private void Update()
    {
        if (playerCam.childCount <= 1) //1 because of new outline camera
        {
            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(portalBall, transform.position + transform.forward * 1.25f, Quaternion.identity);
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("More than 1 parented object to player camera");
            }
        }
    }

}
