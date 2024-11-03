using UnityEngine;

public class GamePlayingState : State
{
    private GameManager _gameManager;

    public GamePlayingState(GameManager gameManager)
    {
        _gameManager = gameManager;
    }

    public override void EnterState()
    {
        _gameManager.Player.Resume();
    }
}
