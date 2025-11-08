using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] Image soundOnIcon;
    [SerializeField] Image soundOffIcon;
    private bool muted = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //If there is no saved data from previous game session muted is set to false
        if (!PlayerPrefs.HasKey("muted"))
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

    public void OnButtonPress()
    {
        //Turn the background music off when the sound button is pressed and the music is on
        if (muted == false)
        {
            muted = true;
            AudioListener.pause = true;
        }
        else
        {
            //Turn on music when sound button is pressed and the music is already off
            muted = false;
            AudioListener.pause = false;
        }

        Save();
        UpdateButtonIcon();
    }

    private void UpdateButtonIcon()
    {
        if (muted == false)
        {
            soundOnIcon.enabled = true;
            soundOffIcon.enabled = false;
        }
        else
        {
            soundOnIcon.enabled = false;
            soundOffIcon.enabled = true;
        }
    }
    private void Load()
    {
        muted = PlayerPrefs.GetInt("muted") == 1;
    }
    private void Save()
    {
        //If muted == true then it will be saved as 1 or if muted == false then it will be saved as zero
        // as PlayerPrefs can only store int,string and float variables
        PlayerPrefs.SetInt("muted", muted ? 1 : 0);
    }
    
}
