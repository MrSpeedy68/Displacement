using UnityEngine;

public class LeverController : MonoBehaviour
{
    private bool wasUsed = false;
    public GameObject DoorToOpen;
    private AudioSource aS;
    public bool canUse = false;
    Animator doorAnim;
    Animator leverAnim;

    private void Start()
    {
        aS = GetComponent<AudioSource>();
        doorAnim = DoorToOpen.GetComponent<Animator>();
        leverAnim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) < 5f)
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
