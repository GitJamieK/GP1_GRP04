﻿using System;
using System.Buffers.Text;
using UnityEngine;

namespace Jesper.PlayerStateMachine {
    public class PlayerRunState : PlayerStates {
        public PlayerRunState(PlayerController p, string anim, string audio) : base (p, anim, audio) { }

        public override void OnEnter() {
            base.OnEnter();
            Debug.Log("Player are Running");
        }

        public override void OnExit() {
            base.OnExit();
        }

        public override void LogicUpdate() {
            base.LogicUpdate();
            UpdateMovement();
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
        
        private void UpdateMovement()
        {
            Player.transform.position += Player.CurrentMoveSpeed * Time.deltaTime * Player.transform.forward;
        }
    }
}