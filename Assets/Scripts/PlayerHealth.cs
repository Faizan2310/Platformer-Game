using UnityEngine;
using UnityEngine.UI; // Include the UI namespace to work with UI elements.
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;
    public Image[] hearts; 

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHeartsUI();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        UpdateHeartsUI();

        if (currentHealth <= 0)
        {
           Die();
        }
    }

    void UpdateHeartsUI()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            // If the index is less than the current health, show the heart, else hide it.
            hearts[i].enabled = i < currentHealth;
        }
    }
     void Die(){
        // Disable the MeshRenderer component, effectively making the player invisible
        GetComponent<MeshRenderer>().enabled = false;
        // Set the Rigidbody to kinematic, stopping all physics simulation for the player
        GetComponent<Rigidbody>().isKinematic = true; 
        // Disable the PlayerMovement script, stopping player input handling
        GetComponent<PlayerMovement>().enabled = false;
        //Making the model invisible
        GetComponentInChildren<SkinnedMeshRenderer>().enabled = false; 
        // Call the ReloadLevel method after a delay of 1.4 seconds
        Invoke(nameof(GameOver), 1.4f);
    }

    // This method reloads the current level
    void GameOver(){
        // Load the Game Over scene
        SceneManager.LoadScene("Scenes/End Screen");
    }
}