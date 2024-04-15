#  Adding an object pooling for the zombies

Due to the fact that at certain point of the game there could be 1000+ zombies alive, this could potentially lead to very low performance and slow down the game or even make the game crash. Therefore, an object pooling is needed, 
where I just set zombies to either active or inactive and they are coming from the pool of zombies. 


using System.Collections.Generic;
using UnityEngine;

namespace SimpleLowPolyNature.Scripts
{
public class ZombiePoolManager : MonoBehaviour
{
public GameObject zombiePrefab;
public int poolSize = 10;

        private List<GameObject> zombiePool = new List<GameObject>();

        void Start()
        {
            // Create the pool of zombie objects
            for (int i = 0; i < poolSize; i++)
            {
                GameObject zombie = Instantiate(zombiePrefab, Vector3.zero, Quaternion.identity);
                zombie.SetActive(false); // Deactivate the zombie initially
                zombiePool.Add(zombie);
            }
        }

        public GameObject SpawnZombie(Vector3 position)
        {
            // Find an inactive zombie from the pool
            foreach (GameObject zombie in zombiePool)
            {
                if (!zombie.activeSelf)
                {
                    zombie.transform.position = position; // Set the position of the zombie
                    zombie.SetActive(true); // Activate the zombie
                    return zombie;
                }
            }

            // If no inactive zombie is found, create a new one 
            
            GameObject newZombie = Instantiate(zombiePrefab, position, Quaternion.identity);
            zombiePool.Add(newZombie); // Add the new zombie to the pool
            return newZombie;
        }

        public void DeactivateZombie(GameObject zombie)
        {
            // Deactivate the zombie and return it to the pool
            zombie.SetActive(false);
        }
    }
}

# Level-up

I decided to change the logic for leveling up. Instead of giving the power to the player to choose 
the level of the game himself, the game would level-up automatically.



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
                        zombieMovement.SetTarget(targetObject);
                        
                        Debug.Log("targeeeeeeeeet" + targetObject.position);
                    }
                }
            }

            // increasing with each new wave
            zombiesToSpawn *= 1.2f;
        }

the important variable here is #zombiesToSpawn *= 1.2f;# where at each new iteration we increase the spawned zombies

# Rock Spawning

The RockSpawning class is responsible for spawning objects from the player to kill the zombies

using UnityEngine;

namespace SimpleLowPolyNature.Scripts
{
public class RockSpawning : MonoBehaviour
{
public GameObject[] spawnableObjects; // Array of objects that can be spawned
public float rockSpeed = 20f;

        void Update()
        {
            // Check if the space key is pressed and the spawner can spawn an object
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SpawnRandomObject();
            }
        }
        void SpawnRandomObject()
        {
            // Get the player's position
            Vector3 playerPosition = transform.position;

            // Calculate the spawn position in front of the player
            Vector3 spawnOffset = transform.forward * 2; // Adjust the forward offset as needed
            Vector3 spawnPosition = playerPosition + spawnOffset;

            // Get a random index for the spawnable objects array
            int randomIndex = Random.Range(0, spawnableObjects.Length);

            // Spawn the object at the calculated spawn position
            GameObject spawnedObject = Instantiate(spawnableObjects[randomIndex], new Vector3(spawnPosition.x, spawnPosition.y + 1, spawnPosition.z), Quaternion.identity);

            // Check if the spawned object has a Rigidbody component
            Rigidbody rb = spawnedObject.GetComponent<Rigidbody>();
            if (rb == null)
            {
                Debug.LogWarning("Rigidbody component not found on the spawned object. Adding Rigidbody component.");
                // Add a Rigidbody component to the spawned object
                rb = spawnedObject.AddComponent<Rigidbody>();
            }

            // Apply a forward force to the spawned object
            rb.AddForce(transform.forward * 10, ForceMode.Impulse);
        }
       

    }
}



