using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour {

    public bool playing = false;

    bool paused;
    public GameObject menuCanvas;
    public GameObject pauseCanvas;
    public GameObject upgradeController;

    public string menuCanvasTag = "MenuCanvas";
    public string pauseCanvasTag = "PauseCanvas";
    public string upgradeControlTag = "UpgradeController";

    public int lastCurrency;


    // Use this for initialization
    void Start()
    {
        menuCanvas = GameObject.FindGameObjectWithTag(menuCanvasTag);
        pauseCanvas = GameObject.FindGameObjectWithTag(pauseCanvasTag);
        upgradeController = GameObject.FindGameObjectWithTag(upgradeControlTag);

        pauseCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !paused && playing)
            SetPause(0f, true, true);
        else if (Input.GetKeyDown(KeyCode.Escape) && paused)
            SetPause(1f, false, false);
    }

    public void SetPause(float TimeScale, bool PauseValue, bool PauseCanvasActive)
    {
        Time.timeScale = TimeScale;
        paused = PauseValue;
        pauseCanvas.SetActive(PauseCanvasActive);
    }

    public void Retry_OnClick()
    {
        SceneManager.UnloadSceneAsync(1);
        SceneManager.LoadScene(1, LoadSceneMode.Additive);
        upgradeController.GetComponent<UpgradeControl>().currency = lastCurrency;
        SetPause(1f, false, false);
    }
    public void Menu_OnClick()
    {
        SceneManager.UnloadSceneAsync(1);
        playing = false;
        SetPause(1f, false, false);
        GetComponent<MenuControl>().OnGameEnd();
        GetComponent<MenuControl>().mainCamera.SetActive(true);
    }
}
