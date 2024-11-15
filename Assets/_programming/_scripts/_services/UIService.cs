using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIService : MonoBehaviour
{
    [SerializeField] private Text _scoreText;
    [SerializeField] private Animator _screenTransitionAnimator;
    [SerializeField] private LevelLoader _levelLoader;

    private void Start()
    {
        SubscribeToEvents();
        _screenTransitionAnimator.SetTrigger("EnterTransition");
    }

    private void OnDestroy()
    {
        UnsubscribeFromEvents();
    }

    private void SubscribeToEvents()
    {
        GameManager.Instance.EventService.OnPlayerStartedOpeningDoor += OnPlayerStartedOpeningDoor;
    }

    private void UnsubscribeFromEvents()
    {
        GameManager.Instance.EventService.OnPlayerStartedOpeningDoor -= OnPlayerStartedOpeningDoor;
    }

    private void OnPlayerStartedOpeningDoor()
    {
        _screenTransitionAnimator.SetTrigger("ExitTransition");
    }

    private void OnSceneTransitionFinished()
    {
        GameManager.Instance.EventService.InvokeInitiateNextSceneLoadEvent();
    }

    public void UpdateSeedsCollected(int seeds) => _scoreText.text = seeds.ToString();
}
