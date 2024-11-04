using System;
using System.Buffers.Text;
using UnityEngine;
using System.Collections;

namespace Jesper.PlayerStateMachine {
    public class PlayerRunState : PlayerStates {
        public PlayerRunState(NewPlayerController p, string anim, string audio) : base (p, anim, audio) { }

        public override void OnEnter() {
            base.OnEnter();
            Debug.Log("Player are Running");
        }

        public override void OnExit() {
            base.OnExit();
        }

        public override void LogicUpdate() {
            base.LogicUpdate();

            if (NewPlayer.MovementLocked)
                return;
            
            if(UnityEngine.Input.GetKeyDown(KeyCode.Space))
                NewPlayer.SwitchState(NewPlayer.JumpState);
            
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
            NewPlayer.transform.position += NewPlayer.CurrentMoveSpeed * Time.deltaTime * NewPlayer.transform.forward;
        }
        private void UpdateRotation()
        {
            NewPlayer.transform.forward = NewPlayer.MovementDirection > 0f ? NewPlayer.CurrentPositiveAxis : NewPlayer.CurrentNegativeAxis;
        }
    }
}