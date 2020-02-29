using UnityEngine;

public class EnablePortalShoot : MonoBehaviour
{
    private PortalShooter sht;

    private void Start()
    {
        Camera.main.GetComponent<PortalShooter>().enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Camera.main.GetComponent<PortalShooter>().enabled = true;
        }
    }
}
