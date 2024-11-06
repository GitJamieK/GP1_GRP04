using System;
using UnityEngine;
using UnityEngine.UI;

public class UIService : MonoBehaviour {
    
    [Header("UI Elements")]
    [SerializeField] private Text _collectibleText;


    private void Init() {
        SubscribeToEvents();
    }

    private void Start() {
        _collectibleText.text = "x0";
    }

    private void OnDestroy() {
        UnsubscribeFromEvents();
    }

    private void SubscribeToEvents() {
        
    }
    
    private void UnsubscribeFromEvents() {}

    private void Update() {
        
    }
}
