using System.Collections;
using System.Collections.Generic;
using SimpleLowPolyNature.Scripts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RockCollision : MonoBehaviour
{

    public Text killCountText;
    public GameOverScreen GameOverScreen;
    
    public static int killCount = 0; 

    public int KillCount => killCount; 
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("collision name, " + other.gameObject.name);
        if (other.CompareTag("Zombie"))
        {
            ZombieMovement zombie = other.GetComponent<ZombieMovement>();
            zombie.Die();
            killCount++;
                Debug.Log("Kills:  " + killCount);
                
                UpdateKillsUI();
        }
    }

    void UpdateKillsUI()
    {
        killCountText.text = "Kills: " + killCount.ToString();
    }
}
