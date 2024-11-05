using System;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    [SerializeField] private BoxCollider _platformCollider;
    [SerializeField] private MeshRenderer _meshRenderer;
    [SerializeField] private bool _startingToggle;

    private bool _currentToggleState;
    private void Start()
    {
        SubscribeToEvents();
        ToggleRenderer(_startingToggle);
        ToggleCollider(_startingToggle);
        _currentToggleState = _startingToggle;
    }

    private void OnDestroy()
    {
        UnsubscribeFromEvents();
    }

    private void SubscribeToEvents()
    {
        GameManager.Instance.EventService.OnPlayerToggledPlatformTrigger += TogglePlatform;
    }

    private void UnsubscribeFromEvents()
    {
        GameManager.Instance.EventService.OnPlayerToggledPlatformTrigger -= TogglePlatform;
    }

    private void TogglePlatform()
    {
        _currentToggleState = !_currentToggleState;
        ToggleRenderer(_currentToggleState);
        ToggleCollider(_currentToggleState);
    }
    
    private void ToggleRenderer(bool toggle) => _meshRenderer.enabled = toggle;
    private void ToggleCollider(bool toggle) => _platformCollider.enabled = toggle;
}
