using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gameover : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] public Text Highscorelvl1;
    [SerializeField] public Text Highscorelvl2;

    CatchScript V;
    CatchScriptLvl2 L;


    void Start()
    {
        V = transform.root.GetComponent<CatchScript>();
        L = transform.root.GetComponent<CatchScriptLvl2>();
        Highscorelvl1.text = PlayerPrefs.GetFloat("HighScorelvl1", 0).ToString();
        Highscorelvl2.text = PlayerPrefs.GetFloat("HighScorelvl2", 0).ToString();
    }


    public void Reset()
    {
        PlayerPrefs.DeleteKey("HighScorelv2");
        PlayerPrefs.DeleteKey("HighScorelvl");
        V.HighscoreWon.text = "0";
        V.HighscoreLost.text = "0";
        L.HighscoreWon.text = "0";
        L.HighscoreLost.text = "0";
    }


}
