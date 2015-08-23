using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DatabaseClientScript : MonoBehaviour {

    private GameObject databaseClient;
    private GameInformation gameInformation;
    private PeopleInformation peopleInformation;
    private Text idText;
    private Text firstnameText;
    private Text surnameText;
    private Text subjectText;
    private string ID;
    private string firstname;
    private string surname;
    private string subject;
    private string cardname;
    private string cardnum;
    private string expirationdate;
    private string code;

	void Start () 
    {
        databaseClient = GameObject.FindGameObjectWithTag("DatabaseClient");
        gameInformation = GameObject.FindGameObjectWithTag("GameInformation").GetComponent<GameInformation>();
        peopleInformation = GameObject.FindGameObjectWithTag("PeopleInformation").GetComponent<PeopleInformation>();
        idText = GameObject.FindGameObjectWithTag("ID").GetComponent<Text>();
        firstnameText = GameObject.FindGameObjectWithTag("Firstname").GetComponent<Text>();
        surnameText = GameObject.FindGameObjectWithTag("Surname").GetComponent<Text>();
        subjectText = GameObject.FindGameObjectWithTag("Subject").GetComponent<Text>();
	}

    public void ExitButtonClicked()
    {
        databaseClient.SetActive(false);
    }

    public void setDetails(string ID, string firstname, string surname, string subject, string cardname, string cardnum, string expirationdate, string code)
    {
        this.ID = ID;
        this.firstname = firstname;
        this.surname = surname;
        this.subject = subject;
        this.cardname = cardname;
        this.cardnum = cardnum;
        this.expirationdate = expirationdate;
        this.code = code;

        idText.text = "Client ID: " + ID;
        firstnameText.text = "Firstname: " + firstname;
        surnameText.text = "Surname: " + surname;
        subjectText.text = "Subject :" + subject;
    }
}
