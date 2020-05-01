using UnityEngine;

//script by sean duggan
public class DoorController : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        Animator anim = GetComponent<Animator>();
        if (Input.GetButtonDown("Use"))
        {
            anim.SetTrigger("OpenClose");
        }
    }
}
