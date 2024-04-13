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