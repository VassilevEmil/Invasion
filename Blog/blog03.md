---
title: "Blog 3 Menu and Audio"
author: "Emil Vasilev"
date: "18-03-2024"
version: "0.1"
---


#  Setting up the Menu

My initial thought was to download an asset, but then I decided to create my own custom menu

I started by creating a new scene (Main Menu Scene) and then I created the buttons. After I created

the buttons I did the script for 'Play' and 'Quit' buttons and added the onCLick listener to them.

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
# After that I started to play with the Gameplay button where all the difficulty levels are placed 


    public class DifficultyLevel : MonoBehaviour
    {

    public enum levelOfDifficulty
    {
        Story,
        Easy,
        Normal,
        Hard,
        UltraHard
    }

    // level by default
    public static levelOfDifficulty CurrentDifficulty { get; private set; } = levelOfDifficulty.Easy;

    
    // Save the current difficulty level
    public static void SaveDifficulty()
    {
        PlayerPrefs.SetInt("DifficultyLevel", (int)CurrentDifficulty);
        PlayerPrefs.Save();
        Debug.Log("Difficulty level saved: " + CurrentDifficulty);
    }

    // Load the saved difficulty level
    public static void LoadDifficulty()
    {
        if (PlayerPrefs.HasKey("DifficultyLevel"))
        {
            CurrentDifficulty = (levelOfDifficulty)PlayerPrefs.GetInt("DifficultyLevel");
            Debug.Log("Difficulty level loaded: " + CurrentDifficulty);
        }
        else
        {
            Debug.Log("Difficulty level not found. Using default.");
        }
    }
        public static void SetDifficulty(levelOfDifficulty difficulty)
        {
            CurrentDifficulty = difficulty;
        }
    }


# Setting the Background Audio

For the background audio I used an asset from Unity store.

I set background audios for both, the menu scene and the main scene

    public class AudioManager : MonoBehaviour
    {

    [Header("------------ Audio Source --------------")]
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource sfxSource;

    [Header("---------- Audio Clip ----------------")]
    public AudioClip background;

    private void Start()
    {
    musicSource.clip = background;
    musicSource.Play();
    }
    }

