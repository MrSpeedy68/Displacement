using cakeslice;
using UnityEngine;

public class LeverHighlight : MonoBehaviour
{
    //script by sean duggan
    public Outline outl;
    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        float dist = Vector3.Distance(player.transform.position, transform.position);

        if (dist < 5f)
        {
            outl.enabled = true;
        }
        else
        {
            outl.enabled = false;
        }
    }
}
