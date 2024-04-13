using UnityEngine;
using UnityEngine.AI;

namespace SimpleLowPolyNature.Scripts
{
    public class ZombieMovement : MonoBehaviour, Ikillable
    {
        public Vector3 target;
        
        private NavMeshAgent agent;

        void Start()
        {
            agent = GetComponent<NavMeshAgent>();
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

        void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("PlayerProjectile"))
            {
                // Deactivate the collided zombie
                Die();

                // Deactivate the spawned object
                collision.gameObject.SetActive(false);
            }
        }

        public void Die()
        {
            gameObject.SetActive(false); // Deactivate the zombie
        }
    }
}