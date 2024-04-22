using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
 
    public Button playButton;  // Reference to the Play button
    public Button quitButton;  // Reference to the Quit button
    public Button goldButton500;
    public Button saveButton;
    public Button goldButton1000;
    public int startingGold;
    


    void Start()
    {
       
        // Add click listeners to buttons
        playButton.onClick.AddListener(PlayGame);
        quitButton.onClick.AddListener(QuitGame);
        goldButton500.onClick.AddListener(GoldButton500);
        goldButton1000.onClick.AddListener(GoldButton1000);
        saveButton.onClick.AddListener(SaveGane);
        
    }

    public void SaveGane()
    {
        throw new NotImplementedException();
    }
    // Load the game scene
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("DemoDay");
        Debug.Log("Starting the main scene");
    }

    // Quit the game
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("QUitting the game");
    }
    public void GoldButton500()
    {
        GoldManager.SetStartingGoldFromMenu(500);
        PlayGame();
       
    }
    public void GoldButton1000()
    {
        GoldManager.SetStartingGoldFromMenu(1000);
        PlayGame();
       
    }
}
