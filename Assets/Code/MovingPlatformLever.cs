using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformLever : MonoBehaviour
{
    public GameObject Platform;

    private void OnTriggerStay(Collider other)
    {
        Animator doorAnim = Platform.GetComponent<Animator>();
        Animator leverAnim = GetComponent<Animator>();
        if (Input.GetButtonDown("Use"))
        {
            leverAnim.SetTrigger("UseLever");
            doorAnim.SetTrigger("Move");
        }
    }
}
