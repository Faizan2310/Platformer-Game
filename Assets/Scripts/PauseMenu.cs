using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif
public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuUI;


    // Variable to keep track of game state
    private bool isPaused = false;

    void Update(){
        if (Input.GetKeyDown(KeyCode.Escape)) // Check for the pause button press
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume(){
        pauseMenuUI.SetActive(false); // Hide the pause menu
        Time.timeScale = 1f; // Resume normal time flow
        isPaused = false;
    }

    public void Pause(){
        pauseMenuUI.SetActive(true); // Show the pause menu
        Time.timeScale = 0f; // Stop time flow, effectively pausing the game
        isPaused = true;
    }

    public void RestartBtn(){
       isPaused = false;
       Time.timeScale = 1f;
       SceneManager.LoadScene(SceneManager.GetActiveScene().name);
       // Reset Score
       if (ScoreManager.instance != null){
            ScoreManager.instance.ResetScore();
            }
    }

    public void HomeMenuBtn(){
        isPaused = false;
         Time.timeScale = 1f;
        // Reset the Score
        if (ScoreManager.instance != null){
            ScoreManager.instance.ResetScore();
            }
        // Stop the background music 
        if (BackgroundMusic.Instance != null){
            BackgroundMusic.Instance.StopMusic();
        }
        // Load the Scene   
        SceneManager.LoadScene("Scenes/Start Scene");
    }

    public void QuitBtn(){
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Stop playing the scene in the editor
        #else
        Application.Quit();
        #endif
    }

    public void ResumeBtn(){
        pauseMenuUI.SetActive(false); // Hide the pause menu
        Time.timeScale = 1f; // Resume normal time flow
        isPaused = false;
    }

}
