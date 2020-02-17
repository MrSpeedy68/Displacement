using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverOpenDoor : MonoBehaviour
{
    private Transform player;
    Animator leverAnim;
    float distanceThresholdFloat = 1f;
    bool hasPlayer = false;
    bool LeverIsOn = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        leverAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //LeverIsOn = leverAnim.GetBool("LeverActivate");
        InteractWithLever();
    }


    void InteractWithLever()
    {
        float distanceBetweenPlayerAndLever = Vector3.Distance(transform.position, player.position);
        if (distanceBetweenPlayerAndLever <= distanceThresholdFloat)
        {
            if(distanceBetweenPlayerAndLever <= 3f)
            {
                hasPlayer = true;
            }
            else
            {
                hasPlayer = false;
            }

            if (hasPlayer && Input.GetButtonDown("Use") && !LeverIsOn)
            {
                leverAnim.SetBool("LeverActivate", true);
                //LeverIsOn = true;
                //leverAnim.enabled = false;
                Debug.Log("poopy");
                Debug.Log(LeverIsOn);
            }
            
            if (hasPlayer && Input.GetButtonDown("Use") && LeverIsOn)
            {
                leverAnim.enabled = true;
                leverAnim.SetBool("LeverActivate", false);
                Debug.Log("Stinky");
            }
        }

        void PauseLeverAnimation()
        {
            leverAnim.enabled = false;
        }
    }


}
