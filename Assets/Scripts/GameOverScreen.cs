using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace SimpleLowPolyNature.Scripts
{
    public class GameOverScreen : MonoBehaviour
    {
        public TextMeshProUGUI killsText;
        public GameObject background;
        public void Setup(TextMeshProUGUI kills)
        {
            background.SetActive(true);
            gameObject.SetActive(true);
            killsText.text = kills.ToString() + " Kills";
            Time.timeScale = 0;
        }

        public void restartButton()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("DemoDay");
        }

        public void exitButton()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("MainMenu");
        }
    }
}