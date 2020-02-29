using UnityEngine;

public class CreateExitMenu : MonoBehaviour
{

    public GameObject exitMenu;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Instantiate(exitMenu, Vector3.zero, Quaternion.identity);
        }
    }
}
