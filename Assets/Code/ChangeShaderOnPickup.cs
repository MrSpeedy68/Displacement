using UnityEngine;

public class ChangeShaderOnPickup : MonoBehaviour
{

    private PickupObject objectScript;
    private MeshRenderer mR;
    private Shader regular;
    private Shader onTop;

    bool isOnTop;

    void Start()
    {
        //player should have object script always
        objectScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PickupObject>();
        regular = Shader.Find("Standard");
        onTop = Shader.Find("Custom/alwaysOnTop");
        mR = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        if (Vector3.Distance(objectScript.gameObject.transform.position, transform.position) < 15f)
        {
            if (objectScript.carrying)
            {
                if (!isOnTop)
                {
                    mR.material.shader = onTop;
                }
                isOnTop = true;
            }
            else
            {
                if (isOnTop)
                {
                    mR.material.shader = regular;
                }
                isOnTop = false;
            }
        }
    }
}
