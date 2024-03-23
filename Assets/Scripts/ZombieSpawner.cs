using UnityEngine;
using System.Collections;
using TMPro;

namespace SimpleLowPolyNature.Scripts
{
    public class ZombieSpawner : MonoBehaviour
    {
        public GameObject zombiePrefab;
        public Transform targetObject;
        public float spawnInterval = 25.0f;
        public int baseNumberOfZombies = 1; // Base number of zombies to spawn

        // var for tracking the number of alive zombies
        public int zombieCount;
        public TextMeshProUGUI zombieCountText;


        void Start()
        {
            StartCoroutine(SpawnZombies());
            zombieCount = 1;
            setCountText(zombieCount);
        }

        IEnumerator SpawnZombies()
        {
            while (true)
            {
                // int numberOfZombies = baseNumberOfZombies;
                for (int i = 0; i < baseNumberOfZombies; i++)
                {

                    SpawnZombie(baseNumberOfZombies);
                    baseNumberOfZombies += baseNumberOfZombies;

                    // number of alive zombies
                    zombieCount = baseNumberOfZombies;
                    setCountText(zombieCount);
                    yield return new WaitForSeconds(spawnInterval);

                }
            }
        }

        void setCountText(int count)
        {
            zombieCountText.text = "Zombies: " + zombieCount.ToString();
        }

    void SpawnZombie(int numberOfZombies)
        {
            for (int i = 0; i < numberOfZombies; i++)
            {
                // Define the range for random offsets
                float offsetX = Random.Range(-5f, 5f); 
                float offsetZ = Random.Range(-5f, 5f); 

                // Calculate the spawn position with random offsets
                Vector3 spawnPosition = new Vector3(113f + offsetX, 8.7f, -127f + offsetZ);

                // Spawn zombie at the calculated position
                GameObject zombie = Instantiate(zombiePrefab, spawnPosition, Quaternion.identity);

                // Set the target for the zombie to move towards
                ZombieMovement zombieMovement = zombie.GetComponent<ZombieMovement>();
                if (zombieMovement != null)
                {
                    zombieMovement.SetTarget(targetObject);
                }
            }
        }


    }
}