using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    //https://github.com/SebLague/Portals/tree/master
    public float sensitivity = 100f;
    public Transform player;
    float xRot;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;
        xRot -= mouseY;
        xRot = Mathf.Clamp(xRot, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);
        player.Rotate(Vector3.up, mouseX);
    }
}
