using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {

    public AudioSource fan;
    public AudioClip cliBeepClip, startupBeepClip, programBeepClip, notificationClip;
    private bool mute;
    void Start()
    {
        mute = false;
        DontDestroyOnLoad(this);
    }

    public void PlaySound(string name)
    {
        switch (name) 
        { 
            case "CliBeep":
                GetComponent<AudioSource>().PlayOneShot(cliBeepClip, 0.2f);
                break;
            case "StartupBeep":
                GetComponent<AudioSource>().PlayOneShot(startupBeepClip, 0.4f);
                break;
            case "ProgramBeep":
                GetComponent<AudioSource>().PlayOneShot(programBeepClip, 1);
                break;
            case "Notification":
                GetComponent<AudioSource>().PlayOneShot(notificationClip, 0.6f);
                break;
        }
    }

    public void ToggleMute()
    {
        if(mute)
        {
            GetComponent<AudioSource>().volume = 1;
            fan.volume = 1;
            mute = false;
            Debug.Log("UN-MUTED");
        }
        else
        {
            GetComponent<AudioSource>().volume = 0;
            fan.volume = 0;
            mute = true;
            Debug.Log("MUTED");
        }
    }
}
