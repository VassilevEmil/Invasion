using UnityEngine;
using UnityEngine.AI;

namespace SimpleLowPolyNature.Scripts
{
    public class ZombieMovement : MonoBehaviour, Ikillable
    {
        public Transform target;
        private NavMeshAgent agent;
      //  private GoldManager goldManager;

        void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            // goldManager = FindObjectOfType<GoldManager>();
        }

          void Update()
        {
            if (target != null)
            {
                // Move towards the target
                agent.SetDestination(target.position);
            }
        }

        public void SetTarget(Transform newTarget)
        {
            target = newTarget;
        }

        
        public void Die()
        {
            gameObject.SetActive(false);
        }
    }
}