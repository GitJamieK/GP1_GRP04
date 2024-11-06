using System;
using UnityEngine;
using UnityEngine.UI;

public class UIService : MonoBehaviour {
    [Header("Event References")] 
    public EventService EventService;
    
    [Header("Input Reference")] 
    // public Input Input;
    
    [Header("UI Elements")]
    [SerializeField] private Text _collectibleText;

    private void Awake() {
        Init();
    }
    
    private void Init() {
        EventService = new EventService();
        SubscribeToEvents();
    }

    

    private void OnDestroy() {
        UnsubscribeFromEvents();
    }

    private void SubscribeToEvents() {
        //EventService.OnCollectibleCollectedTextUpdate += OnCollectibleCollectedTextUpdate;
    }

    private void UnsubscribeFromEvents() {
        //EventService.OnCollectibleCollectedTextUpdate -= OnCollectibleCollectedTextUpdate;

    }

    private void Update() {
        
    }
    void OnCollectibleCollectedTextUpdate(string text) {
            _collectibleText.text = text;
    }
}
