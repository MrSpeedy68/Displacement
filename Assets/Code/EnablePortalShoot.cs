using UnityEngine;

public class EnablePortalShoot : MonoBehaviour
{
    private PortalShooter sht;
    public GameObject textPrompt;

    private void Start()
    {
        Camera.main.GetComponent<PortalShooter>().enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Camera.main.GetComponent<PortalShooter>().enabled = true;
            Instantiate(textPrompt, Vector3.zero, Quaternion.identity);
        }
    }
}
