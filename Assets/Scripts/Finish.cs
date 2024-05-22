using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    public string playerTag = "Player";
    [SerializeField] private AudioSource sceneAudio;

    // The name of the scene you want to load after crossing the finish line

    private void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object has the correct tag
        if (other.CompareTag(playerTag))
        {
            // Play the audio clip
            sceneAudio.Play();

            // Start a coroutine to load the next scene after the audio clip finishes
            StartCoroutine(LoadSceneAfterAudio(sceneAudio.clip.length));
        }
    }

    private IEnumerator LoadSceneAfterAudio(float delay)
    {
        // Wait for the length of the audio clip
        yield return new WaitForSeconds(delay);

        // Load the next scene
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = (currentSceneIndex + 1) % SceneManager.sceneCountInBuildSettings;
        
        SceneManager.LoadScene(nextSceneIndex);
    }
}
