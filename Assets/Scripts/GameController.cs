using SimpleLowPolyNature.Scripts;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour

{
    public GameOverScreen GameOverScreen;
    public int kills;

    public void GameOver()
    {
        GameOverScreen.Setup(kills);
    }


}
