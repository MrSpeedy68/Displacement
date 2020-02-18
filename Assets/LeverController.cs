using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverController : MonoBehaviour
{
    public GameObject DoorToOpen;

    private void OnTriggerStay(Collider other)
    {
        Animator doorAnim = DoorToOpen.GetComponent<Animator>();
        Animator leverAnim = GetComponent<Animator>();
        if (Input.GetButtonDown("Use"))
        {
            leverAnim.SetTrigger("UseLever");
            doorAnim.SetTrigger("OpenClose");
        }
    }
}
