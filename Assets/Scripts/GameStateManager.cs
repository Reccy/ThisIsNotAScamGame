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
        GameObject.FindGameObjectWithTag("SupervisorNotice").GetComponent<Text>().text = "<color=#555555>Notice from SUPERVISOR:</color>\n" + GameInformation.pcName + ", this is your first day on the job so don't screw up!\n\nGet the client's card information and input it into our database. If you lose a client (you better not!) then skip onto the next one.\n\nI'll be keeping an eye on you.";
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
