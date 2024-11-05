using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour, IPausable
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private CapsuleCollider _capsuleCollider;
    [SerializeField] private float _jumpForce;
    
    private Quaternion _targetRotation;
    private Vector3 _currentPositiveAxis;
    private Vector3 _currentNegativeAxis;
    private bool _movementLocked;
    private bool _isAirborne;
    private float _movementDirection; 
    private float _currentMoveSpeed;
    
    private readonly float groundSphereCastDistance = 0.9f;
    private readonly float groundSphereCastRadius = 0.2f;
    private readonly string groundMask = "Ground";
    
    public RotationDirection CurrentRotationDirection { get; private set; }
    void Start()
    {
        SubscribeToEvents();
        _currentMoveSpeed = _moveSpeed;
        _movementDirection = 1f;
        RefreshCurrentAxes();
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
        _currentMoveSpeed = 0f;
        _movementLocked = true;
    }

    public void Resume()
    {
        _currentMoveSpeed = _moveSpeed;
        _movementLocked = false;
        _movementDirection = 1f;
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

    void Update()
    {
        if (_movementLocked)
            return;
            
        if(UnityEngine.Input.GetKeyDown(KeyCode.Space) && IsGrounded())
            DoJump();
        
        if(UnityEngine.Input.GetKeyDown(KeyCode.A))
            GameManager.Instance.EventService.InvokePlayerToggledPlatformTriggerEvent();
        
        UpdateMovement();
        UpdateRotation();
    }

    public void DoJump(InputAction.CallbackContext ctx)
    {
        if(ctx.performed && IsGrounded())
            _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
    }

    public void DoTogglePlatform(InputAction.CallbackContext ctx)
    {
        if(ctx.performed)
            GameManager.Instance.EventService.InvokePlayerToggledPlatformTriggerEvent();
    }

    private void UpdateMovement()
    {
        transform.position += _currentMoveSpeed * Time.deltaTime * transform.forward;
    }
    private void UpdateRotation()
    {
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

    private void DoJump()
    {
        _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
    }
    
    private bool IsGrounded()
    {
        RaycastHit hitInfo;
        Vector3 center = _capsuleCollider.bounds.center;
        return Physics.SphereCast(center, groundSphereCastRadius, -Vector3.up, out hitInfo, groundSphereCastDistance, LayerMask.GetMask(groundMask));
    }

    private void OnCollisionEnter(Collision other)
    {
        if(!IsGrounded())
            _rigidbody.AddForce(-transform.forward * _currentMoveSpeed * 2, ForceMode.Impulse);
    }
}