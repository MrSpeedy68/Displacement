using UnityEngine;

public class ResetPosUponKillzone : MonoBehaviour
{
    private Transform resetPos;

    private void Start()
    {
        resetPos = new GameObject("ResetPos").transform;
        resetPos.position = transform.position;
        resetPos.rotation = transform.rotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Killzone")
        {
            if (tag == "Player") GetComponent<CharacterController>().enabled = false;
            transform.position = resetPos.position;
            transform.rotation = resetPos.rotation;
            if (tag == "Player") GetComponent<CharacterController>().enabled = true;
        }
    }
}
