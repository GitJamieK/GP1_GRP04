using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.UI;
using UnityEngine.Serialization;
using Jesper.PlayerStateMachine;


public class NewPlayerController : MonoBehaviour, IPausable
{
    private PlayerStates _currentState;
    
    public PlayerIdleState IdleState;
    public PlayerRunState RunState;
    public PlayerJumpState JumpState;

    [SerializeField] private float _moveSpeed;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private CapsuleCollider _capsuleCollider;
    
    private Quaternion _targetRotation;
    public Vector3 CurrentPositiveAxis { get; private set; }
    public Vector3 CurrentNegativeAxis { get; private set; }
    public RotationDirection CurrentRotationDirection { get; private set; }
    public bool MovementLocked { get; private set; }
    public float MovementDirection { get; private set; }

    public Rigidbody PlayerRigidbody{get{return _rigidbody;}}
    public CapsuleCollider PlayerCapsuleCollider{get{return _capsuleCollider;}}
    public float JumpForce;

    [HideInInspector] public float CurrentMoveSpeed;

    void Start()
    {
        _currentState = new PlayerStates();
        IdleState = new PlayerIdleState(this, "idle", "");
        RunState = new PlayerRunState(this, "running", "running");
        JumpState = new PlayerJumpState(this, "jumping", "jumping");

        _currentState = IdleState;
        _currentState.OnEnter();

        SubscribeToEvents();
        CurrentMoveSpeed = _moveSpeed;
        MovementDirection = 1f;
        RefreshCurrentAxes();
    }

    public virtual void SwitchState(PlayerStates newState)
    {
        Debug.Log(this.name + " switched to " + newState + " state!");
        _currentState.OnExit();
        _currentState = newState;
        _currentState.OnEnter();
    }

    private void OnDestroy()
    {
        UnsubscribeFromEvents();
    }

    private void SubscribeToEvents()
    {
        GameManager.Instance.EventService.OnPlayerEnteredWorldRotationTrigger += RotatePlayer;
    }

    private void UnsubscribeFromEvents()
    {
        GameManager.Instance.EventService.OnPlayerEnteredWorldRotationTrigger -= RotatePlayer;
    }

    public void Pause()
    {
        CurrentMoveSpeed = 0f;
        MovementLocked = true;
    }

    public void Resume()
    {
        CurrentMoveSpeed = _moveSpeed;
        MovementLocked = false;
        MovementDirection = 1f;
    }

    private void RefreshCurrentAxes()
    {
        float dotProductWithZAxis = Vector3.Dot(transform.forward, Vector3.forward);
        float dotProductWithXAxis = Vector3.Dot(transform.forward, Vector3.right);

        if (dotProductWithZAxis > 0.01f || dotProductWithZAxis < -0.01f)
        {
            CurrentPositiveAxis = dotProductWithZAxis > 0f ? Vector3.forward : Vector3.back;
            CurrentNegativeAxis = dotProductWithZAxis > 0f ? Vector3.back : Vector3.forward;
        }

        else if (dotProductWithXAxis > 0.01f || dotProductWithXAxis < -0.01f)
        {
            CurrentPositiveAxis = dotProductWithXAxis > 0f ? Vector3.right : Vector3.left;
            CurrentNegativeAxis = dotProductWithXAxis > 0f ? Vector3.left : Vector3.right;
        }
    }

    void Update()
    {
        _currentState.LogicUpdate();
    }

    private void FixedUpdate()
    {
        _currentState.PhysicsUpdate();
    }

    private void RotatePlayer(RotationDirection rotationDirection)
    {
        CurrentRotationDirection = rotationDirection;
        transform.forward = rotationDirection == RotationDirection.FORWARD ? -transform.right : transform.right;
        RefreshCurrentAxes();
        MovementLocked = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DirectionSwap"))
            MovementDirection *= -1f;
    }
}