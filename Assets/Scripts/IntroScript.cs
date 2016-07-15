using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class IntroScript : MonoBehaviour {

    private List<string> preList; //List for initial rll-through of commands
    private List<string> introList; //List for initial game screen
    private Text term; //Terminal output
    private bool bootingUp; //If the bootup sequence has activated

    void Update ()
    {
        if (bootingUp && (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))) { SceneManager.LoadScene("IntroScene"); } //Skips bootup sequence
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter)) { StartCoroutine(bootUp()); } //Starts bootup sequence
    }

	void Start () 
    {
        term = GameObject.Find("Terminal").GetComponent<Text>();
        term.text = "\n\n\n\n\n\n\n\n\n\n\n\n\nThis is NOT a Scam!\nBy Aaron Meaney {@theReccy}\n\nPress <ENTER> to begin";

        //Add data to pre list
	    preList = new List<string>();
        preList.Add("UNITY VM STARTED"); //0
        preList.Add("CHECKING FOR VALID OPERATING SYSTEM"); //1
        preList.Add("FOUND WANDISK 97"); //2
        preList.Add("LOADING WANDISK 97"); //3
        preList.Add("FETCHING RESOURCE MANIFEST"); //4
        preList.Add("LOADING DRIVERS");
        preList.Add("LOADING gfx.drv");
        preList.Add("LOADING sound.drv");
        preList.Add("LOADING net.drv");
        preList.Add("LOADING io.drv");
        preList.Add("LOADING print.drv");
        preList.Add("DONE\n");
        preList.Add("LOADING STARTUP PROGRAMS"); //12
        preList.Add("wan_crack.exe");
        preList.Add(">Bypassing authentication process"); //14
        preList.Add(">DONE");
        preList.Add("ssh_host.exe");
        preList.Add(">Starting SSH on localhost:443"); //17
        preList.Add(">DONE");
        preList.Add("macrofirm_access.exe");
        preList.Add("Accessing MacroFirm Customer Support Server"); //20
        preList.Add(">DONE");
        preList.Add("RESOURCES LOADED");
        preList.Add("VERIFYING STARTUP CONDITIONS"); //23
        preList.Add("STARTUP COMPLELTE");
        preList.Add("SWITCHING ENVIRONMENT: WANDISK 97"); //24
	}

    IEnumerator bootUp()
    {
        bootingUp = true;
        term.text = preList[0];
        for(int i = 1; i < preList.Count; i++)
        {
            Debug.Log(i);
            term.text = term.text + "\n" + preList[i];
            switch (i) 
            {
                case 1:
                    yield return new WaitForSeconds(0.6f);
                    break;
                case 2:
                    yield return new WaitForSeconds(0.8f);
                    break;
                case 3:
                    yield return new WaitForSeconds(0.5f);
                    break;
                case 4:
                    yield return new WaitForSeconds(0.3f);
                    break;
                case 12:
                    yield return new WaitForSeconds(0.8f);
                    break;
                case 14:
                    yield return new WaitForSeconds(0.3f);
                    break;
                case 20:
                    yield return new WaitForSeconds(0.8f);
                    break;
                case 23:
                    yield return new WaitForSeconds(0.5f);
                    break;
                case 25:
                    yield return new WaitForSeconds(2f);
                    break;
                default:
                    yield return new WaitForSeconds(0.05f);
                    break;
            }
        }
        SceneManager.LoadScene("MainScene");
    }
}
