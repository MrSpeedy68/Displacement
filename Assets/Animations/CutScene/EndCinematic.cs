using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndCinematic : MonoBehaviour
{
    public GameObject playerCam;
    public GameObject cam2;
    public GameObject Boat;
    public GameObject Rouge;
    public GameObject Wizard;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(Cinematic());
    }

    IEnumerator Cinematic()
    {
        Animator BoatAnim = Boat.GetComponent<Animator>();
        Animator RougeAnim = Rouge.GetComponent<Animator>();
        Animator WizardAnim = Wizard.GetComponent<Animator>();
        RougeAnim.enabled = false;
        Wizard.SetActive(true);
        playerCam.SetActive(false);
        cam2.SetActive(true);
        BoatAnim.SetTrigger("Sail");
        
        yield return new WaitForSeconds(1);
        WizardAnim.enabled = false;
        yield return new WaitForSeconds(35);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
