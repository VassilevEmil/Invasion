# Game optimisations and some extra logics

I decided to create object pool for the spawning objects from the player as well, in order to improve the memory and game performance.

    using System.Collections.Generic;
    using UnityEngine;

    namespace SimpleLowPolyNature.Scripts
    {
    public class RockPoolManager : MonoBehaviour
    {
    public GameObject rockPrefab;
    public int poolSize = 10;
    private List<GameObject> rockPool = new List<GameObject>();

        void Start()
        {
            // Initialize the pool with inactive rocks
            for (int i = 0; i < poolSize; i++)
            {
                GameObject rock = Instantiate(rockPrefab);
                rock.SetActive(false);
                rockPool.Add(rock);
            }
        }

        public GameObject SpawnRock(Vector3 position, Quaternion rotation)
        {
            // Find an inactive rock in the pool
            foreach (GameObject rock in rockPool)
            {
                if (!rock.activeSelf)
                {
                    rock.transform.SetPositionAndRotation(position, rotation);
                    rock.SetActive(true);
                    return rock;
                }
            }

            // If no inactive rock is found, create a new one and add it to the pool
            GameObject newRock = Instantiate(rockPrefab, position, rotation);
            rockPool.Add(newRock);
            return newRock;
        }

        public void ReturnRockToPool(GameObject rock)
        {
            rock.SetActive(false);
        }
    }
    }

# After that i realised that the rocks that do not hit any zombie are flying indefinitely and they are not returning to the pool, so i added a lifespan of the rock projectile.

    using System;
    using TMPro;
    using UnityEngine;
    using UnityEngine.InputSystem;
    using UnityEngine.Serialization;
    using UnityEngine.UI;

    namespace SimpleLowPolyNature.Scripts
    {
    public class RockSpawning : MonoBehaviour
    {
    public RockPoolManager rockPoolManager; // Reference to the RockPoolManager
    public TextMeshProUGUI killCountText;
    public float rockSpeed = 20f;
    private PlayerInput _playerInput;
    private bool _hasAttack;
    private float _timer = 0f;

        private void Start()
        {
            _playerInput = GetComponent<PlayerInput>();
            _hasAttack = false;
        }

        void Update()
        {
            // Check if the space key is pressed and the spawner can spawn an object
            if (!_hasAttack &&_playerInput.actions["Fire"].ReadValue<float>()>=1f)
            {
                _hasAttack = true;
                SpawnRandomObject();
            }

            if (_hasAttack)
            {
                _timer += Time.deltaTime;
                if (_timer >= 1f)
                {
                    _timer = 0;
                    _hasAttack = false;
                }
            }
        }

        void SpawnRandomObject()
        {
            // Get the player's position
            Vector3 playerPosition = transform.position;

            // Calculate the spawn position in front of the player
            Vector3 spawnOffset = transform.forward * 2; // Adjust the forward offset as needed
            Vector3 spawnPosition = playerPosition + spawnOffset;

            // Spawn the rock using the RockPoolManager
            GameObject spawnedRock = rockPoolManager.SpawnRock(new Vector3(spawnPosition.x, spawnPosition.y + 1, spawnPosition.z), transform.rotation);
            spawnedRock.GetComponent<RockCollision>().Init(rockPoolManager,killCountText);
            Debug.Log($"Spawned rock at position: {spawnedRock.transform.position}");
            // Check if the spawned object has a Rigidbody component
            Rigidbody rb = spawnedRock.GetComponent<Rigidbody>();
            if (rb == null)
            {
                Debug.LogWarning("Rigidbody component not found on the spawned object. Adding Rigidbody component.");
                // Add a Rigidbody component to the spawned object
                rb = spawnedRock.AddComponent<Rigidbody>();
            }

            
            rb.velocity = spawnedRock.transform.forward * rockSpeed;
            
            // Ensure the rock is active
            spawnedRock.SetActive(true);
        }
    }
    }

    using System.Collections;
    using System.Collections.Generic;
    using SimpleLowPolyNature.Scripts;
    using TMPro;
    using UnityEngine;
    using UnityEngine.UI;

    public class RockCollision : MonoBehaviour
    {
    public TextMeshProUGUI killCountText;
    public GameOverScreen gameOverScreen;
    public RockPoolManager rockPoolManager; // Reference to the RockPoolManager

    public static int killCount = 0;
    
    public int KillCount => killCount;

    public float lifespan = 5f; // Lifespan of the projectile in seconds
    private float timer; // Timer to track the lifespan

    public void Init(RockPoolManager rockPoolManager, TextMeshProUGUI killCountText)
    {
        this.rockPoolManager = rockPoolManager;
        timer = lifespan; // Initialize the timer
        this.killCountText = killCountText;
    }

    void Update()
    {
        // Decrement the timer
        timer -= Time.deltaTime;

        // Check if the rock is out of bounds
        if (timer <= 0)
        {
            rockPoolManager.ReturnRockToPool(gameObject); // Return the rock to the pool if it goes out of bounds or the timer expires

        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("collision name, " + other.gameObject.name);
        if (other.CompareTag("Zombie"))
        {
            ZombieMovement zombie = other.GetComponent<ZombieMovement>();
            if (zombie != null)
            {
                zombie.Die();
                killCount++;
                Debug.Log("Kills:  " + killCount);
                UpdateKillsUI();

                // Return the rock to the pool
                rockPoolManager.ReturnRockToPool(gameObject);
            }
        }
    }

    void UpdateKillsUI()
    {
        killCountText.text = "Kills: " + killCount.ToString();
    }
    }

# Finally, i made it so, when the 'Game Over' screen appears, the game to stop and only the user input to be available, so the user is still able to choose what to do from the game over screen options. 
