using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public void OpenLevel(int levelId)
    {   
        string levelName = "Scenes/Levels/Level" + levelId;
        SceneManager.LoadScene(levelName);
    }
}
