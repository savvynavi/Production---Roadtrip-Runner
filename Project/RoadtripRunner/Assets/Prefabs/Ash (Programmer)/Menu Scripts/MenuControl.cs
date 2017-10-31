using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//SCRIPT EFFECT:
//Allows user to play game (Play button), select settings (Settings button), go back to Main Menu from Settings (Back button).

public class MenuControl : MonoBehaviour
{
    public string currencyControllerTag = "CurrencyController";
    public CurrencyManagerScript currencyController;
    public GameObject mainPanel;
    public GameObject settingsPanel;
    public GameObject upgradePanel;
    public Text rockPrice;
    public Text paperPrice;
    public Text scissorsPrice;
    public bool audioToggle;

    void Start()
    {
        mainPanel.SetActive(true);
        settingsPanel.SetActive(false);
        upgradePanel.SetActive(false);

        currencyController = GameObject.FindGameObjectWithTag(currencyControllerTag).GetComponent<CurrencyManagerScript>();
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

    public void BuyRock_OnClick()
    {
        int price = int.Parse(rockPrice.text.Remove(0, 1));
        if (currencyController.currency < price) { return; }

        currencyController.currency -= price;
        rockPrice.text = "$" + price * 2f;

        //CODE FOR IMPROVING POWERUPS GO HERE
    }

    public void BuyPaper_OnClick()
    {
        int price = int.Parse(paperPrice.text.Remove(0, 1));
        if (currencyController.currency < price) { return; }

        currencyController.currency -= price;
        paperPrice.text = "$" + price * 2;

        //CODE FOR IMPROVING POWERUPS GO HERE
    }

    public void BuyScissors_OnClick()
    {
        int price = int.Parse(scissorsPrice.text.Remove(0, 1));
        if (currencyController.currency < price) { return; }

        currencyController.currency -= price;
        scissorsPrice.text = "$" + price * 2;

        //CODE FOR IMPROVING POWERUPS GO HERE
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

    //Call when level has ended, preferably before scene is closed
    public void OnGameEnd()
    {
        mainPanel.SetActive(true);
        settingsPanel.SetActive(false);
        upgradePanel.SetActive(false);
    }
}
