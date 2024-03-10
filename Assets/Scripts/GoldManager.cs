using UnityEngine;
using UnityEngine.UI;

public class GoldManager : MonoBehaviour
{
    public static int CurrentGold { get; private set; } = 1000;
    public Text goldText;

    private void Start()
    {
        UpdateGoldUI();
    }

    public void DeductGold(int amount)
    {
        CurrentGold -= amount;
        UpdateGoldUI();
    }

    void UpdateGoldUI()
    {
        if (goldText != null)
        {
            goldText.text = "Gold: " + CurrentGold.ToString();
        }
    }
}