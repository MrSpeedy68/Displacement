using UnityEngine;

public class Pickupable : MonoBehaviour
{

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
