using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    //unused script
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
    public AudioClip[] footSteps;
    private AudioSource aS;
    public float timeBetweenFootsteps = 0.6f;
    private float timer;
    private bool isWalking;

    private Vector3 lastUpdatePos = Vector3.zero;
    private Vector3 dist;
    private float currentSpeed;

    void Start()
    {
        aS = GetComponent<AudioSource>();
        resetPos = new GameObject("ResetPosObject").transform;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
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
            timeBetweenFootsteps = 0.3f;
        }
        else
        {
            speed = startSpeedStore;
            timeBetweenFootsteps = 0.6f;
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

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        dist = transform.position - lastUpdatePos;
        currentSpeed = dist.magnitude / Time.deltaTime;
        lastUpdatePos = transform.position;

        if (isGrounded && currentSpeed > 0.1f)
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                aS.pitch = Random.Range(0.9f, 1.1f);
                aS.PlayOneShot(footSteps[Random.Range(0, footSteps.Length)], aS.volume);
                timer = timeBetweenFootsteps;
            }
        }
    }
}
