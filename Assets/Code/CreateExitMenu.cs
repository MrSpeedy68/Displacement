using UnityEngine;

public class CreateExitMenu : MonoBehaviour
{
    public GameObject exitMenu;
    public bool menuExists = false;

    //script by sean duggan
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !menuExists)
        {
            Instantiate(exitMenu, Vector3.zero, Quaternion.identity);
            menuExists = true;
        }

        if (Input.GetMouseButtonDown(0))
        {
            menuExists = false;
        }
    }
}
