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