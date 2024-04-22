using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GoldManager : MonoBehaviour
{
    public static int currentGold { get; private set; } 
    public TextMeshProUGUI goldCountText;

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
    }
    void UpdateGoldUI()
    {
        goldCountText.text = "Gold: " + currentGold.ToString();
    }
}