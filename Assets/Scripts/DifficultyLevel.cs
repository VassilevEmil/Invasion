using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
