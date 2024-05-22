using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    private static BackgroundMusic instance = null;

    public static BackgroundMusic Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject); // Destroy duplicate
            return;
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(this.gameObject); // Persist across scenes
    }

    // Optional: If you ever need to stop the music, you can call this method
    public void StopMusic()
    {
        Destroy(this.gameObject); // Stops the music by destroying the object
    }
}

