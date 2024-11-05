﻿using UnityEngine;

namespace Jesper.PlayerStateMachine {
    public class PlayerIdleState : PlayerStates{
        public PlayerIdleState(NewPlayerController p, string anim, string audio) : base(p, anim, audio) { }

        public override void OnEnter() {
            base.OnEnter();
            Debug.Log("Player are Idle");
            NewPlayer.SwitchState(NewPlayer.RunState);
        }

        public override void OnExit() {
            base.OnExit();
        }

        public override void LogicUpdate() {
            base.LogicUpdate();
        }

        public override void PhysicsUpdate() {
            base.PhysicsUpdate();
        }

        public override void AnimationEnterTrigger() {
            base.AnimationEnterTrigger();
        }

        public override void AnimationFinishedTrigger() {
            base.AnimationFinishedTrigger();
        }

        public override void AudioTrigger() {
            base.AudioTrigger();
        }
    }
}