using Jesper.GeneralStateMachine;
using UnityEngine;

public class GameRotationState : ManagerStates
{
    private GameManager _gameManager;
    public GameRotationState(GameManager manager, string anim, string audio) : base(manager, anim, audio)
    {
        _gameManager = manager;
    }

    public override void OnEnter()
    {
        _gameManager.Player.Pause();
    }
}
