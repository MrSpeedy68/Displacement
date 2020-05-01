using cakeslice;
using UnityEngine;

public class MovingPlatformLever : MonoBehaviour
{
    //script by sean duggan
    public GameObject Platform;
    public Transform player;
    private bool wasUsed = false;
    private AudioSource aS;
    public Outline outl;
    private Transform playerTransform;

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        aS = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, playerTransform.position) < 5f)
        {

        }
        float dist = Vector3.Distance(playerTransform.position, transform.position);
    }

    private void OnTriggerStay(Collider other)
    {
        Animator doorAnim = Platform.GetComponent<Animator>();
        Animator leverAnim = GetComponent<Animator>();
        if (Input.GetButtonDown("Use"))
        {
            if (!wasUsed)
            {
                aS.PlayOneShot(aS.clip, aS.volume);
                leverAnim.SetTrigger("UseLever");
                doorAnim.SetTrigger("Move");
                wasUsed = true;
            }
        }
    }
}
