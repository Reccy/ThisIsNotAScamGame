using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Collections;

public class GameStateManager : MonoBehaviour {

    private bool done;
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
        done = false;
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
        if(!done)
        {
            StartCoroutine(srslyBegin());
        }
        else
        {
            SceneManager.LoadScene("EndScene");
        }
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

    public void endGame()
    {
        done = true;
        database.SetActive(false);
        chat.SetActive(false);
        StartCoroutine(reallyEndGame());
    }

    IEnumerator reallyEndGame()
    {
        yield return new WaitForSeconds(2);

        email.SetActive(true);
        Text t = GameObject.FindGameObjectWithTag("SupervisorNotice").GetComponent<Text>();

        switch (GameInformation.peopleScammed)
        {
            case 0:
                t.text = "Did you actually forget how to do your job!?\n\nYou idiot! You lost FIVE CLIENTS!\n\nAre you trying to get fired? It doesn't matter. You're fired.\n\nGet out.";
                break;
            case 1:
                t.text = "You only got one? What the hell happened!? You used to be the best damn scam artist this company has ever seen!\n\nYou're on probation. We'll see if you can keep your job.";
                break;
            case 2:
                t.text = "Looks like you had a bad day.\n\nDon't worry, it's happened to all of us. Better luck tomorrow, eh?";
                break;
            case 3:
                t.text = "Good Job!\n\nIt's good to have you back, " + GameInformation.pcName + "!\n\nI'll see you tomorrow!";
                break;
            case 4:
                t.text = "Impressive!\n\nI missed having you around, nobody can scam quite like you!\n\nMaybe we should send you on vacation more often!";
                break;
            case 5:
                t.text = "A PERFECT DAY!\n\nI don't think that's ever happened before! And on your first day back too!\n\nI'll send you an invitation for the executive party tonight. Don't be late!";
                break;
            default:
                t.text = "<color=#d10f08>cheater</color>";
                break;
        }
    }
}
