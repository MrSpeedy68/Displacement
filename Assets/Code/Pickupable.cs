using UnityEngine;

public class Pickupable : MonoBehaviour
{
    //Script by Sean Duggan
    public bool isColliding;

    void OnCollisionEnter(Collision other)
    {
        isColliding = true;
    }

    void OnCollisionExit(Collision other)
    {
        isColliding = false;
    }
}
