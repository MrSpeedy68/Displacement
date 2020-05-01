using UnityEngine;

public class vsyncEnforcer : MonoBehaviour
{
    //script by Sean Duggan (very proud of this one)
    void Start()
    {
        QualitySettings.vSyncCount = 1;
    }
}
