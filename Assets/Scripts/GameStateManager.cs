using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class GameStateManager : MonoBehaviour {

    private bool loggedIn;
    private GameObject database;
    private GameObject login;
    private GameObject chat;
    private GameObject taskbar;
    private GameObject build;
    private GameObject email;
    private GameObject usernameField;
    private PeopleInformation people;

	void Start () {
        loggedIn = false;
        database = GameObject.FindGameObjectWithTag("DatabaseClient");
        login = GameObject.FindGameObjectWithTag("LoginClient");
        chat = GameObject.FindGameObjectWithTag("ChatClient");
        taskbar = GameObject.FindGameObjectWithTag("BottomTaskbar");
        build = GameObject.FindGameObjectWithTag("BuildText");
        email = GameObject.FindGameObjectWithTag("EmailClient");
        usernameField = GameObject.FindGameObjectWithTag("Username");
        people = GameObject.FindGameObjectWithTag("PeopleInformation").GetComponent<PeopleInformation>();

        database.SetActive(false);
        login.SetActive(false);
        chat.SetActive(false);
        taskbar.SetActive(false);
        email.SetActive(false);
        build.SetActive(false);

        StartCoroutine(startUp());
	}
	
	IEnumerator startUp()
    {
        yield return new WaitForSeconds(2.4f);
        taskbar.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        build.SetActive(true);
        yield return new WaitForSeconds(0.8f);
        login.SetActive(true);
        login.GetComponentInChildren<InputField>().Select();
    }

    public void startGame()
    {
        if(!ConsistsOfWhiteSpace(usernameField.GetComponent<Text>().text))
        {
            StartCoroutine(begin());
        }
        else
        {
            //Play warning sound
        }
    }

    //Credits to "jamora": http://answers.unity3d.com/questions/559715/if-string-only-contains-spaces.html
    private bool ConsistsOfWhiteSpace(string s)
    {
        foreach (char c in s)
        {
            if (c != ' ') return false;
        }
        return true;
    }

    IEnumerator begin()
    {
        GameInformation.pcName = usernameField.GetComponent<Text>().text.Trim();
        login.SetActive(false);
        yield return new WaitForSeconds(1f);
        email.SetActive(true);
        GameObject.FindGameObjectWithTag("SupervisorNotice").GetComponent<Text>().text = "Welcome back, " + GameInformation.pcName + "!\nI hope you enjoyed your vacation! Don't get annoyed, but protocol insists I have to remind you how to do your job.\n\n\"Scam the client. Put their information into our database. Skip the entry if they disconnect.\"\n\nI'll see you later!";
    }

    public void srslyStart()
    {
        StartCoroutine(srslyBegin());
    }

    IEnumerator srslyBegin()
    {
        email.SetActive(false);
        yield return new WaitForSeconds(1.2f);
        chat.SetActive(true);
        chat.GetComponent<ChatClientScript>().Begin();
        yield return new WaitForSeconds(0.3f);
        database.SetActive(true);
        people.Begin();
    }
}
