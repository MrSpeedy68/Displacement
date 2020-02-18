using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverOpenDoor : MonoBehaviour
{
    private Transform player;
    Animator leverAnim;
    float distanceThresholdFloat = 1f;
    bool hasPlayer = false;
    //bool LeverIsOn = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        leverAnim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        InteractWithLever();

    }


    void InteractWithLever()
    {
        float distanceBetweenPlayerAndLever = Vector3.Distance(transform.position, player.position);
        if (distanceBetweenPlayerAndLever <= distanceThresholdFloat)
        {
            if (distanceBetweenPlayerAndLever <= 3f)
            {
                hasPlayer = true;
            }
            else
            {
                hasPlayer = false;
            }

            if (hasPlayer && Input.GetButtonDown("Use"))
            {
                leverAnim.SetTrigger("Lever move");
                Debug.Log("poopy");
               
            }
        }
    }
    /*
    IEnumerator leverDown()
    {
        leverAnim.SetTrigger("Lever move");
        yield return new WaitForSeconds(5.0f);
        LeverIsOn = true;
        Debug.Log("poopy");
        Debug.Log(LeverIsOn);
    }

    IEnumerator leverUp()
    {
        leverAnim.enabled = true;
        yield return new WaitForSeconds(5.0f);
        LeverIsOn = false;
        Debug.Log("Stinky");
        Debug.Log(LeverIsOn);
    }
    */


    void PauseLeverAnimation()
        {
            leverAnim.enabled = false;
        }
    


}
