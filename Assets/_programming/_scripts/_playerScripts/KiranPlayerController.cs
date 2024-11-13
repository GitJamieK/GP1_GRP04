using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


public class KiranPlayerController : MonoBehaviour, IPausable
{
    [SerializeField] private PlayerScriptableObject _playerScriptableObject;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private CapsuleCollider _capsuleCollider;
    [SerializeField] private Animator _animator;

    private Quaternion _targetRotation;
    private Vector3 _currentPositiveAxis;
    private Vector3 _currentNegativeAxis;
    
    private bool _movementLocked;
    private bool _isGrounded;

    private float _moveSpeed;
    private float _jumpForce;
    private float _groundSphereCastDistance;
    private float _movementDirection;
    private float _currentMoveSpeed;
    
    private readonly float _groundSphereCastRadius = 0.2f;
    private readonly string _groundMask = "Ground";

    public RotationDirection CurrentRotationDirection { get; private set; }

    private void Awake()
    {
        InitData();
        RefreshCurrentAxes();
        _animator.SetTrigger("Run");
    }

    private void InitData()
    {
        _moveSpeed = _playerScriptableObject.MoveSpeed;
        _jumpForce = _playerScriptableObject.UpwardJumpForce;
        _groundSphereCastDistance = _playerScriptableObject.GroundSphereCastDistance;
        _isGrounded = false;
    }

    private void Start()
    {
        SubscribeToEvents();
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

    public void Pause() //find out way to stop animations when paused maybe
    {
        _currentMoveSpeed = 0f;
        _movementLocked = true;
        _rigidbody.useGravity = false;
    }

    public void Resume()
    {
        _currentMoveSpeed = _moveSpeed;
        _movementLocked = false;
        _movementDirection = 1f;
        _rigidbody.useGravity = true;
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
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

    public void UpdatePlayer()
    {
        if (_movementLocked)
            return;
        
        if (UnityEngine.Input.GetKeyDown(KeyCode.Space) && _isGrounded)
            MakePlayerJump();

        if (UnityEngine.Input.GetKeyDown(KeyCode.A))
            GameManager.Instance.EventService.InvokePlayerToggledPlatformTriggerEvent();

        DoGroundCheck();
        UpdateRotation();
        UpdateMovement();
    }

    public void DoJump(InputAction.CallbackContext ctx)
    {
        if (ctx.performed && _isGrounded)
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

    private void UpdateMovement()
    {
        transform.position += _currentMoveSpeed * Time.deltaTime * transform.forward;
        if (!_isGrounded)
            _animator.SetBool("Jump", true);
        else
            _animator.SetBool("Jump", false);
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

    private void MakePlayerJump()
    {
        _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
    }

    private void DoGroundCheck()
    {
        RaycastHit hitInfo;
        Vector3 center = _capsuleCollider.bounds.center;
        _isGrounded = Physics.SphereCast(center, _groundSphereCastRadius, -Vector3.up, out hitInfo, _groundSphereCastDistance,
            LayerMask.GetMask(_groundMask));
    }
}