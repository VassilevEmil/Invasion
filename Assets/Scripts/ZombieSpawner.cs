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
            }
        }

        void SpawnZombie()
        {
            // Spawn zombie at a random position
            Vector3 randomPosition = new Vector3(Random.Range(-10f, 10f), 0f, Random.Range(-10f, 10f));
            GameObject zombie = Instantiate(zombiePrefab, randomPosition, Quaternion.identity);

            // Set the target for the zombie to move towards
            ZombieMovement zombieMovement = zombie.GetComponent<ZombieMovement>();
            if (zombieMovement != null)
            {
                zombieMovement.SetTarget(targetObject);
            }
        }

        int CalculateNumberOfZombies()
        {
          
            switch (DifficultyLevel.CurrentDifficulty)
            {
                case DifficultyLevel.levelOfDifficulty.Story:
                    return baseNumberOfZombies;
                case DifficultyLevel.levelOfDifficulty.Easy:
                    return baseNumberOfZombies + 1;
                case DifficultyLevel.levelOfDifficulty.Normal:
                    return baseNumberOfZombies + 2;
                case DifficultyLevel.levelOfDifficulty.Hard:
                    return baseNumberOfZombies + 3;
                case DifficultyLevel.levelOfDifficulty.UltraHard:
                    return baseNumberOfZombies + 4;
                default:
                    return baseNumberOfZombies;
            }
        }
    }
}
