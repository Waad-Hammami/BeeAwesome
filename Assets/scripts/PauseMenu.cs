using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;


    // Update is called once per frame


    public void Lvl1()
    {   Time.timeScale = 1f;
        SceneManager.LoadScene("ARGame");
        FindObjectOfType<AudioManager>().Play("button");
        
    }

    public void Lvl2()
    {   Time.timeScale = 1f;
        SceneManager.LoadScene("ARGamelevel2");
        FindObjectOfType<AudioManager>().Play("button");
    }

    public void Resume()
    {
        FindObjectOfType<AudioManager>().Play("button");
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

   public void Pause()
    {
        FindObjectOfType<AudioManager>().Play("button");
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        FindObjectOfType<AudioManager>().Play("button");
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
        Debug.Log("Loading Menu ...");
    }

    public void QuitGame()
    {
        FindObjectOfType<AudioManager>().Play("button");
        Debug.Log("Quitting game ...");
        Application.Quit();
    }

    public void SettingMenu()
    {

    }


}