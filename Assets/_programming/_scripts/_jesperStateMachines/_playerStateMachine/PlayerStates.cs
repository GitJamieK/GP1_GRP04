namespace Jesper.PlayerStateMachine {
    public class PlayerStates {
        /// <summary>
        /// Reference to Player Script
        /// </summary>
        protected NewPlayerController NewPlayer;
        private string AnimationName { get; set; }
        private string AudioFileName { get; set; }

        /// <summary>
        /// Empty Constructor
        /// </summary>
        public PlayerStates() { }
        
        /// <summary>
        /// Default Constructor. Choose this one
        /// </summary>
        /// <param name="p"></param>
        /// <param name="anim"></param>
        /// <param name="audio"></param>
        /// <example>p = Reference to Player.
        /// anim = Reference to Animation Parameter Name.
        /// audio = Reference to Audio Clip Name.</example>
        public PlayerStates(NewPlayerController p, string anim, string audio) {
            NewPlayer = p;
            AnimationName = anim;
            AudioFileName = audio;
        }
        /// <example>p = Reference to Manager.
        /// anim = Reference to Animation Parameter Name.
        /// audio = Reference to Audio Clip Name.</example>
        public virtual void OnEnter() { }
        /// <summary>
        /// Decides if something should happen when we exit a state
        /// </summary>
        public virtual void OnExit() { }
        /// <summary>
        /// Acts like Update (Connect LogicUpdate to the Update Method in MonoBehaviour Script)
        /// </summary>
        public virtual void LogicUpdate() { }
        /// <summary>
        /// Acts like FixedUpdate (Connect PhysicsUpdate to the FixedUpdate Method in MonoBehaviour Script)
        /// </summary>
        public virtual void PhysicsUpdate() { }
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

