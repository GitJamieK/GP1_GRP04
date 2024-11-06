using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour, IPausable {
    public int AcornScore = 0;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private CapsuleCollider _capsuleCollider;
    [SerializeField] private Animator _animator;
    // [SerializeField] private ParticleSystem _runDustParticles;

    private Quaternion _targetRotation;
    private Vector3 _currentPositiveAxis;
    private Vector3 _currentNegativeAxis;
    private readonly Vector3 _offsetVector = new Vector3(0.0001f, 0f, 0.0001f);
    private bool _movementLocked;
    private float _movementDirection;
    private float _currentMoveSpeed;

    private readonly float groundSphereCastDistance = 0.9f;
    private readonly float groundSphereCastRadius = 0.2f;
    private readonly string groundMask = "Ground";

    public RotationDirection CurrentRotationDirection { get; private set; }

    void Awake()
    {
        RefreshCurrentAxes();
        _animator.SetTrigger("Run");
    }

    void Start()
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
        // _runDustParticles.Stop();
    }

    public void Resume()
    {
        _currentMoveSpeed = _moveSpeed;
        _movementLocked = false;
        _movementDirection = 1f;
        // _runDustParticles.Play();
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

        if (UnityEngine.Input.GetKeyDown(KeyCode.Space) && IsGrounded())
            MakePlayerJump();

        if (UnityEngine.Input.GetKeyDown(KeyCode.A))
            GameManager.Instance.EventService.InvokePlayerToggledPlatformTriggerEvent();

        UpdateRotation();
        UpdateMovement();
    }

    public void DoJump(InputAction.CallbackContext ctx)
    {
        if (ctx.performed && IsGrounded())
            MakePlayerJump();
    }

    public void DoTogglePlatform(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
            GameManager.Instance.EventService.InvokePlayerToggledPlatformTriggerEvent();
    }

    private void UpdateMovement()
    {
        transform.position += _currentMoveSpeed * Time.deltaTime * transform.forward;
        if (IsGrounded() == false)
             _animator.SetBool("Jump", true);
        if(IsGrounded() == true)
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

    private bool IsGrounded()
    {
        RaycastHit hitInfo;
        Vector3 center = _capsuleCollider.bounds.center;
        return Physics.SphereCast(center, groundSphereCastRadius, -Vector3.up, out hitInfo, groundSphereCastDistance,
            LayerMask.GetMask(groundMask));
    }
}