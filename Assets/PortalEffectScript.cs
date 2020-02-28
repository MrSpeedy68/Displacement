using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalEffectScript : MonoBehaviour
{

    public ParticleSystem[] portalEffect;
    public bool portalWasMoved;
    void Update()
    {
        if (portalWasMoved)
        {
            for (int i = 0; i < portalEffect.Length; i++)
            {
                portalEffect[i].Play();
            }
            portalWasMoved = false;
        }
    }
}
