using UnityEngine;

public class LeverController : MonoBehaviour
{
    private bool wasUsed = false;
    public GameObject DoorToOpen;
    private AudioSource aS;

    private void Start()
    {
        aS = GetComponent<AudioSource>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
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
}
