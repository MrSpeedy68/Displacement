using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
