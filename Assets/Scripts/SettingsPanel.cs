using UnityEngine;
using UnityEngine.UI; 

public class SettingsPanel : MonoBehaviour
{
    public Dropdown graphicsDropdown; 
    public Slider volumeSlider;
    
   void Start(){
    // Initialize dropdown selection to current quality level
    graphicsDropdown.value = QualitySettings.GetQualityLevel();
    // Update the dropdown display
    graphicsDropdown.RefreshShownValue();

    // Load the saved volume, default to 1 (full volume) if it hasn't bee saved yet
    float savedVolume = PlayerPrefs.GetFloat("GameVolume", 1f); 
    AudioListener.volume = savedVolume;
    // Update the slider UI
    volumeSlider.value = savedVolume;
    
    volumeSlider.onValueChanged.AddListener(SetVolume);
}

    public void ChangeGraphicsQuality(){
        // Apply the selected quality level
        QualitySettings.SetQualityLevel(graphicsDropdown.value, true);
    }
    public void SetVolume(float volume){
    Debug.Log("Volume set to: " + volume);
    AudioListener.volume = volume;
    PlayerPrefs.SetFloat("GameVolume", volume);
    PlayerPrefs.Save();
    }

}
