using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace SimpleLowPolyNature.Scripts
{
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
}