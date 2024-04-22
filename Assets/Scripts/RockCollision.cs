using System.Collections;
using System.Collections.Generic;
using SimpleLowPolyNature.Scripts;
using UnityEngine;

public class RockCollision : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("collision name, " + other.gameObject.name);
        if (other.CompareTag("Zombie"))
        {
            ZombieMovement zombie = other.GetComponent<ZombieMovement>();
            zombie.Die();
        }
    }
}
