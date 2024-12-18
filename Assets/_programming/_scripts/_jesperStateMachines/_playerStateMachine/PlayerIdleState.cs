﻿using UnityEngine;

namespace Jesper.PlayerStateMachine {
    public class PlayerIdleState : PlayerStates{
        public PlayerIdleState(PlayerController p, string anim, string audio) : base(p, anim, audio) { }
        public PlayerIdleState(PlayerController p, string anim) : base(p, anim) { }

        public override void OnEnter() {
            base.OnEnter();
            Player.SwitchState(Player.RunState);
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