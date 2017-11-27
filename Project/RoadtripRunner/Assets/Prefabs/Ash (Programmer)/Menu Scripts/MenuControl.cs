using UnityEngine;
using UnityEngine.SceneManagement;

//SCRIPT EFFECT:
//Allows user to play game (Play button), select settings (Settings button), select upgrades (Upgrades button), go back to Main Menu from Settings and Upgrades (Back button).

public class MenuControl : MonoBehaviour
{
    public string upgradeControlTag = "UpgradeController";          //Set this to whatever the tag for the UpgradeController object is
    private GameObject upgradeControl;

    public GameObject mainPanel;                                    //Drop the panel containing the main menu screen to this variable
    public GameObject settingsPanel;                                //Drop the panel containing the settings screen to this variable
    public GameObject upgradePanel;                                 //Drop the panel containing the upgrades screen to this variable

    public bool audioToggle;

    void Start()
    {
        mainPanel.SetActive(true);
        settingsPanel.SetActive(false);
        upgradePanel.SetActive(false);

        upgradeControl = GameObject.FindGameObjectWithTag(upgradeControlTag);
    }


    #region MenuControl Functions
    public void OnGameEnd()                                         //Call when level has ended, preferably before the scene is closed
    {
        mainPanel.SetActive(true);
        settingsPanel.SetActive(false);
        upgradePanel.SetActive(false);
    }
    #endregion


    #region Main Menu Button Functions
    public void Play_OnClick()
    {
        mainPanel.SetActive(false);
        settingsPanel.SetActive(false);
        upgradePanel.SetActive(false);

        Pause PauseScript = GetComponent<Pause>();
        PauseScript.playing = true;
        PauseScript.lastCurrency = upgradeControl.GetComponent<UpgradeControl>().currency;

        //This loads a test scene. To add a scene, go into File > Build Settings and drop a scene in. Then, put the corresponding number below (first scene is 0, second 1, etc)
        //Note that loadscenemode.additive should be used so that Upgrade functionality is retained. Remember to disable any menu objects/UI above before loading the scene
        SceneManager.LoadScene(1, LoadSceneMode.Additive);
    }

    public void Settings_OnClick()
    {
        mainPanel.SetActive(false);
        settingsPanel.SetActive(true);
    }

    public void Upgrade_OnClick()
    {
        mainPanel.SetActive(false);
        upgradePanel.SetActive(true);
    }

    public void Back_OnClick()
    {
        mainPanel.SetActive(true);
        settingsPanel.SetActive(false);
        upgradePanel.SetActive(false);
    }
    #endregion


    #region Settings Menu Button Functions
    public void Audio_OnToggle()
    {
        audioToggle = !audioToggle;

        //Will be uncommented when sound is implemented
        //if (audioToggle == true)
        //    audioSource.SetActive(true);
        //else
        //    audioSource.SetActive(false);
    }
    #endregion


    #region Upgrade Menu Button Functions
    public void BuyRock_OnClick()
    {
        upgradeControl.GetComponent<UpgradeControl>().rockUpgrade();
    }

    public void BuyPaper_OnClick()
    {
        upgradeControl.GetComponent<UpgradeControl>().paperUpgrade();
    }

    public void BuyScissors_OnClick()
    {
        upgradeControl.GetComponent<UpgradeControl>().scissorsUpgrade();
    }
    #endregion
}