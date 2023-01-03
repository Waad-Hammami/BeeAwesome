using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownTimer : MonoBehaviour {

	public GameObject WonUI;
	float currentTime = 0f;
	float startingTime = 30f ;
	
	
	[SerializeField] Text countDownText;


	// Use this for initialization
	void Start () {
		
		currentTime = startingTime;
	}
	
	// Update is called once per frame
	void Update () {
		
		currentTime -= 1 * Time.deltaTime ;
		countDownText.text = currentTime.ToString("0") ;
		
		if(currentTime <= 10.0f)
		{
			FindObjectOfType<AudioManager>().Play("timer");
			countDownText.color = Color.red;
		}

		if (currentTime <= 0 )
		{
			FindObjectOfType<AudioManager>().Play("WonUI");
			currentTime = 0;
			WonUI.SetActive(true);
			Time.timeScale = 0f;

		}
		
	}

}
