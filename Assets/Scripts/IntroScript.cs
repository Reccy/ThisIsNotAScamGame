using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class IntroScript : MonoBehaviour {

    private List<string> l;
    private Text term;

	void Start () 
    {
        Debug.Log("SCRIPT STARTED");
        term = GameObject.Find("Terminal").GetComponent<Text>();

	    l = new List<string>();
        l.Add("\nGetting OS \"Wandisk 97\"");
        l.Add("\nInitating OS");
        l.Add("\nBooting OS");
        l.Add("\nRunning Custom Script \"adminbackdoor.exe\"");
        l.Add("\nUser RILEY@MF logged in");
        l.Add("\nERROR: No audio driver detected!");
        l.Add("\nRunning \"mf_db.exe\"");
        l.Add("\nRunning \"chat_admin.exe\"");
        l.Add("\nCustom Script Complete");
        l.Add("\n");
        l.Add("\nINSTRUCTION FROM ADMIN");
        l.Add("\n======================");
        l.Add("\nGet the client's card info");
        l.Add("\nInsert it into our database");
        l.Add("\nIf you lose a client, skip the entry");
        l.Add("\nDon't give in to sympathy");
        l.Add("\nYou are the Monster");
        l.Add("\nPRESS <ENTER> TO BEGIN");
        StartCoroutine(bootUp());
	}

    void Update() 
    { 
        if(Input.GetKeyDown("enter") || Input.GetKeyDown("return"))
        {
            Application.LoadLevel("MainScene");
        }
    }

    IEnumerator bootUp()
    {
        Debug.Log("BOOTING");
        yield return new WaitForSeconds(0.5f);
        term.text = term.text + l[0];
        yield return new WaitForSeconds(0.5f);
        term.text = term.text + l[1];
        yield return new WaitForSeconds(0.5f);
        term.text = term.text + l[2];
        yield return new WaitForSeconds(0.5f);
        term.text = term.text + l[3];
        yield return new WaitForSeconds(0.5f);
        term.text = term.text + l[4];
        yield return new WaitForSeconds(0.5f);
        term.text = term.text + l[5];
        yield return new WaitForSeconds(0.5f);
        term.text = term.text + l[6];
        yield return new WaitForSeconds(0.5f);
        term.text = term.text + l[7];
        yield return new WaitForSeconds(0.5f);
        term.text = term.text + l[8];
        yield return new WaitForSeconds(0.5f);
        term.text = term.text + l[9];
        yield return new WaitForSeconds(0.5f);
        term.text = term.text + l[10];
        yield return new WaitForSeconds(0.5f);
        term.text = term.text + l[11];
        yield return new WaitForSeconds(0.5f);
        term.text = term.text + l[12];
        yield return new WaitForSeconds(0.5f);
        term.text = term.text + l[13];
        yield return new WaitForSeconds(0.5f);
        term.text = term.text + l[14];
        yield return new WaitForSeconds(0.5f);
        term.text = term.text + l[15];
        yield return new WaitForSeconds(0.5f);
        term.text = term.text + l[16];
        yield return new WaitForSeconds(0.5f);
        term.text = term.text + l[17];
    }
}
