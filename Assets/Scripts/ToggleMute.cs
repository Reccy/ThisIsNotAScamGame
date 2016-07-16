using UnityEngine;
using System.Collections;

public class ToggleMute : MonoBehaviour {

    private GameObject audioManager;

	void Start () {
        audioManager = GameObject.FindGameObjectWithTag("AudioManager");
	}
	
	public void TMute ()
    {
        audioManager.GetComponent<AudioManager>().ToggleMute();
        Debug.Log("Toggle Mute!");
    }
}
