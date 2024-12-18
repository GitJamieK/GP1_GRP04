namespace Jesper.GeneralStateMachine {
    public class ManagerStates {
        public object manager;
        public string AnimationName { get; set; }
        public string AudioFileName { get; set; }

        /// <summary>
        /// Empty Constructor
        /// </summary>
        public ManagerStates() { }
        
        /// <summary>
        /// Default Constructor. Choose this one
        /// </summary>
        /// <param name="manager"></param>
        /// <param name="anim"></param>
        /// <param name="audio"></param>
        /// <example>m = Reference to Manager.
        /// anim = Reference to Animation Parameter Name.
        /// audio = Reference to Audio Clip Name.</example>
        public ManagerStates(object manager, string anim, string audio) {
            this.manager = manager;
            AnimationName = anim;
            AudioFileName = audio;
        }
        /// <summary>
        /// Acts like MonoBehaviour Start method
        /// </summary>
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
