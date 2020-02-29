using cakeslice;
using UnityEngine;

public class MovingPlatformLever : MonoBehaviour
{
    public GameObject Platform;
    public Transform player;
    private bool wasUsed = false;
    private AudioSource aS;
    public Outline outl;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        aS = GetComponent<AudioSource>();
    }

    private void Update()
    {
        float dist = Vector3.Distance(player.transform.position, transform.position);

        if (dist < 5f)
        {
            outl.enabled = true;
        }
        else
        {
            outl.enabled = false;
        }
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
