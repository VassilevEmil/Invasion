using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace SimpleLowPolyNature.Scripts
{
    public class ZombieMovement : MonoBehaviour, Ikillable
    {
        public Vector3 target;
        private ZombiePoolManager _zombiePoolManager;
        private NavMeshAgent agent;

        void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            _zombiePoolManager = FindObjectOfType<ZombiePoolManager>();
        }
        
        private void OnEnable()
        {
            StartCoroutine(LifespanCoroutine());
        }

        void Update()
        {
            if (target != null)
            {
                agent.SetDestination(target);
            }
        }

        public void SetTarget(Transform newTarget)
        {
            target = newTarget.position;
        }
        

        public void Die()
        {
            gameObject.SetActive(false); // Deactivate the zombie
        }
        
        private IEnumerator LifespanCoroutine()
        {
            yield return new WaitForSeconds(105f);
            if (gameObject.activeSelf)
            {
                _zombiePoolManager.DeactivateZombie(gameObject); // Return the zombie to the pool
            }
        }
    }
}