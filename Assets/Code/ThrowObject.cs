using UnityEngine;

public class ThrowObject : MonoBehaviour
{
    Transform player;
    Transform playerCam;
    private Rigidbody rb;
    public float throwForce = 700f;
    bool hasPlayer;
    bool beingCarried;
    public bool canBePickedUp = true;
    private bool touched = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerCam = Camera.main.transform;
    }

    void LateUpdate()
    {
        float dist = Vector3.Distance(gameObject.transform.position, player.position);
        if (dist <= 3f)
        {
            hasPlayer = true;
        }
        else
        {
            hasPlayer = false;
            touched = true;
        }
        if (hasPlayer && Input.GetButtonDown("Use"))
        {
            Grab();
            beingCarried = true;
        }
        if (beingCarried)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            if (touched)
            {
                UnGrab();
                rb.AddForce(playerCam.forward * 300f);
                touched = false;
            }
            if (Input.GetMouseButtonDown(0))
            {
                UnGrab();
                rb.AddForce(playerCam.forward * throwForce);
            }
            else if (Input.GetMouseButtonDown(1))
            {
                UnGrab();
            }
        }
    }

    void Grab()
    {
        rb.useGravity = false;
        rb.detectCollisions = true;
        transform.parent = playerCam;
        beingCarried = true;
    }

    public void UnGrab()
    {
        rb.useGravity = true;
        transform.parent = null;
        beingCarried = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Portal")
        {
            touched = true;
        }
    }
}
