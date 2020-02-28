using UnityEngine;

public class PortalOptimiser : MonoBehaviour
{

    PortalTextureSetup pts;

    private void Start()
    {
        pts = GameObject.FindGameObjectWithTag("PTS").GetComponent<PortalTextureSetup>();
    }

    private void OnBecameInvisible()
    {
        //pts.invisCount--;
    }

    private void OnBecameVisible()
    {
        //pts.invisCount++;
    }
}
