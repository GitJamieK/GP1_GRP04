using UnityEngine;
using Jesper.GeneralStateMachine;
public class GamePausedState : ManagerStates
{
    private GameManager _gameManager;

    public GamePausedState(GameManager manager, string anim, string audio) : base(manager, anim, audio)
    {
        _gameManager = manager;
    }

    public override void OnEnter()
    {
        base.OnEnter();
        _gameManager.Player?.Pause();
    }

    public override void OnExit()
    {
        base.OnExit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
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
