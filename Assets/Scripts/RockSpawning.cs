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
                if (_timer >= 0.25f)
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