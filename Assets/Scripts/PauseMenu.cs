using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject PauseMenuUI;
    public GameObject MainMenuUI;
    public tweenStuff tweenBGBlur;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                ShowPauseMenu();
                //tweenBGBlur.TweenBlurValue();
                Invoke("Pause", 0.9f);
            }
        }
    }

    public void Resume()
    {
        MainMenuUI.SetActive(true);
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {                
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    void ShowPauseMenu()
    {
        MainMenuUI.SetActive(false);
        PauseMenuUI.SetActive(true);
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        int buildIndex = 0;
        int y = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadSceneAsync(buildIndex);
        SceneManager.UnloadSceneAsync(y);
        Debug.Log("Cleared Data");
    }
    public void QuitGame()
    {
        Application.Quit();
        
    }
    
}
