using System;
using Jesper.PlayerStateMachine;
using UnityEngine;

namespace _programming._scripts._playerScripts {
    public class Player : MonoBehaviour {

        public PlayerStates currentState;
        public PlayerIdleState idleState;
        public PlayerJumpState jumpState;
        public PlayerRunState runState;

        private void Start() {

            currentState = new PlayerStates();
            idleState = new PlayerIdleState(this, "", "");
            jumpState = new PlayerJumpState(this, "", "");
            runState = new PlayerRunState(this, "", "");
            
            currentState = idleState;
            currentState.OnEnter();
            currentState = jumpState;
            currentState.OnEnter();
            currentState = runState;
            currentState.OnEnter();
        }

        private void Update() {
            
        }

        private void SwitchState(PlayerStates newState) {
            currentState.OnExit();
            currentState = newState;
            currentState.OnEnter();
        }
    }
}