using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Toggle storyToggle;
    public Toggle easyToggle;
    public Toggle normalToggle;
    public Toggle hardToggle;
    public Toggle ultraHardToggle;
    public Button playButton;  // Reference to the Play button
    public Button quitButton;  // Reference to the Quit button
    public Button saveButton;
    public Button gameplayButton;
    public DifficultyLevel difficultyLevel;

    void Start()
    {
        // Add toggle change listeners
        storyToggle.onValueChanged.AddListener((isOn) => ToggleDifficulty(DifficultyLevel.levelOfDifficulty.Story, isOn));
        easyToggle.onValueChanged.AddListener((isOn) => ToggleDifficulty(DifficultyLevel.levelOfDifficulty.Easy, isOn));
        normalToggle.onValueChanged.AddListener((isOn) => ToggleDifficulty(DifficultyLevel.levelOfDifficulty.Normal, isOn));
        hardToggle.onValueChanged.AddListener((isOn) => ToggleDifficulty(DifficultyLevel.levelOfDifficulty.Hard, isOn));
        ultraHardToggle.onValueChanged.AddListener((isOn) => ToggleDifficulty(DifficultyLevel.levelOfDifficulty.UltraHard, isOn));

        // Set the default selected difficulty to 'Story' (true), and others to false
        storyToggle.isOn = true;
        easyToggle.isOn = false;
        normalToggle.isOn = false;
        hardToggle.isOn = false;
        ultraHardToggle.isOn = false;
        
       

        // Add click listeners to buttons
        playButton.onClick.AddListener(PlayGame);
        quitButton.onClick.AddListener(QuitGame);
        saveButton.onClick.AddListener(SaveGame);
        
    }

    // Toggle the difficulty level
    void ToggleDifficulty(DifficultyLevel.levelOfDifficulty difficulty, bool isOn)
    {
        if (isOn)
        {
            DifficultyLevel.SetDifficulty(difficulty);
            Debug.Log("Difficulty set to: " + difficulty);
        }
    }

    // Save the game
    public void SaveGame()
    {
        DifficultyLevel.SaveDifficulty();
        Debug.Log("Game saved.");
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

    
    void Update()
    {
      
    }

   
}
