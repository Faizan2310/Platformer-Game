using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveAndLoad : MonoBehaviour
{
    public void SaveGame(){
        // Save the current score
        PlayerPrefs.SetInt("PlayerScore", ScoreManager.instance.score);
        // Save the name of the current level
        PlayerPrefs.SetString("CurrentLevel", SceneManager.GetActiveScene().name);
        PlayerPrefs.Save();
        Debug.Log($"Game Saved: Score = {ScoreManager.instance.score}, Level = {SceneManager.GetActiveScene().name}");
    }

    public void LoadGame()
    {
        // Load the score
        if (PlayerPrefs.HasKey("PlayerScore"))
        {
            int score = PlayerPrefs.GetInt("PlayerScore");
            // Set the score in your ScoreManager
            ScoreManager.instance.SetScore(score);
        }

        // Load the level
        if (PlayerPrefs.HasKey("CurrentLevel"))
        {
            string levelName = PlayerPrefs.GetString("CurrentLevel");
            SceneManager.LoadScene(levelName);
        }
        else
        {
            // If there is no saved level, load the default start level
            SceneManager.LoadScene("Scenes/ Start Scene"); // Replace with your start level name
        }
    }

    public void ClearSaveData(){
    PlayerPrefs.DeleteKey("PlayerScore");
    PlayerPrefs.DeleteKey("CurrentLevel");
    PlayerPrefs.Save();
    }
}
