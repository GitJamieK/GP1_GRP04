using System;
using System.Buffers.Text;
using UnityEngine;
using System.Collections;

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

            if (Player.MovementLocked)
                return;
            
            if(UnityEngine.Input.GetKeyDown(KeyCode.Space))
                Player.SwitchState(Player.JumpState);
            
            UpdateMovement();
            UpdateRotation();
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
        private void UpdateRotation()
        {
            Player.transform.forward = Player.MovementDirection > 0f ? Player.CurrentPositiveAxis : Player.CurrentNegativeAxis;
        }
    }
}