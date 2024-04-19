using UnityEngine;

namespace SimpleLowPolyNature.Scripts
{
    public class TentCollider : MonoBehaviour
    {
        public int startingGold = 100;
        private int currentGold;

        void Start()
        {
            currentGold = startingGold;
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Zombie"))
            {
                
                ZombieMovement zombieMovement = other.GetComponent<ZombieMovement>();

               
                if (zombieMovement != null)
                {
                  
                    zombieMovement.Die();

                    
                    DeductGold(10);

                   
                }
            }
        }

        void DeductGold(int amount)
        {
            currentGold -= amount;

     
        }
    }
}