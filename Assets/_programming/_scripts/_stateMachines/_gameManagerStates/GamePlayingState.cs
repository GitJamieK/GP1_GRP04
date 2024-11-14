using Jesper.GeneralStateMachine;
using UnityEngine;

public class GamePlayingState : ManagerStates {
    private GameManager _gameManager;

    public GamePlayingState(GameManager manager, string anim, string audio) : base(manager, anim, audio)
    {
        _gameManager = manager;
    }

    public override void OnEnter()
    {
        base.OnEnter();
        _gameManager.Player?.Resume();
    }

    public override void OnExit()
    {
        base.OnExit();
    }

    public override void LogicUpdate()
    {
        _gameManager.Player?.UpdatePlayer();
    }

    public override void PhysicsUpdate()
    {
        _gameManager.Player?.PhysicsUpdate();
    }

    public override void AnimationEnterTrigger()
    {
        base.AnimationEnterTrigger();
    }

    public override void AnimationFinishedTrigger()
    {
        base.AnimationFinishedTrigger();
    }

    public override void AudioTrigger()
    {
        base.AudioTrigger();
    }
}
