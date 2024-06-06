using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public int startingGold;
    

    public void SaveGame()
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
        Debug.Log("Quitting the game");
    }

    public void GoldButton500()
    {
        GoldVarTransport.currentGold=500;
        PlayGame();
    }

    public void GoldButton1000()
    {
        GoldVarTransport.currentGold = 1000;
        PlayGame();
    }
}