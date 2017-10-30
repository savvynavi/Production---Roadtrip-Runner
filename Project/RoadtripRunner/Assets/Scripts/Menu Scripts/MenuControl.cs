using UnityEngine;
using UnityEngine.SceneManagement;

//SCRIPT EFFECT:
//Allows user to play game (Play button), select settings (Settings button), go back to Main Menu from Settings (Back button).

public class MenuControl : MonoBehaviour
{
    public GameObject mainPanel;
    public GameObject settingsPanel;

    void Start()
    {
        mainPanel.SetActive(true);
        settingsPanel.SetActive(false);
    }

    public void Play_OnClick()
    {
        //This loads a test scene. To add a scene, go into File > Build Settings and drop a scene in. Then, put the corresponding number below (first scene is 0, second 1, etc)
        SceneManager.LoadScene(1, LoadSceneMode.Single); 
    }

    public void Settings_OnClick()
    {
        mainPanel.SetActive(false);
        settingsPanel.SetActive(true);
    }

    public void Back_OnClick()
    {
        mainPanel.SetActive(true);
        settingsPanel.SetActive(false);
    }
}
