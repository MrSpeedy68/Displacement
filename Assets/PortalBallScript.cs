using System.Collections;
using UnityEngine;

public class PortalBallScript : MonoBehaviour
{
    private Transform playerCam;
    private Rigidbody rb;
    private IEnumerator corout;
    public GameObject portal;
    public float speed = 500f;

    private void Start()
    {
        playerCam = Camera.main.transform;
        rb = GetComponent<Rigidbody>();
        rb.AddForce(playerCam.forward * speed);
        corout = Kill();
        StartCoroutine(corout);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "Ground")
        {
            //Instantiate(portal, transform.position, Quaternion.identity);
            Destroy(gameObject);
            Debug.Log("Poggers!");
        }
    }

    IEnumerator Kill()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }

}
