using UnityEngine;

public class LeverController : MonoBehaviour
{
    //script by sean duggan & adrian hebel
    private bool wasUsed = false;
    public GameObject DoorToOpen;
    private AudioSource aS;
    public bool canUse = false;
    Animator doorAnim;
    Animator leverAnim;
    public Transform playerTransform;

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        aS = GetComponent<AudioSource>();
        doorAnim = DoorToOpen.GetComponent<Animator>();
        leverAnim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, playerTransform.position) < 5f)
        {

            if (Input.GetButtonDown("Use"))
            {
                if (!wasUsed)
                {
                    leverAnim.SetTrigger("UseLever");
                    doorAnim.SetTrigger("OpenClose");
                    aS.PlayOneShot(aS.clip, aS.volume);
                    wasUsed = true;
                }
            }
        }
    }
}
