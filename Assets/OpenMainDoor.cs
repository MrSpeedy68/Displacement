using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMainDoor : MonoBehaviour
{
    public GameObject RightDoor;
    public GameObject LeftDoor;

    public GameObject Gem1;
    public GameObject Gem2;
    public GameObject Gem3;
    private int smooth = 5;

    /*
        private void OnTriggerStay(Collider other)
        {
        }
        */

    private void LateUpdate()
    {
        float distGem1 = Vector3.Distance(gameObject.transform.position, Gem1.transform.position);
        float distGem2 = Vector3.Distance(gameObject.transform.position, Gem2.transform.position);
        float distGem3 = Vector3.Distance(gameObject.transform.position, Gem3.transform.position);

        if (distGem1 <= 5f && distGem2 <= 5f && distGem3 <= 5f)
        {
            OpenDoors();
        }
    }

    /*
    private void OnTriggerStay(Collider other)
    {
        if()
        {
            OpenDoors();
        }
        //Gem1.transform.position = Vector3.MoveTowards(other.transform.position, new Vector3(52, -7, 91), Time.deltaTime * smooth);
    }
    */
    void OpenDoors ()
    {
        Animator rightDoorAnim = RightDoor.GetComponent<Animator>();
        Animator leftDoorAnim = LeftDoor.GetComponent<Animator>();

            rightDoorAnim.SetTrigger("OpenRight");
            leftDoorAnim.SetTrigger("OpenLeft"); 
    }
}
