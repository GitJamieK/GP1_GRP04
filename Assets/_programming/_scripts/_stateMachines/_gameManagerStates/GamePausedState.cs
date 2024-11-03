using UnityEngine;

public class GamePausedState : State
{
    private GameManager _gameManager;

    public GamePausedState(GameManager gameManager)
    {
        _gameManager = gameManager;
    }

    public override void EnterState()
    {
        _gameManager.Player.Pause();
    }
}
