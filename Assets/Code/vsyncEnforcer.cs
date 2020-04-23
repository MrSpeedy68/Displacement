using UnityEngine;

public class vsyncEnforcer : MonoBehaviour
{

    void Start()
    {
        QualitySettings.vSyncCount = 1;
    }
}
