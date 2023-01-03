using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class CatchScript : MonoBehaviour
{
    [SerializeField] public Text ScoreText;
    [SerializeField]  public Text ScoreTextWon;
    [SerializeField] public Text ScoreTextLost;
    [SerializeField] public Text HighscoreWon;
    [SerializeField] public Text HighscoreLost;
    public GameObject arCamera;
    public GameObject smoke;
    
    
    public Image[] hearts;
    public Sprite fullheart;
    public Sprite emptyheart;
    float health = 3f; 
    
    public float currentScore = 0f;
    
    public GameObject LostMenuUI;


    void UpdateHealth()
    {
      
        for (int i = 0; i < hearts.Length; i++) {
            if  (i < health )
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
        HighscoreWon.text = PlayerPrefs.GetFloat("HighScorelvl1",0).ToString();
        HighscoreLost.text = PlayerPrefs.GetFloat("HighScorelvl1", 0).ToString();
    }
    
    void Update()
    {
        ScoreText.text = currentScore.ToString();
        ScoreTextWon.text = currentScore.ToString();
        ScoreTextLost.text = currentScore.ToString();

        if (health == 0f)
        {
            FindObjectOfType<AudioManager>().Play("LostUI");
            LostMenuUI.SetActive(true);
            Time.timeScale = 0f;
        }
        
        if(currentScore > PlayerPrefs.GetFloat("HighScorelvl1",0))
        {
         PlayerPrefs.SetFloat("HighScorelvl1", currentScore);
         HighscoreWon.text = PlayerPrefs.GetFloat("HighScorelvl1", 0).ToString();
         HighscoreLost.text = PlayerPrefs.GetFloat("HighScorelvl1", 0).ToString();
        }
           
    }
    public void Catch()
    {
        RaycastHit hit;
        
        if (Physics.Raycast(arCamera.transform.position, arCamera.transform.forward , out hit))
        {
            if (hit.transform.name == "BEE(Clone)")
            {
                FindObjectOfType<AudioManager>().Play("caught");
                Destroy(hit.transform.gameObject);
                Instantiate(smoke, hit.point, Quaternion.LookRotation(hit.normal));
                currentScore+=5 ;
            }
        
        }
        else
        {
            FindObjectOfType<AudioManager>().Play("missed");
            currentScore -= 2;
            health -= 1;
            UpdateHealth();
        }

    }
  

}
