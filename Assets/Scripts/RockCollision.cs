using System.Collections;
using System.Collections.Generic;
using SimpleLowPolyNature.Scripts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RockCollision : MonoBehaviour
{
    public TextMeshProUGUI killCountText;
    public GameOverScreen gameOverScreen;
    public RockPoolManager rockPoolManager; // Reference to the RockPoolManager

    public static int killCount = 0;
    
    public int KillCount => killCount;

    public float lifespan = 5f; // Lifespan of the projectile in seconds
    private float timer; // Timer to track the lifespan

    public void Init(RockPoolManager rockPoolManager, TextMeshProUGUI killCountText)
    {
        this.rockPoolManager = rockPoolManager;
        timer = lifespan; // Initialize the timer
        this.killCountText = killCountText;
    }

    void Update()
    {
        // Decrement the timer
        timer -= Time.deltaTime;

        // Check if the rock is out of bounds
        if (timer <= 0)
        {
            rockPoolManager.ReturnRockToPool(gameObject); // Return the rock to the pool if it goes out of bounds or the timer expires

        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("collision name, " + other.gameObject.name);
        if (other.CompareTag("Zombie"))
        {
            ZombieMovement zombie = other.GetComponent<ZombieMovement>();
            if (zombie != null)
            {
                zombie.Die();
                killCount++;
                Debug.Log("Kills:  " + killCount);
                UpdateKillsUI();

                // Return the rock to the pool
                rockPoolManager.ReturnRockToPool(gameObject);
            }
        }
    }

    void UpdateKillsUI()
    {
        killCountText.text = "Kills: " + killCount.ToString();
    }
}