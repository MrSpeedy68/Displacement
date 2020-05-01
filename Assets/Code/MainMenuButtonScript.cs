using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//script by sean duggan
public class MainMenuButtonScript : MonoBehaviour
{

    private Button b;

    public void GoToGame()
    {
        SceneManager.LoadScene(1);
    }
}
