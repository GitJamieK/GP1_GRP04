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
        public PlayerJumpState(PlayerController p, string anim, string audio) : base(p, anim, audio) { }
        public PlayerJumpState(PlayerController p, string anim) : base(p, anim) { }

        public override void OnEnter() {
            base.OnEnter();
            Player.PlayerRigidbody.linearVelocity = new(Player.PlayerRigidbody.linearVelocity.x, Player.Velocity, Player.PlayerRigidbody.linearVelocity.z);
            WaitUntilAirborne();
        }

        public override void OnExit() {
            base.OnExit();
            _playerIsAirborne = false;
        }

        public override void LogicUpdate() {
            base.LogicUpdate();
        }

        public override void PhysicsUpdate() {
            base.PhysicsUpdate();
            Jump();
            if(Player.IsGrounded && _playerIsAirborne)
                Player.SwitchState(Player.RunState);
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

        void Jump() {
            
            Player.transform.position += Player.CurrentMoveSpeed * Time.deltaTime * Player.transform.forward;

            if(Player.PlayerRigidbody.linearVelocity.y > 0.01f)
                Player.PlayerRigidbody.AddForce(Vector3.down * Player.UpwardJumpForce, ForceMode.Acceleration);
        }
    }
}

