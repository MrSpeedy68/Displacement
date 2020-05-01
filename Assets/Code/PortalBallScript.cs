using System.Collections;
using UnityEngine;

public class PortalBallScript : MonoBehaviour
{
    //script by Sean Duggan
    private Transform playerCam;
    public AudioSource bounceSource; //assign in inspector
    private Rigidbody rb;
    private IEnumerator corout;
    private PortalMemory pm;
    public LayerMask lMask;
    private SphereCollider col;
    private bool isTouchingGround = false;
    private Transform portalA;
    private Transform portalB;
    public float speed = 500f;

    private void Start()
    {
        portalA = GameObject.FindGameObjectWithTag("PortalA").transform;
        portalB = GameObject.FindGameObjectWithTag("PortalB").transform;
        pm = GameObject.FindGameObjectWithTag("PortalMemory").GetComponent<PortalMemory>();
        col = GetComponent<SphereCollider>();
        playerCam = Camera.main.transform;
        rb = GetComponent<Rigidbody>();
        rb.AddForce(playerCam.forward * speed);
        corout = Kill();
        StartCoroutine(corout);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag != "Ground")
        {
            bounceSource.PlayOneShot(bounceSource.clip, bounceSource.volume);
        }
    }

    private void Update()
    {
        isTouchingGround = Physics.CheckSphere(transform.position, col.radius * 1.05f, lMask);
        if (isTouchingGround)
        {
            if (pm.lastPortalWasA)
            {
                portalB.GetComponent<PortalEffectScript>().portalWasMoved = true;
                portalB.transform.position = transform.position - new Vector3(0f, col.radius, 0f);
                Vector3 lookTarget = new Vector3(playerCam.position.x, portalB.position.y, playerCam.position.z);
                portalB.transform.LookAt(lookTarget);
                pm.lastPortalWasA = false;
            }
            else
            {
                portalA.GetComponent<PortalEffectScript>().portalWasMoved = true;
                portalA.transform.position = transform.position - new Vector3(0f, col.radius, 0f);
                Vector3 lookTarget = new Vector3(playerCam.position.x, portalA.position.y, playerCam.position.z);
                portalA.transform.LookAt(lookTarget);
                pm.lastPortalWasA = true;
            }
            Destroy(gameObject);
        }
    }

    IEnumerator Kill()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
}
