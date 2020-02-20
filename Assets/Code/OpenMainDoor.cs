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
    public GameObject Candle;
    private int smooth = 1;

    /*
        private void OnTriggerStay(Collider other)
        {
        }
        */

    private void LateUpdate()
    {
        float distGem1 = Vector3.Distance(Candle.transform.position, Gem1.transform.position);
        float distGem2 = Vector3.Distance(Candle.transform.position, Gem2.transform.position);
        float distGem3 = Vector3.Distance(Candle.transform.position, Gem3.transform.position);



        if (distGem1 <= 5f && distGem2 <= 5f && distGem3 <= 5f)
        {
            OpenDoors();
        }
        if (distGem1 <= 5f)
        {
            Gem1.transform.position = Vector3.MoveTowards(Gem1.transform.position, new Vector3(52.511f, -7.5f, 91.243f), Time.deltaTime * smooth);
            Gem1.GetComponent<ThrowObject>().enabled = false;
        }
        if (distGem2 <= 5f)
        {
            Gem2.transform.position = Vector3.MoveTowards(Gem2.transform.position, new Vector3(51.646f, -7.5f, 93.406f), Time.deltaTime * smooth);
            Gem2.GetComponent<ThrowObject>().enabled = false;
        }
        if (distGem3 <= 5f)
        {
            Gem3.transform.position = Vector3.MoveTowards(Gem3.transform.position, new Vector3(53.373f, -7.5f, 93.391f), Time.deltaTime * smooth);
            Gem3.GetComponent<ThrowObject>().enabled = false;
        }
    }

    
    void OpenDoors ()
    {
        Animator rightDoorAnim = RightDoor.GetComponent<Animator>();
        Animator leftDoorAnim = LeftDoor.GetComponent<Animator>();

            rightDoorAnim.SetTrigger("OpenRight");
            leftDoorAnim.SetTrigger("OpenLeft"); 
    }
}
