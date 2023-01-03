using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] Image SoundOnIcon;
    [SerializeField] Image SoundOffIcon;
    private bool muted = false;

        // Start is called before the first frame update
    void Start()
    {
        if(!PlayerPrefs.HasKey("muted"))
        {
            PlayerPrefs.SetInt("muted", 0);
            Load();
        }
        else
        {
            Load();
        }
        UpdateButtonIcon();
        AudioListener.pause = muted;
    }

    private void UpdateButtonIcon()
    {
        if (muted==false)
        {
            SoundOnIcon.enabled = true;
            SoundOffIcon.enabled = false;
        }
        else
        {
            SoundOnIcon.enabled = false;
            SoundOffIcon.enabled = true;
        }
    }


    public void OnButtonPress() 
    {
        if (muted == false)
        {
            muted = true;
            AudioListener.pause = true;
        }
        else
        {
            muted = false;
            AudioListener.pause = false ;
        }
        Save();
        UpdateButtonIcon();
    }


    private void Load()
    {
        muted = PlayerPrefs.GetInt("muted") == 1;
    }
    private void Save()
    {
        PlayerPrefs.GetInt("muted", muted ? 1 : 0 ) ;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
