using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance; // Singleton instance for global access
    
    public int score { get; private set; } // Current score
    private int bestScore; // Best score
    private Text scoreText; // UI Text to display score

    private Text bestScoreText; // UI Text to display BestScore

    void Awake(){
        // Ensure that only one instance of the ScoreManager exists
        if (instance == null){
            instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else if (instance != this){
            Destroy(gameObject);
        }

        bestScore = PlayerPrefs.GetInt("BestScore", 0);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode){
        // Find and update references to the score and best score Text components in the new scene
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        bestScoreText = GameObject.Find("BestScoreText").GetComponent<Text>();
        UpdateScoreText();
        UpdateBestScoreText();
    }

    private void OnDestroy(){
        SceneManager.sceneLoaded -= OnSceneLoaded; // Clean up the delegate to prevent memory leaks
    }

    public void AddScore(int amount){
        score += amount;
        UpdateScoreText();

        if (score > bestScore){
            bestScore = score;
            PlayerPrefs.SetInt("BestScore", bestScore);
            PlayerPrefs.Save();
            UpdateBestScoreText();
        }
    }

    private void UpdateScoreText(){
        if (scoreText != null){
            scoreText.text = "Score: " + score;
        }
    }

    private void UpdateBestScoreText(){
        if (bestScoreText != null){
            bestScoreText.text = "Best Score: " + PlayerPrefs.GetInt("BestScore", 0);
        }
    }

    public void ResetScore(){
        score = 0;
        UpdateScoreText();
    }
     public void SetScore(int score){
        this.score = score;
        UpdateScoreText();
    }
}
