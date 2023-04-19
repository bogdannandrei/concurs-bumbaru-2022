using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIConroller : MonoBehaviour
{
    public static UIConroller instance;

    private void Awake()
    {
        instance = this;
    }

    public TMP_Text goldText;
    public GameObject notEnoughMoneyWarning;

    public GameObject levelCompleteScreen, levelFailScreen;

    public GameObject towerButtons;

    public string LevelSelectScene, mainMenuScene;

    public GameObject pauseScreen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            PauseUnpause();
        }
    }

    public void PauseUnpause()
    {
        if(pauseScreen.activeSelf == false)
        {
            pauseScreen.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            pauseScreen.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    public void LevelSelect()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(LevelSelectScene);
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(mainMenuScene);
    }

    public void TryAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(LevelManager.instance.nextLevel);
        
    }
}
