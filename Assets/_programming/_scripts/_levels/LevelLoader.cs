using System;
using jamie;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    private int firstSceneBuildIndex = 0;
    private int numberOfScenes;

    private void Awake()
    {
        numberOfScenes = SceneManager.sceneCountInBuildSettings;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerController player))
        {
            if (SceneManager.GetActiveScene().buildIndex == numberOfScenes - 1)
                SceneManager.LoadScene(firstSceneBuildIndex);
            else
                LoadNextScene();
        }
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
