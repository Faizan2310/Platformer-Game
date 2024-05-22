using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RespawnGame : MonoBehaviour
{
    public float threshold;
    [SerializeField] private AudioSource fallAudio;
    [SerializeField] private float respawnDelay = 0.5f; // Short delay before respawning

    private bool isFalling = false;

    void FixedUpdate()
    {
        if (transform.position.y < threshold && !isFalling)
        {
            isFalling = true;
            StartCoroutine(RespawnAfterFall());
        }
    }

    // Creating a Delay for Respawn
    IEnumerator RespawnAfterFall()
    {
        fallAudio.Play();
        yield return new WaitForSeconds(respawnDelay);

        //Reset Score
        if (ScoreManager.instance != null){
            ScoreManager.instance.ResetScore();
            }
        // Reset Health
        PlayerPrefs.DeleteKey("PlayerCurrentHealth");
        //Game Over
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
