using UnityEngine;

namespace Jesper.PlayerStateMachine {
    public class PlayerStates {
        /// <summary>
        /// Reference to Player Script
        /// </summary>
        protected PlayerController Player;
        private string AnimationName { get; set; }
        private string AudioFileName { get; set; }

        /// <summary>
        /// Empty Constructor
        /// </summary>
        public PlayerStates() { }
        
        /// <summary>
        /// Default Constructor. Choose this one
        /// </summary>
        /// <param name="p">Reference to Player.</param>
        /// <param name="anim">Reference to Animation Parameter Name.</param>
        public PlayerStates(PlayerController p, string anim) {
            Player = p;
            AnimationName = anim;
        }
        
        /// <summary>
        /// Default Constructor. Choose this one
        /// </summary>
        /// <param name="p">Reference to Player.</param>
        /// <param name="anim">Reference to Animation Parameter Name.</param>
        /// <param name="audio">Reference to Audio Clip Name.</param>
        public PlayerStates(PlayerController p, string anim, string audio) {
            Player = p;
            AnimationName = anim;
            AudioFileName = audio;
        }

        /// <example>p = Reference to Manager.
        /// anim = Reference to Animation Parameter Name.
        /// audio = Reference to Audio Clip Name.</example>
        public virtual void OnEnter() {
            Player._animator.SetBool(AnimationName, true);
        }

        /// <summary>
        /// Decides if something should happen when we exit a state
        /// </summary>
        public virtual void OnExit() {
            Player._animator.SetBool(AnimationName, false);
        }

        /// <summary>
        /// Acts like Update (Connect LogicUpdate to the Update Method in MonoBehaviour Script)
        /// </summary>
        public virtual void LogicUpdate() {
            if (Player.MovementLocked)
                return;
            
        }

        /// <summary>
        /// Acts like FixedUpdate (Connect PhysicsUpdate to the FixedUpdate Method in MonoBehaviour Script)
        /// </summary>
        public virtual void PhysicsUpdate() {
            if (Player.MovementLocked)
                return;
            
            Debug.Log("Player are falling");
            if(Player.PlayerRigidbody.linearVelocity.y < 0.01f)
                Player.PlayerRigidbody.AddForce(Vector3.down * Player.DownwardJumpForce, ForceMode.Acceleration);
        }
        /// <summary>
        /// Trigger an Animation Parameter when Animation are enter
        /// </summary>
        public virtual void AnimationEnterTrigger() { }
        /// <summary>
        /// Trigger an Animation Parameter when Animation are finished
        /// </summary>
        public virtual void AnimationFinishedTrigger() { }
        /// <summary>
        /// Trigger an Audio clip
        /// </summary>
        public virtual void AudioTrigger() { }
    }
}

