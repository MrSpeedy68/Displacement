using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMainDoors : MonoBehaviour
{
    public GameObject RightMainDoor;
    public GameObject LeftMainDoor;

    public GameObject GemKey1;
    public GameObject GemKey2;
    public GameObject GemKey3;
    public GameObject Candle;
    private int smoothTime = 1;


    private void LateUpdate()
    {
        float distGem1 = Vector3.Distance(Candle.transform.position, GemKey1.transform.position);
        float distGem2 = Vector3.Distance(Candle.transform.position, GemKey2.transform.position);
        float distGem3 = Vector3.Distance(Candle.transform.position, GemKey3.transform.position);



        if (distGem1 <= 5f && distGem2 <= 5f && distGem3 <= 5f)
        {
            OpenBothDoors();
        }
        if (distGem1 <= 5f)
        {
            GemKey1.transform.position = Vector3.MoveTowards(GemKey1.transform.position, new Vector3(52.511f, -7.5f, 91.243f), Time.deltaTime * smoothTime);
            GemKey1.GetComponent<ThrowObject>().enabled = false;
        }
        if (distGem2 <= 5f)
        {
            GemKey2.transform.position = Vector3.MoveTowards(GemKey2.transform.position, new Vector3(51.646f, -7.5f, 93.406f), Time.deltaTime * smoothTime);
            GemKey2.GetComponent<ThrowObject>().enabled = false;
        }
        if (distGem3 <= 5f)
        {
            GemKey3.transform.position = Vector3.MoveTowards(GemKey3.transform.position, new Vector3(53.373f, -7.5f, 93.391f), Time.deltaTime * smoothTime);
            GemKey3.GetComponent<ThrowObject>().enabled = false;
        }
    }

    
    void OpenBothDoors ()
    {
        Animator rightDoorAnim = RightMainDoor.GetComponent<Animator>();
        Animator leftDoorAnim = LeftMainDoor.GetComponent<Animator>();

            rightDoorAnim.SetTrigger("OpenRight");
            leftDoorAnim.SetTrigger("OpenLeft"); 
    }
}
