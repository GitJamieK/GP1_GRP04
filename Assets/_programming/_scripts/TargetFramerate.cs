using System;
using UnityEngine;

public class TargetFramerate : MonoBehaviour {
    private float frameRate;
    void Start()
    {
        // Limit framerate to cinematic 24fps.
        QualitySettings.vSyncCount = 0; // Set vSyncCount to 0 so that using .targetFrameRate is enabled.
        Application.targetFrameRate = 180;
    }

    private void Update() {
        Debug.Log("FPS - " + Application.targetFrameRate);
    }
}
