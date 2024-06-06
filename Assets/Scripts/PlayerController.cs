using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    public float turnSpeed = 2f;
    
    private CharacterController _characterController;
    private Animator _animator;
    private PlayerInput _playerInput;
    private float verticalVelocity;
    private float _timer;
    private bool _hasRotate;
    

    void Start()
    {
        
        _animator = GetComponent<Animator>();
        _characterController = GetComponent<CharacterController>();
        _playerInput = GetComponent<PlayerInput>();
    }

    void Update()
    {
        Vector2 movementInput = _playerInput.actions["Move"].ReadValue<Vector2>();

        // Handle movement
        Vector3 forwardMovement = transform.forward * movementInput.y * speed * Time.deltaTime;
        _characterController.Move(forwardMovement);
        
        // Handle rotation
        float turn = 0;

// Check if movementInput is 1 or -1
        if (movementInput.x != 0 && !_hasRotate)
        {
            _hasRotate = true;
            turn = movementInput.x == 1 ? 90 : -90;
        }

        if (_hasRotate)
        {
            _timer += Time.deltaTime;
            if (_timer >= 0.5f)
            {
                _timer = 0;
                _hasRotate = false;
            }
        }

// Apply the rotation
        transform.Rotate(0, turn, 0);


        // Update animator parameters
        _animator.SetFloat("YMove", movementInput.y);
        //_animator.SetFloat("XMove", movementInput.x);

        ApplyGravity();
    }

    void ApplyGravity()
    {
        if (!_characterController.isGrounded)
        {
            verticalVelocity += Physics.gravity.y * Time.deltaTime;
            _characterController.Move(new Vector3(0, verticalVelocity, 0) * Time.deltaTime);
        }
        else
        {
            verticalVelocity = -0.5f;
        }
    }
}