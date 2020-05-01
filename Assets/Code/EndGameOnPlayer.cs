using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameOnPlayer : MonoBehaviour
{
    //script by sean duggan
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
