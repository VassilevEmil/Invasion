using System;
using UnityEngine;

namespace SimpleLowPolyNature.Scripts
{
    public class TentCollider : MonoBehaviour
    {
        public int startingGold = 100;

        private ZombiePoolManager _zombiePoolManager;
        private GoldManager _goldManager;
        void Start()
        {
            _zombiePoolManager = FindObjectOfType<ZombiePoolManager>();
            _goldManager = FindObjectOfType<GoldManager>();
#if UNITY_EDITOR
            _goldManager.SetStartingGold(startingGold);
#else
            _goldManager.SetStartingGold(_goldManager.GetCurrentGold());
#endif
        }
        
        void OnTriggerEnter(Collider other)
        { 
            Debug.Log(other.gameObject.name);
            if (other.gameObject.CompareTag("Zombie"))
            {
                Debug.Log("sss");
                ZombieMovement zombieMovement = other.GetComponent<ZombieMovement>();

               
                if (zombieMovement != null)
                {
                  
                    zombieMovement.Die();
                    _zombiePoolManager.DeactivateZombie(other.gameObject);

                    
                    DeductGold(10);

                   
                }
            }
        }

        void DeductGold(int amount)
        {
            if (amount >= 0)
            {
                _goldManager.DeductGold(amount);
            } 
        }
    }
}