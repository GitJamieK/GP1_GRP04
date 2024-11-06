using System;
using UnityEngine;
using UnityEngine.UI;

public class UIService : MonoBehaviour {
    
    [Header("Input Reference")] 
    // public Input Input;
    
    [Header("UI Elements")]
    [SerializeField] private Text _collectibleText;

    private void Start() {
        Init();
    }
    
    private void Init() {
        SubscribeToEvents();
    }

    

    private void OnDestroy() {
        UnsubscribeFromEvents();
    }

    private void SubscribeToEvents() { 
        GameManager.Instance.EventService.OnCollectibleCollectedTextUpdate += UpdateUiText;
    }

    private void UnsubscribeFromEvents() {
        GameManager.Instance.EventService.OnCollectibleCollectedTextUpdate -= UpdateUiText;
    }

    private void Update() {
        
    }
    
    void UpdateUiText(string text) {
        _collectibleText.text = text;
    }
}
