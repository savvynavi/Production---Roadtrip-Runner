using UnityEngine;
using UnityEngine.SceneManagement;

//SCRIPT EFFECT:
//Allows user to play game (Play button), select settings (Settings button), go back to Main Menu from Settings (Back button).

public class MenuControl : MonoBehaviour
{
    public GameObject mainPanel;
    public GameObject settingsPanel;
    public GameObject upgradePanel;
    public bool audioToggle;

    void Start()
    {
        mainPanel.SetActive(true);
        settingsPanel.SetActive(false);
        upgradePanel.SetActive(false);
    }

    public void Play_OnClick()
    {
        mainPanel.SetActive(false);
        settingsPanel.SetActive(false);
        upgradePanel.SetActive(false);
        //This loads a test scene. To add a scene, go into File > Build Settings and drop a scene in. Then, put the corresponding number below (first scene is 0, second 1, etc)
        SceneManager.LoadScene(1, LoadSceneMode.Additive); 
    }

    public void Settings_OnClick()
    {
        mainPanel.SetActive(false);
        settingsPanel.SetActive(true);
    }

    public void SBack_OnClick()
    {
        mainPanel.SetActive(true);
        settingsPanel.SetActive(false);
    }

    public void Upgrade_OnClick()
    {
        mainPanel.SetActive(false);
        upgradePanel.SetActive(true);
    }

    public void UBack_OnClick()
    {
        mainPanel.SetActive(true);
        upgradePanel.SetActive(false);
    }

    public void Audio_OnToggle()
    {
        audioToggle = !audioToggle;

        //Will be uncommented when sound is implemented
        //if (audioToggle == true)
        //    audioSource.SetActive(true);
        //else
        //    audioSource.SetActive(false);
    }
}
