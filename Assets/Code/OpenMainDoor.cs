using UnityEngine;

public class OpenMainDoor : MonoBehaviour
{
    public GameObject RightDoor;
    public GameObject LeftDoor;
    public GameObject Gem1;
    public GameObject Gem2;
    public GameObject Gem3;
    public GameObject Candle;
    public bool flip = false;
    private int smooth = 1;

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
            PlaceGem(Gem1);
        }
        if (distGem2 <= 5f)
        {
            Gem2.transform.position = Vector3.MoveTowards(Gem2.transform.position, new Vector3(51.646f, -7.5f, 93.406f), Time.deltaTime * smooth);
            PlaceGem(Gem2);
        }
        if (distGem3 <= 5f)
        {
            Gem3.transform.position = Vector3.MoveTowards(Gem3.transform.position, new Vector3(53.373f, -7.5f, 93.391f), Time.deltaTime * smooth);
            PlaceGem(Gem3);
        }
    }
    

    void PlaceGem(GameObject gem)
    {
        gem.GetComponent<ThrowObject>().UnGrab();
        gem.GetComponent<ThrowObject>().canBePickedUp = false;
        gem.GetComponent<Rigidbody>().useGravity = false;
    }


    void OpenDoors()
    {
        Animator rightDoorAnim = RightDoor.GetComponent<Animator>();
        Animator leftDoorAnim = LeftDoor.GetComponent<Animator>();

        rightDoorAnim.SetTrigger("OpenRight");
        leftDoorAnim.SetTrigger("OpenLeft");
        flip = true;
    }
}
