using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public AudioSource perc, piano, strings, winds;
    private OpenMainDoor oMD;
    public AudioMixerSnapshot init;
    public AudioMixerSnapshot gotGem1;
    public AudioMixerSnapshot gotGem2;

    //script (agonizingly) by Sean Duggan
    private void Start()
    {
        oMD = GameObject.FindGameObjectWithTag("Altar").GetComponent<OpenMainDoor>();

        //snapshots resulted in strong track latency for some inexplicable reason... thanks Unity
        //music CANNOT be fully muted or else it unloads from memory!
        //always keep music playing at an extremely low level when not needed
        piano.PlayScheduled(AudioSettings.dspTime + 1);
        perc.PlayScheduled(AudioSettings.dspTime + 1);
        strings.PlayScheduled(AudioSettings.dspTime + 1);
        winds.PlayScheduled(AudioSettings.dspTime + 1);

        perc.timeSamples = piano.timeSamples;
        strings.timeSamples = piano.timeSamples;
        winds.timeSamples = piano.timeSamples;
    }

    private void Update()
    {
        if (oMD.gotGem1 || Input.GetKeyDown(KeyCode.J))
        {
            bool b = true;
            if (b)
            {
                gotGem1.TransitionTo(1);
                b = false;
            }
        }

        if (oMD.gotGem2 || Input.GetKeyDown(KeyCode.K))
        {
            bool b = true;
            if (b)
            {
                gotGem2.TransitionTo(1);
                b = false;
            }
        }
    }
}
