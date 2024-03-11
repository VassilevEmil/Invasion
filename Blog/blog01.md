---
title: "Blog 1 Roll-a-ball"
author: "Adrian-Cristian Militaru"
date: "13-02-2024"
version: "0.1"
---

# Setting up the Game

For this project, I used the Unity 2022.3.19f1 engine version and the "3D URP" project template.

I began by creating the Ball as a "Player" and the cubes as "PickUp" objects, as well as the arena, which is made up of a plane for the floor and cubes for the walls.

![Game Scene](/blog/img.png)

# Moving the player

public class PlayerController : MonoBehaviour
{
// Rigidbody of the player.
private Rigidbody rb;

    // Movement along X and Y axes.
    private float movementX;
    private float movementY;

    private int count;

    // Speed at which the player moves.
    public float speed = 0;
    public TextMeshProUGUI countText;

    public GameObject winTextObject;
    // Start is called before the first frame update.
    void Start()
    {
        // Get and store the Rigidbody component attached to the player.
        rb = GetComponent<Rigidbody>();
        count = 0;

        SetCountText();
        winTextObject.SetActive(false);
    }
// This function is called when a move input is detected.
void OnMove(InputValue movementValue)
{
// Convert the input value into a Vector2 for movement.
Vector2 movementVector = movementValue.Get<Vector2>();

        // Store the X and Y components of the movement.
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 11)
        {
            winTextObject.SetActive(true);
        }
    }

    // FixedUpdate is called once per fixed frame-rate frame.
    private void FixedUpdate()
    {

        // Create a 3D movement vector using the X and Y inputs.
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        // Apply force to the Rigidbody to move the player.
        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            
            SetCountText();
            
        }

        
    }

## Pick up the objects 

The cubes that the player will pick up will only have a rotation motion, which will be achieved by utilizing the Rotate transform function within the Update method.

public class Rotator : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(15,30,45) * Time.deltaTime);
        
    }
}
