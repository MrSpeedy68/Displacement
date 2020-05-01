using UnityEngine;

public class DeleteOnLMB : MonoBehaviour
{
    //script by sean duggan
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Destroy(gameObject);
        }
    }
}
