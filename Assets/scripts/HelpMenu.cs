using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpMenu : MonoBehaviour
{
    public GameObject helpMenuUI;
    public static bool GameIsPaused = false;

    // Update is called once per frame



    public void CloseHelp()
    {
        FindObjectOfType<AudioManager>().Play("button");
        helpMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    public void Help()
    {
        FindObjectOfType<AudioManager>().Play("button");
        helpMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = false;
    }
}
