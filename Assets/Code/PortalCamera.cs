using UnityEngine;

public class PortalCamera : MonoBehaviour
{
    public Transform playerCamera;
    public Transform portal;
    public Transform Otherportal;

    
    private void Start()
    {
        playerCamera = Camera.main.transform;
    }
    

    // Update is called once per frame
    void Update()
    {
        //CameraB moving with player camera
        Vector3 playerOffsetFromPortal = playerCamera.position - Otherportal.position;
        transform.position = portal.position + playerOffsetFromPortal;

        //CameraB handling rotation to the player camera
        float angularDifferenceBetweenPortalRotations = Quaternion.Angle(portal.rotation, Otherportal.rotation);

        Quaternion portalRotationalDifference = Quaternion.AngleAxis(angularDifferenceBetweenPortalRotations - 180, Vector3.up);
        Vector3 newCameraDirection = portalRotationalDifference * playerCamera.forward;
        transform.rotation = Quaternion.LookRotation(newCameraDirection, Vector3.up);
    }
}
