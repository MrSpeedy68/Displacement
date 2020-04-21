using UnityEngine;

public class LeverController : MonoBehaviour
{
    private bool wasUsed = false;
    public GameObject DoorToOpen;
    private AudioSource aS;
    public bool canUse = false;

    private void Start()
    {
        aS = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        canUse = true;
        if (other.tag == "Player" && canUse)
        {
            Animator doorAnim = DoorToOpen.GetComponent<Animator>();
            Animator leverAnim = GetComponent<Animator>();
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

    private void OnTriggerExit(Collider other)
    {
        canUse = false;
    }
}
