using UnityEngine;

public class PortalTeleporter : MonoBehaviour
{
    private Transform player;
    private CharacterController playerController;
    public Transform reciever;
    private Transform collidingItem;

    private bool playerIsOverlapping = false;
    private bool ItemIsOverlapping = false;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //dotProduct is the Cos angle between the portal and player
        if (playerIsOverlapping)
        {
            Vector3 portalToPlayer = player.position - transform.position;
            float dotProduct = Vector3.Dot(transform.up, portalToPlayer);

            //If this is true it means the player has moved through the portal
            if (dotProduct < 0f)
            {
                playerController.enabled = false;
                //Teleport player and rotate him 180 to walk out the other side
                float rotationDiff = -Quaternion.Angle(transform.rotation, reciever.rotation);
                rotationDiff += 180;
                player.Rotate(Vector3.up, rotationDiff);

                Vector3 positionOffset = Quaternion.Euler(0f, rotationDiff, 0f) * portalToPlayer;
                player.position = reciever.position + positionOffset;

                playerController.enabled = true;
                playerIsOverlapping = false;
            }
        }

        //Teleporting objects that are not the player
        if (ItemIsOverlapping)
        {
            Vector3 portalToObject = collidingItem.position - transform.position;
            float dotProduct = Vector3.Dot(transform.up, portalToObject);

            if (dotProduct < 0f)
            {
                collidingItem.position = reciever.position;
                ItemIsOverlapping = false;
            }
        }
    }

    //Is the player colliding with the portal
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerIsOverlapping = true;
        }

        if (other.tag == "Item" || other.tag == "Skull")
        {
            ItemIsOverlapping = true;
            collidingItem = other.transform;
        }
    }

    //Check that the player has left the portal
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerIsOverlapping = false;
        }

        if (other.tag == "Item" || other.tag == "Skull")
        {
            ItemIsOverlapping = false;
        }
    }
}
