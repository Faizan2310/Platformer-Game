using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    [SerializeField] private GameObject settingsMenuUI;
    [SerializeField] private GameObject levelsPanelUI;
    [SerializeField] private GameObject infoPanelUI;

    public void LoadGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void SettingsBtn(){
        settingsMenuUI.SetActive(true);
    }
    public void CancelBtn(){
        settingsMenuUI.SetActive(false);
    }
    public void LevelBtn(){
        levelsPanelUI.SetActive(true);
    }
    public void CloseLvl(){
        levelsPanelUI.SetActive(false);
    }
    public void InfoBtn(){
        infoPanelUI.SetActive(true);
    }
    public void CloseInfo(){
        infoPanelUI.SetActive(false);
    }
    

}
