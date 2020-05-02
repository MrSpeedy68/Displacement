using UnityEngine;

public class SkullDoorOpen : MonoBehaviour
{
    //script by Sean Duggan & Adrian Hebel
    public GameObject CellDoor;
    public GameObject SkullObj;
    public GameObject SkullLocation;
    public BoxCollider boxCol;
    private int smooth = 1;

    private void Start()
    {
        SkullObj = GameObject.FindGameObjectWithTag("Skull");
        boxCol.enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Skull")
        {
            Vector3 E = SkullLocation.transform.position;
            SkullObj.transform.position = Vector3.MoveTowards(SkullObj.transform.position, E, Time.deltaTime * smooth);
            boxCol.enabled = false;
            PlaceSkull(SkullObj);
            OpenCell();
        }
    }

    /*
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Skull")
        {
            OpenCell();
        }
    }
    */

    void PlaceSkull(GameObject SkullObj)
    {
        //ThrowObject tO = SkullObj.GetComponent<ThrowObject>();
        Transform tF = SkullObj.GetComponent<Transform>();
        Rigidbody rB = SkullObj.GetComponent<Rigidbody>();
        //tO.UnGrab();
        //tO.canBePickedUp = false;
        tF.rotation = SkullLocation.transform.rotation;
        tF.position = SkullLocation.transform.position;
        rB.velocity = Vector3.zero;
        rB.useGravity = false;
    }

    void OpenCell()
    {
        Animator cellOpen = CellDoor.GetComponent<Animator>();
        cellOpen.SetTrigger("OpenCloseCell");
    }
}
