using Jesper.GeneralStateMachine;
using UnityEngine;

public class GamePlayingState : ManagerStates {
    private GameManager _gameManager;

    public GamePlayingState(GameManager m, string anim, string audio) : base(m, anim, audio)
    {
        _gameManager = m;
    }

    public override void OnEnter()
    {
        base.OnEnter();
        _gameManager.Player.Resume();

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
