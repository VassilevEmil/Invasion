using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GoldManager : MonoBehaviour
{
    public static int currentGold { get; private set; } 
    public Text goldText;
    public TextMeshProUGUI goldCountText;

    private void Start()
    {
      
            
        
        UpdateGoldUI();
    }
    public static void SetStartingGold(int startingGold)
    {
        currentGold = startingGold;
        
    }

    public void DeductGold()
    {
        currentGold--;
        UpdateGoldUI();
    }

    void UpdateGoldUI()
    {
       
        goldCountText.text = "Gold: " + currentGold.ToString();
        
    }
    
    
}