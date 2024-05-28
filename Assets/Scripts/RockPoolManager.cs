using System.Collections.Generic;
using UnityEngine;

namespace SimpleLowPolyNature.Scripts
{
    public class RockPoolManager : MonoBehaviour
    {
        public GameObject rockPrefab;
        public int poolSize = 10;
        private List<GameObject> rockPool = new List<GameObject>();

        void Start()
        {
            // Initialize the pool with inactive rocks
            for (int i = 0; i < poolSize; i++)
            {
                GameObject rock = Instantiate(rockPrefab);
                rock.SetActive(false);
                rockPool.Add(rock);
            }
        }

        public GameObject SpawnRock(Vector3 position, Quaternion rotation)
        {
            // Find an inactive rock in the pool
            foreach (GameObject rock in rockPool)
            {
                if (!rock.activeSelf)
                {
                    rock.transform.SetPositionAndRotation(position, rotation);
                    rock.SetActive(true);
                    return rock;
                }
            }

            // If no inactive rock is found, create a new one and add it to the pool
            GameObject newRock = Instantiate(rockPrefab, position, rotation);
            rockPool.Add(newRock);
            return newRock;
        }

        public void ReturnRockToPool(GameObject rock)
        {
            rock.SetActive(false);
        }
    }
}