using UnityEngine;

public class ResetPosUponKillzone : MonoBehaviour
{
    private Transform resetPos;

    private void Start()
    {
        resetPos = new GameObject("ResetPos").transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Killzone")
        {
            transform.position = resetPos.position;
            transform.rotation = resetPos.rotation;
        }
    }
}
