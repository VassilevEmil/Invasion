# Adding 'Game Over' screen and its navigations

I started this with creating a new Ui-Image. In the image i created 2 text fields, one for the game over text and another for the killed zombies count. Then i created 2 buttons, one for restarting the game and another for returning to the main menu.

    public class GameOverScreen : MonoBehaviour
    {
        public TextMeshProUGUI killsText;

        public void Setup(int kills)
        {
            gameObject.SetActive(true);
            killsText.text = kills.ToString() + " Kills";
        }

        public void restartButton()
        {
            SceneManager.LoadScene("DemoDay");
        }

        public void exitButton()
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
# 
    public class GameController : MonoBehaviour

    {
    public GameOverScreen GameOverScreen;
    public int kills;

    public void GameOver()
    {
        GameOverScreen.Setup(kills);
    }


    }

    using SimpleLowPolyNature.Scripts;
    using TMPro;
    using UnityEngine;
    using UnityEngine.UI;

    public class GoldManager : MonoBehaviour
    {
    public static int currentGold { get; private set; }
    public TextMeshProUGUI goldCountText;
    public GameOverScreen gameOverScreen;

    private void Start()
    {
        UpdateGoldUI();
    }

    public static void SetStartingGoldFromMenu(int starttingGold)
    {
        currentGold = starttingGold;
    }

    public int GetCurrentGold()
    {
        return currentGold;
    }
    
    public void SetStartingGold(int startingGold)
    {
        currentGold = startingGold;
    }
    public void DeductGold(int amount)
    {
        currentGold-=amount;
        UpdateGoldUI();

        if (currentGold == 0)
        {
            gameOverScreen.Setup(RockCollision.killCount);
        }
       
    }
    void UpdateGoldUI()
    {
        goldCountText.text = "Gold: " + currentGold.ToString();
    }
}

# tent collider

The logic of the game is as follows: If the player doesnt manage to shoot a zombie, it is going to run towards the Tent game object. In the tent game object, there is a certain amount of gold, and when a zombie collides with the tent, the player loses 10 gold. The game is over when there is no more gold left in the tent.

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

