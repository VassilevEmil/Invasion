using SimpleLowPolyNature.Scripts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour

{
    public GameOverScreen gameOverScreen;
    public TextMeshProUGUI kills;
    public static bool isGameOver = false;

    
    public void GameOver()
    {
        isGameOver = true; 
        if (gameOverScreen != null)
        {
            gameOverScreen.Setup(kills);
        }
        else
        {
            Debug.LogError("gameOverScreen is null in GameOver method.");
        }
    }
}