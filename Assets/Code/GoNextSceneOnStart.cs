using UnityEngine;
using UnityEngine.SceneManagement;

//script by sean duggan
public class GoNextSceneOnStart : MonoBehaviour
{

    public bool LetsGoChamp = false;

    void Update()
    {
        if (LetsGoChamp)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
