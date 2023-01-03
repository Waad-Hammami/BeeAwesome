using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CatchScriptLvl2 : MonoBehaviour
{
    [SerializeField] public Text ScoreText;
    [SerializeField] public Text ScoreTextWon;
    [SerializeField] public Text ScoreTextLost;
    [SerializeField] public Text HighscoreWon;
    [SerializeField] public Text HighscoreLost;
    public GameObject arCamera;
    public GameObject smoke;


    public Image[] hearts;
    public Sprite fullheart;
    public Sprite emptyheart;
    float health = 3f;

    

    float waspcount = 0f;
    public float Highscorelvl2 = 0f;
    public float currentScorelvl2 = 0f;
    public GameObject LostMenuUI;


    void UpdateHealth()
    {

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullheart;
            }
            else
            {
                hearts[i].sprite = emptyheart;
            }
        }


    }

    void Start()
    {
        HighscoreWon.text = PlayerPrefs.GetFloat("HighScorelvl2", 0).ToString();
        HighscoreLost.text = PlayerPrefs.GetFloat("HighScorelvl2", 0).ToString();
    }

    void Update()
    {
        ScoreText.text = currentScorelvl2.ToString();
        ScoreTextWon.text = currentScorelvl2.ToString();
        ScoreTextLost.text = currentScorelvl2.ToString();

        if (health == 0)
        {
            FindObjectOfType<AudioManager>().Play("LostUI");
            LostMenuUI.SetActive(true);
            Time.timeScale = 0f;
        }

        if (currentScorelvl2 > PlayerPrefs.GetFloat("HighScorelvl2", 0))
        {
            PlayerPrefs.SetFloat("HighScorelvl2", currentScorelvl2);
            HighscoreWon.text = PlayerPrefs.GetFloat("HighScorelvl2", 0).ToString();
            HighscoreLost.text = PlayerPrefs.GetFloat("HighScorelvl2", 0).ToString();
        }

    }
    public void Catch()
    {
        RaycastHit hit;

        if (Physics.Raycast(arCamera.transform.position, arCamera.transform.forward, out hit))
        {
            if (hit.transform.name == "BEE(Clone)")
            {
                Destroy(hit.transform.gameObject);
                Instantiate(smoke, hit.point, Quaternion.LookRotation(hit.normal));
                currentScorelvl2 += 5;
                FindObjectOfType<AudioManager>().Play("caught");


            }
            else if (hit.transform.name == "wasp(Clone)")
            {
                Destroy(hit.transform.gameObject);
                Instantiate(smoke, hit.point, Quaternion.LookRotation(hit.normal));
                currentScorelvl2 -= 3;
                waspcount++;
                health -= 1;
                UpdateHealth();
                FindObjectOfType<AudioManager>().Play("missed");
            }
            
        }
        else
        {
            FindObjectOfType<AudioManager>().Play("missed");
            currentScorelvl2 -= 2;
            health -= 1;
            UpdateHealth();
        }
    }
}
