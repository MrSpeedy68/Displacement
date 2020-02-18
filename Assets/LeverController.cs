using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverController : MonoBehaviour
{

    private void OnTriggerStay(Collider other)
    {
        GameObject Door = GameObject.Find("SD_Env_Door_02");
        Animator doorAnim = Door.GetComponent<Animator>();
        Animator leverAnim = GetComponent<Animator>();
        if (Input.GetButtonDown("Use"))
        {
            leverAnim.SetTrigger("UseLever");
            doorAnim.SetTrigger("OpenClose");
        }
    }
}
