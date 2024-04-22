using UnityEngine;
using System.Collections;
using TMPro;

namespace SimpleLowPolyNature.Scripts
{
   
 


    public class ZombieSpawner : MonoBehaviour
    {
        public ZombiePoolManager zombiePoolManager;
        public GameObject targetObject;
        public float spawnInterval = 25.0f;

        // Variable for tracking the number of alive zombies
        public int zombieCount;
        public TextMeshProUGUI zombieCountText;

        private float zombiesToSpawn = 1; // Number of zombies to spawn initially

        void Start()
        {
            InvokeRepeating(nameof(SpawnZombie), 0f, spawnInterval);
            zombieCount = 0; // Initialize the count to zero
            UpdateZombieCount(); // Update the text initially
        }

        void SpawnZombie()
        {
            float offsetX = Random.Range(-5f, 5f);
            float offsetZ = Random.Range(-5f, 5f);
            Vector3 spawnPosition = new Vector3(113f + offsetX, 8.7f, -127f + offsetZ);

            // Spawn the specified number of zombies
            for (int i = 0; i < zombiesToSpawn; i++)
            {
                // Spawn zombie using the pool manager
                GameObject zombie = zombiePoolManager.SpawnZombie(spawnPosition);
                if (zombie != null)
                {
                    // Increment the zombie count when a zombie is spawned
                    zombieCount++;
                    UpdateZombieCount(); // Update the text
                    // Set the target for the zombie to move towards
                    ZombieMovement zombieMovement = zombie.GetComponent<ZombieMovement>();
                    if (zombieMovement != null)
                    {
                        zombieMovement.SetTarget(targetObject.transform);
                        
                        Debug.Log("targeeeeeeeeet" + targetObject.transform.position);
                    }
                }
            }

            // increasing with each new wave
            zombiesToSpawn *= 1.2f;
        }

        void UpdateZombieCount()
        {
            zombieCountText.text = "Zombies: " + zombieCount.ToString();
        }

        // Method to decrement the zombie count when a zombie dies
        public void DecrementZombieCount()
        {
            zombieCount--;
            UpdateZombieCount(); // Update the text
        }
    }

}