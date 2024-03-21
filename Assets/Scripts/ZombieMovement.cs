using UnityEngine;
using UnityEngine.AI;

namespace SimpleLowPolyNature.Scripts
{
    public class ZombieMovement : MonoBehaviour
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

        // private void OnCollisionEnter(Collision collision)
        // {
        //     if (collision.gameObject.CompareTag("TargetObject"))
        //     {
        //         // Deduct gold and destroy the zombie
        //         goldManager.DeductGold(5);
        //         Destroy(gameObject);
        //     }
        // }
    }
}