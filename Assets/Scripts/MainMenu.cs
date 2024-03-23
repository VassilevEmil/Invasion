using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
 
    public Button playButton;  // Reference to the Play button
    public Button quitButton;  // Reference to the Quit button
    public Button goldButton;
    public Button saveButton;


    void Start()
    {
       
        // Add click listeners to buttons
        playButton.onClick.AddListener(PlayGame);
        quitButton.onClick.AddListener(QuitGame);
        goldButton.onClick.AddListener(GoldButton500);
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

    // method for setting the gold at beginning
    public void GoldButton500()
    {
        Debug.Log("");
    }
    
    

   
}
