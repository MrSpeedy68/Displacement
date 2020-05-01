using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //https://www.youtube.com/watch?v=_QajrabyTJc
    //adapted by Sean Duggan

    public float mvSpeed = 5f;
    public float sprintSpeed = 7f;
    private Rigidbody rb;
    private float forward;
    private float strafe;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float tempSpeed;
        if (Input.GetButton("Sprint"))
        {
            tempSpeed = sprintSpeed;
        }
        else
        {
            tempSpeed = mvSpeed;
        }
        forward = Input.GetAxis("Vertical") * tempSpeed * Time.deltaTime;
        strafe = Input.GetAxis("Horizontal") * tempSpeed * Time.deltaTime;
        transform.Translate(strafe, 0f, forward);

        Debug.Log(tempSpeed);
        //Dev debug unlock mouse
        if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
