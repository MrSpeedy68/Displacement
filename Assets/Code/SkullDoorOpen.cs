using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullDoorOpen : MonoBehaviour
{
    public GameObject CellDoor;
    public GameObject SkullObj;
    public GameObject SkullLocation;
    private int smooth = 1;

    // Update is called once per frame
    private void LateUpdate()
    {
        
    }

    private void Start()
    {
        SkullObj = GameObject.FindGameObjectWithTag("Skull");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Skull")
        {
            Vector3 E = SkullLocation.transform.position;
            SkullObj.transform.position = Vector3.MoveTowards(SkullObj.transform.position,E, Time.deltaTime * smooth);
            PlaceSkull(SkullObj);
            OpenCell();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Skull")
        {
            OpenCell();
        }
    }

    void PlaceSkull(GameObject SkullObj)
    {
        SkullObj.GetComponent<ThrowObject>().UnGrab();
        SkullObj.GetComponent<ThrowObject>().canBePickedUp = false;
        SkullObj.GetComponent<Rigidbody>().useGravity = false;
    }

    void OpenCell()
    {
        Animator cellOpen = CellDoor.GetComponent<Animator>();
        cellOpen.SetTrigger("OpenCloseCell");
    }
}
