using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
 
    public Button playButton;  // Reference to the Play button
    public Button quitButton;  // Reference to the Quit button
   


    void Start()
    {
       
        // Add click listeners to buttons
        playButton.onClick.AddListener(PlayGame);
        quitButton.onClick.AddListener(QuitGame);
        
        
    }

    // Toggle the difficulty level
   
    
 

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

    
    void Update()
    {
      
    }

   
}
