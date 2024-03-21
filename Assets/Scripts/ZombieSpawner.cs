using UnityEngine;
using System.Collections;

namespace SimpleLowPolyNature.Scripts
{
    public class ZombieSpawner : MonoBehaviour
    {
        public GameObject zombiePrefab;
        public Transform targetObject;
        public float spawnInterval = 10.0f;
        public int baseNumberOfZombies = 3; // Base number of zombies to spawn

        private int currentWave = 1; // Tracks the current wave or difficulty level

        void Start()
        {
            StartCoroutine(SpawnZombies());
        }

        IEnumerator SpawnZombies()
        {
            while (true)
            {
                int numberOfZombies = CalculateNumberOfZombies();

                for (int i = 0; i < numberOfZombies; i++)
                {
                    SpawnZombie();
                    yield return new WaitForSeconds(spawnInterval);
                }

                yield return new WaitForSeconds(spawnInterval); // Wait between waves
                currentWave++; // Increment the wave
            }
        }

        void SpawnZombie()
        {
            
            Vector3 spawnPosition = new Vector3(113f, 8.7f, -127f);

            // Spawn zombie at the specified position
            GameObject zombie = Instantiate(zombiePrefab, spawnPosition, Quaternion.identity);

            // Set the target for the zombie to move towards
            ZombieMovement zombieMovement = zombie.GetComponent<ZombieMovement>();
            if (zombieMovement != null)
            {
                zombieMovement.SetTarget(targetObject);
            }
        }

        int CalculateNumberOfZombies()
        {
            // Increase the number of zombies based on the current wave
            return baseNumberOfZombies + currentWave - 1;
        }
    }
}

