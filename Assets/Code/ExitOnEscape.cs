using UnityEngine;

public class ExitOnEscape : MonoBehaviour
{
    //script by sean duggan
    private bool canExit = false;

    private void Start()
    {
        Invoke("CanExit", 0.2f);
    }

    void Update()
    {
        if (canExit && Input.GetKeyDown(KeyCode.Space))
        {
            Application.Quit();
            print("Exiting...");
        }
    }

    void CanExit()
    {
        canExit = true;
    }
}
