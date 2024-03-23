using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 10;

    public float turnSpeed;

    public float horizontalInput;

    public float verticalInput;

    private CharacterController _characterController;
    private Animator _animator;
   private float verticalVelocity;
   

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _characterController = GetComponent<CharacterController>();
       
    }

    // Update is called once per frame
    void Update()
    {

        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        // Check if the arrow keys are pressed
        // Check if the arrow keys are pressed
        if (Mathf.Abs(horizontalInput) > 0.1f || Mathf.Abs(verticalInput) > 0.1f)
        {
            // Calculate movement direction
            Vector3 movement = new Vector3(horizontalInput, 0, verticalInput);
            
            //Call animator
            _animator.SetFloat("YMove",horizontalInput);
            if (Input.GetKey(KeyCode.LeftShift) && verticalInput>=1)
            {
                // Move the character using CharacterController
                _characterController.Move(movement * (speed*2) * Time.deltaTime);
                _animator.SetFloat("XMove",verticalInput+1);
            }
            else
            {
                // Move the character using CharacterController
                _characterController.Move(movement * speed * Time.deltaTime);
                _animator.SetFloat("XMove",verticalInput);
            }
            
            // Rotation around the vertical axis (turning)
            transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * horizontalInput);
        }
        rotateOnTurn();
    }
    
    void ApplyGravity()
    {
        if (!_characterController.isGrounded)
        {
            verticalVelocity += Physics.gravity.y * Time.deltaTime;
        }
        else
        {
            // If on the ground, reset the vertical velocity
            verticalVelocity = -0.5f;
        }
    }

    // method for rotating the character on 90 degrees
    void rotateOnTurn()
    {
        if (horizontalInput != 0)
        {
            float angle = Mathf.Atan2(horizontalInput, verticalInput) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, angle, 0);
        }
    }

 
    
}

