using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class IntroScript : MonoBehaviour {

    private List<string> preList; //List for initial rll-through of commands
    private List<string> introList; //List for initial game screen
    private Text term;

    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter)) { StartCoroutine(bootUp()); }
    }

	void Start () 
    {
        term = GameObject.Find("Terminal").GetComponent<Text>();
        term.text = "\n\n\n\n\n\n\n\n\n\n\n\n\nThis is NOT a Scam!\nBy Aaron Meaney {@theReccy}\n\nPress <ENTER> to begin";

        //Add data to pre list
	    preList = new List<string>();
        preList.Add("POWER GOOD");
        preList.Add("CHECKING FOR VALID OPERATING SYSTEM");
        preList.Add("FOUND WANDISK 97");
        preList.Add("LOADING WANDISK 97");
        preList.Add("FETCHING RESOURCE MANIFEST");
        preList.Add("LOADING OPERATING SYSTEM RESOURCES");
        preList.Add("Hpe5krXx1fsdfs3f3wfvYIkBbX38NB");
        preList.Add("irPQE4pIw3fwfw55ywabCbb7wjTMu");
        preList.Add("W45lj1yzDdbsdfsdAMDVDdVg1");
        preList.Add("FnH3EttXwrjgdgsvz7pSAzfyiC8");
        preList.Add("8hHjIzYMvavasvvc0CE6t6AhxF");
        preList.Add("pvPhkorEXjrtjPkmvz5NsvvT");
        preList.Add("Lk6mdMBwxk9YIdHlwBgB");
        preList.Add("tKfB2WMEEib5262342gQPM1Q4wMpp");
        preList.Add("vA2uOjdgLK4hsbK4m3mOQdB8");
        preList.Add("gJfhD7WS54s2eqVQ8NvWvp");
        preList.Add("oF1QMNWpwegaHzY9GtPQLt");
        preList.Add("xtZ4wPEhTe3tTTTsbx1vZ2lmx0z");
        preList.Add("vrwTu8tRkJcbxcvcsvhbI7Z0u");
        preList.Add("QP0Zu7KZDgdfsdfw0dTrwMIs9");
        preList.Add("SaL0Xuh23WmsdfsIzL3s1EQS");
        preList.Add("9YbLboPGUHsdfNcUzvE2nVp");
        preList.Add("KjOKj73dRwesdfsfsZ8VgLSrsS");
        preList.Add("gsnsHSi4zSv422342424tgsf634pVTgrBKT2L");
        preList.Add("d6yJDDBk423inQ4d9RXP5JH");
        preList.Add("ubVOeRwLSAMmQ5opOUB0");
        preList.Add("RESOURCES LOADED");
        preList.Add("STARTING WANDISK 97...");
	}

    IEnumerator bootUp()
    {
        term.text = preList[0];
        for(int i = 1; i < preList.Count; i++)
        {
            term.text = term.text + "\n" + preList[i];
            yield return new WaitForSeconds(0.04f);
        }
        SceneManager.LoadScene("IntroScene");
    }
}
