using System;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    [SerializeField] private BoxCollider _platformCollider;
    [SerializeField] private Animator _platformAnimator;
    [SerializeField] private bool _startingToggle;

    private bool _currentToggleState;
    private void Start()
    {
        SubscribeToEvents();
        _currentToggleState = _startingToggle;
        ToggleVine(_currentToggleState);
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
        ToggleVine(_currentToggleState);
    }

    private void ToggleVine(bool toggleValue)
    {
        ToggleCollider(toggleValue);
        _platformAnimator.SetBool("ExpandVines", toggleValue);
    }

    private void ToggleCollider(bool toggle) => _platformCollider.enabled = toggle;
}
