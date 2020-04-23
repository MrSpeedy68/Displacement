using UnityEngine;

//https://www.youtube.com/watch?time_continue=299&v=runW-mf1UH0&feature=emb_logo

public class PickupObject : MonoBehaviour
{
    GameObject mainCamera;
    public bool carrying;
    public bool touchingSomething;
    GameObject carriedObject;
    public float distance;
    public float smooth;

    // Use this for initialization
    void Start()
    {
        mainCamera = GameObject.FindWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        if (carrying)
        {
            carry(carriedObject);
            checkDrop();
            //rotateObject();
        }
        else
        {
            pickup();
        }
    }

    void rotateObject()
    {
        carriedObject.transform.Rotate(5, 10, 15);
    }

    void carry(GameObject o)
    {
        CheckCollisions();
        o.transform.position = Vector3.Lerp(o.transform.position, mainCamera.transform.position + mainCamera.transform.forward * distance, Time.deltaTime * smooth);
        SmoothLook(-mainCamera.transform.forward);
    }

    void pickup()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            int x = Screen.width / 2;
            int y = Screen.height / 2;

            Ray ray = mainCamera.GetComponent<Camera>().ScreenPointToRay(new Vector3(x, y));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Pickupable p = hit.collider.GetComponent<Pickupable>();
                if (p != null)
                {
                    carrying = true;
                    carriedObject = p.gameObject;
                    //p.gameObject.transform.SetParent(mainCamera.transform);
                    //p.gameObject.rigidbody.isKinematic = true;
                    p.gameObject.GetComponent<Rigidbody>().useGravity = false;
                }
            }
        }
    }
    
    void CheckCollisions()
    {
        if (carriedObject.GetComponent<Pickupable>().isColliding)
        {
            carriedObject.transform.SetParent(null);

        }
        else
        {
            carriedObject.transform.SetParent(mainCamera.transform);
            carriedObject.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f);
            carriedObject.GetComponent<Rigidbody>().angularVelocity = new Vector3(0f, 0f);
        }
    }

    void SmoothLook(Vector3 target)
    {
        carriedObject.transform.rotation = Quaternion.Lerp(carriedObject.transform.rotation, Quaternion.LookRotation(target), Time.deltaTime * smooth);
    }

    void checkDrop()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            dropObject();
        }
    }

    void dropObject()
    {
        carrying = false;
        //carriedObject.gameObject.rigidbody.isKinematic = false;
        carriedObject.transform.SetParent(null);
        carriedObject.gameObject.GetComponent<Rigidbody>().useGravity = true;
        carriedObject = null;
    }
}
