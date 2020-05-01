using UnityEngine;

public class PortalEffectScript : MonoBehaviour
{

    //script by Sean Duggan
    private AudioSource aS;
    public ParticleSystem[] portalEffect;
    public bool portalWasMoved;

    private void Start()
    {
        aS = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (portalWasMoved)
        {
            for (int i = 0; i < portalEffect.Length; i++)
            {
                portalEffect[i].Play();
                aS.PlayOneShot(aS.clip, aS.volume);
            }
            portalWasMoved = false;
        }
    }
}
