using System.Collections;
using UnityEngine;

public class PortalBallScript : MonoBehaviour
{
    private Transform playerCam;
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

    private void Update()
    {
        isTouchingGround = Physics.CheckSphere(transform.position, col.radius * 1.05f, lMask);
        if (isTouchingGround)
        {
            if (pm.lastPortalWasA)
            {
                portalB.transform.position = transform.position - new Vector3(0f, col.radius, 0f);
                pm.lastPortalWasA = false;
            }
            else
            {
                portalA.transform.position = transform.position - new Vector3(0f, col.radius, 0f);
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
