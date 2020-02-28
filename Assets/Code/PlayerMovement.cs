using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Transform resetPos;
    public Transform groundCheck;
    public float GroundCheckRadius = 0.4f;
    public LayerMask groundCheckMask;
    bool isGrounded;
    private CharacterController controller;
    public float speed = 5f;
    public float sprint = 10f;
    Vector3 vel;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    private float startSpeedStore;
    private AudioSource audioSource;
    public AudioClip[] footStepsStone;
    public AudioClip[] footStepsWooden;
    public float timeBetweenFootsteps = 0.4f;

    void Start()
    {
        resetPos = new GameObject("ResetPosObject").transform;
        Cursor.lockState = CursorLockMode.Locked;
        controller = GetComponent<CharacterController>();
        startSpeedStore = speed;
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, GroundCheckRadius, groundCheckMask);
        if (isGrounded && vel.y < 0)
        {
            vel.y = -2f;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        if (Input.GetButton("Sprint"))
        {
            speed = sprint;
        }
        else
        {
            speed = startSpeedStore;
        }
        Vector3 move = transform.right * x + transform.forward * z;

        if (move != Vector3.zero)
        {
            controller.Move(move * speed * Time.deltaTime);
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            vel.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }
        vel.y += gravity * Time.deltaTime;

        if (vel != Vector3.zero)
        {
            controller.Move(vel * Time.deltaTime);
        }

        if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
