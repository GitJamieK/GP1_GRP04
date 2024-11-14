using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using Jesper.PlayerStateMachine;


public class PlayerController : MonoBehaviour, IPausable
{
    
    public PlayerStates _currentState;
    
    public PlayerIdleState IdleState;
    public PlayerRunState RunState;
    public PlayerJumpState JumpState;
    
    [SerializeField] private NewPlayerScriptableObject _playerScriptableObject;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private CapsuleCollider _capsuleCollider;
    public Animator _animator;

    private Quaternion _targetRotation;
    private Vector3 _currentPositiveAxis;
    private Vector3 _currentNegativeAxis;
    
    private bool _movementLocked;
    private bool _isGrounded;

    private float _moveSpeed;
    private float _upwardJumpForce;
    private float _downwardJumpForce;
    private float _velocity;
    private float _groundSphereCastDistance;
    private float _movementDirection;
    private float _currentMoveSpeed;
    
    private readonly float _groundSphereCastRadius = 0.2f;
    private readonly string _groundMask = "Ground";

    public Rigidbody PlayerRigidbody{get{ return _rigidbody;} set {_rigidbody = value;}}

    public CapsuleCollider PlayerCapsuleCollider {
        get{return _capsuleCollider;} set {_capsuleCollider = value;} }
    public bool MovementLocked { get; private set; }
    
    public bool IsGrounded {
        get { return _isGrounded; } set { _isGrounded = value; }
    }

    public float CurrentMoveSpeed {
        get { return _currentMoveSpeed; } set{ _currentMoveSpeed = value;}
    }

    public float MovementDirection {
        get { return _movementDirection; } set{ _movementDirection = value;} }

    public float UpwardJumpForce {
        get { return _upwardJumpForce; } set{ _upwardJumpForce = value;}
    }
    
    public float DownwardJumpForce {
        get { return _downwardJumpForce; } set{ _downwardJumpForce = value;}
    }
    public float Velocity {
        get { return _velocity; } set{ _velocity = value;}
    }
    
    public Vector3 CurrentPositiveAxis {
        get { return _currentPositiveAxis;} set{ _currentPositiveAxis = value;} 
    }

    public Vector3 CurrentNegativeAxis { 
        get { return _currentNegativeAxis; } set { _currentNegativeAxis = value; }
        
    }
    
    public RotationDirection CurrentRotationDirection { get; private set; }

    private void Awake()
    {
        InitData();
        RefreshCurrentAxes();
    }

    private void InitData()
    {
        _moveSpeed = _playerScriptableObject.MoveSpeed;
        _upwardJumpForce = _playerScriptableObject.UpwardJumpForce;
        _downwardJumpForce = _playerScriptableObject.DownwardJumpForce;
        _velocity = _playerScriptableObject.Velocity;
        _groundSphereCastDistance = _playerScriptableObject.GroundSphereCastDistance;
        _isGrounded = false;
    }

    private void Start()
    {
        _currentState = new PlayerStates();
        // IdleState = new PlayerIdleState(this, "idle");
        RunState = new PlayerRunState(this, "Run");
        JumpState = new PlayerJumpState(this, "Jump");

        _currentState = RunState;
        _currentState.OnEnter();
        _rigidbody.useGravity = true;
        
        SubscribeToEvents();
    }

    private void OnDestroy()
    {
        UnsubscribeFromEvents();
    }

    private void SubscribeToEvents()
    {
        GameManager.Instance.EventService.OnPlayerEnteredWorldRotationTrigger += RotatePlayer;
        GameManager.Instance.EventService.OnPlayerReachedFinishDoor += OnPlayerReachedExitDoor;
        GameManager.Instance.EventService.OnPlayerStartedOpeningDoor += OnPlayerStartedOpeningDoor;
    }

    private void UnsubscribeFromEvents()
    {
        GameManager.Instance.EventService.OnPlayerEnteredWorldRotationTrigger -= RotatePlayer;
        GameManager.Instance.EventService.OnPlayerReachedFinishDoor -= OnPlayerReachedExitDoor;
        GameManager.Instance.EventService.OnPlayerStartedOpeningDoor -= OnPlayerStartedOpeningDoor;
    }
    
    public void UpdatePlayer()
    {
        _currentState.LogicUpdate();
        if (Input.GetKeyDown(KeyCode.A))
            GameManager.Instance.EventService.InvokePlayerToggledPlatformTriggerEvent();
        
        _moveSpeed = _playerScriptableObject.MoveSpeed;
        _upwardJumpForce = _playerScriptableObject.UpwardJumpForce;
        _downwardJumpForce = _playerScriptableObject.DownwardJumpForce;
        _velocity = _playerScriptableObject.Velocity;
        _groundSphereCastDistance = _playerScriptableObject.GroundSphereCastDistance;
        
        UpdateRotation();
        DoGroundCheck();
    }

    public void PhysicsUpdate()
    {
        _currentState.PhysicsUpdate();
    }

    public void Pause() //find out way to stop animations when paused maybe
    {
        _upwardJumpForce = 0f;
        _downwardJumpForce = 0f;
        _velocity = 0f;
        _currentMoveSpeed = 0f;
        _movementLocked = true;
        _rigidbody.useGravity = false;
    }

    public void Resume()
    {
        _upwardJumpForce = _playerScriptableObject.UpwardJumpForce;
        _downwardJumpForce = _playerScriptableObject.DownwardJumpForce;
        _velocity = _playerScriptableObject.Velocity;
        _currentMoveSpeed = _moveSpeed;
        _movementLocked = false;
        _movementDirection = 1f;
        _rigidbody.useGravity = true;
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene((int)GameScenes.MAIN_MENU);
    }

    private void OnPlayerReachedExitDoor()
    {
        _currentMoveSpeed = 0f;
        StartCoroutine(nameof(PlayerOpenedExitDoorCoroutine));
    }

    private IEnumerator PlayerOpenedExitDoorCoroutine()
    {
        while(!_isGrounded)
            yield return null;
        GameManager.Instance.EventService.InvokePlayerStartedOpeningDoorEvent();
    }

    private void OnPlayerStartedOpeningDoor()
    {
        _animator.SetTrigger("LevelExit");
    }

    private void RefreshCurrentAxes()
    {
        float dotProductWithZAxis = Vector3.Dot(transform.forward, Vector3.forward);
        float dotProductWithXAxis = Vector3.Dot(transform.forward, Vector3.right);

        if (dotProductWithZAxis > 0.01f || dotProductWithZAxis < -0.01f)
        {
            _currentPositiveAxis = dotProductWithZAxis > 0f ? Vector3.forward : Vector3.back;
            _currentNegativeAxis = dotProductWithZAxis > 0f ? Vector3.back : Vector3.forward;
        }

        else if (dotProductWithXAxis > 0.01f || dotProductWithXAxis < -0.01f)
        {
            _currentPositiveAxis = dotProductWithXAxis > 0f ? Vector3.right : Vector3.left;
            _currentNegativeAxis = dotProductWithXAxis > 0f ? Vector3.left : Vector3.right;
        }
    }

    public void DoJump(InputAction.CallbackContext ctx)
    {
        if (ctx.performed && _isGrounded)
            if(Mathf.Abs(_rigidbody.linearVelocity.y) < 0.01f)
                MakePlayerJump();
    }

    public void DoTogglePlatform(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
            GameManager.Instance.EventService.InvokePlayerToggledPlatformTriggerEvent();
    }

    private void OnPlayerFinishedEnteringLevel()
    {
        GameManager.Instance.EventService.InvokePlayerFinishedEnteringLevelEvent();
    }
    
    private void UpdateRotation()
    {
        if(transform.forward != Vector3.zero)
            transform.forward = _movementDirection > 0f ? _currentPositiveAxis : _currentNegativeAxis;
    }

    private void RotatePlayer(RotationDirection rotationDirection)
    {
        CurrentRotationDirection = rotationDirection;
        transform.forward = rotationDirection == RotationDirection.FORWARD ? -transform.right : transform.right;
        RefreshCurrentAxes();
        _movementLocked = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DirectionSwap"))
            _movementDirection *= -1f;
    }

    public virtual void SwitchState(PlayerStates newState)
    {
        _currentState.OnExit();
        _currentState = newState;
        _currentState.OnEnter();
    }
    
    private void MakePlayerJump()
    {
        SwitchState(JumpState);
    }

    public virtual void DoGroundCheck()
    {
        RaycastHit hitInfo;
        Vector3 center = _capsuleCollider.bounds.center;
        _isGrounded = Physics.SphereCast(center, _groundSphereCastRadius, -Vector3.up, out hitInfo, _groundSphereCastDistance,
            LayerMask.GetMask(_groundMask));
    }
}