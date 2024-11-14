using Jesper.GeneralStateMachine;
using UnityEngine;

public class GameSuspendedState : ManagerStates
{
    private GameManager _gameManager;
    public GameSuspendedState(GameManager manager, string anim, string audio) : base(manager, anim, audio)
    {
        _gameManager = manager;
    }

    public override void OnEnter()
    {
        _gameManager.Player = null;
        _gameManager.UIService = null;
    }
}