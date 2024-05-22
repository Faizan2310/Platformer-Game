using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    void Start(){
        // Stop the background music 
        if (BackgroundMusic.Instance != null){
            BackgroundMusic.Instance.StopMusic();
        }
    }

    public void GameOver(){
        Application.Quit();
    }

    public void RestartGame(){
        // Reset the score before restarting the game
        if (ScoreManager.instance != null){
            ScoreManager.instance.ResetScore();
        }
        // Load the initial level scene
        SceneManager.LoadScene("Scenes/Levels/Level1");
    }

    public void HomeScreen(){
        if (ScoreManager.instance != null){
            ScoreManager.instance.ResetScore();
        }
        SceneManager.LoadScene("Scenes/Start Scene");
    }
}
