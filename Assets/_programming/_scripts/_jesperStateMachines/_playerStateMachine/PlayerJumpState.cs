using System.Collections;
using UnityEngine;
using System.Threading.Tasks;
namespace Jesper.PlayerStateMachine {
    public class PlayerJumpState : PlayerStates {
        
        private readonly float groundSphereCastDistance = 0.9f;
        private readonly float groundSphereCastRadius = 0.3f;
        private readonly int _waitTimeUntilAirborne = 1000;
        private readonly string groundMask = "Ground";
        private bool _playerIsAirborne;
        public PlayerJumpState(NewPlayerController p, string anim, string audio) : base(p, anim, audio) { }

        public override void OnEnter() {
            base.OnEnter();
            Debug.Log("Player are Jumping");
            NewPlayer.PlayerRigidbody.isKinematic = false;
            NewPlayer.PlayerRigidbody.useGravity = true;
            WaitUntilAirborne();
        }

        public override void OnExit() {
            base.OnExit();
            NewPlayer.PlayerRigidbody.isKinematic = true;
            NewPlayer.PlayerRigidbody.useGravity = false;
            _playerIsAirborne = false;
        }

        public override void LogicUpdate() {
            base.LogicUpdate();
        }

        public override void PhysicsUpdate() {
            NewPlayer.PlayerRigidbody.AddForce(NewPlayer.transform.up * NewPlayer.JumpForce, ForceMode.VelocityChange);
            if(IsGrounded() && _playerIsAirborne)
                NewPlayer.SwitchState(NewPlayer.RunState);
        }
        
        private bool IsGrounded()
        {
            RaycastHit hitInfo;
            Vector3 center = NewPlayer.PlayerCapsuleCollider.bounds.center;
            return Physics.SphereCast(center, groundSphereCastRadius, -Vector3.up, out hitInfo, groundSphereCastDistance, LayerMask.GetMask(groundMask));
        }

        private async void WaitUntilAirborne()
        {
            await Task.Delay(_waitTimeUntilAirborne);
            _playerIsAirborne = true;
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

