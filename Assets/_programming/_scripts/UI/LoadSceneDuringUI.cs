using System;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class LoadSceneDuringUI : MonoBehaviour
{
    private Input input;
    
    [SerializeField] private int sceneBuildIndex = 0;
    private void Update()
    {
        if (Keyboard.current.anyKey.wasPressedThisFrame || 
            Mouse.current.leftButton.wasPressedThisFrame ||
            Gamepad.current != null && Gamepad.current.allControls.Any(control => control.IsPressed()))
        {
            LoadScene();
        }
    }
    
    private void LoadScene()
    {
        if (sceneBuildIndex >= 0 && sceneBuildIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(sceneBuildIndex);
        }
        else
        {
            Debug.LogWarning("Invalid scene build index. Please set a valid index in the Inspector.");
        }
    }
}