using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSkipScript : MonoBehaviour
{

    //script by Sean Duggan
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
