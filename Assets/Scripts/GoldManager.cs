using System;
using SimpleLowPolyNature.Scripts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GoldManager : MonoBehaviour
{
    public TextMeshProUGUI goldCountText;
    public GameOverScreen gameOverScreen;
    public GameController gameController;

    private int gold;

   

    private void Start()
    {
        gold = GoldVarTransport.currentGold;
        Debug.Log(gold);
        UpdateGoldUI();
    }

    

    public int GetCurrentGold()
    {
        return gold;
    }
    
    public void SetStartingGold(int startingGold)
    {
        gold = startingGold;
    }

    public void DeductGold(int amount)
    {
        gold -= amount;
        UpdateGoldUI();

        if (gold == 0)
        {
            gameController.GameOver(); 
        }
    }

    void UpdateGoldUI()
    {
        goldCountText.text = "Gold: " + gold.ToString();
    }
}