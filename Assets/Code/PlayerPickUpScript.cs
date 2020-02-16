using UnityEngine;

public class PlayerPickUpScript : MonoBehaviour
{
    private GameObject dest;
    private Camera cam;

    private void Start()
    {
        dest = GameObject.FindGameObjectWithTag("Dest");
        cam = Camera.main;
    }

    private void Update()
    {
        Ray r = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit rh;
        if (Physics.Raycast(r, out rh))
        {
            Debug.Log(rh.transform.name);
        }
    }
}
