using UnityEngine;

//Help from: https://github.com/jiankaiwang/FirstPersonController
public class FPSCameraLook : MonoBehaviour
{

    public float lookSpeed = 5f;
    public float camSmoothing = 1f; //must be minimum 1f as it multiplies lookspeed
    private GameObject player;
    private Vector2 mouseLook;
    private Vector2 smoothVe;

    // Start is called before the first frame update
    void Start()
    {
        player = this.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 delta = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        delta = Vector2.Scale(delta, new Vector2(lookSpeed * camSmoothing, lookSpeed * camSmoothing));
        smoothVe.x = Mathf.Lerp(smoothVe.x, delta.x, 1f / camSmoothing);
        smoothVe.y = Mathf.Lerp(smoothVe.y, delta.y, 1f / camSmoothing);
        mouseLook += smoothVe;
        transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        player.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, player.transform.up);
    }
}
