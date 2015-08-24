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
    private Text cardnameText;
    private Text cardnumText;
    private Text expirationdateText;
    private Text codeText;
    private Text statusText;
    private InputField cardnameInput;
    private InputField cardnumInput;
    private InputField expirationdateInput;
    private InputField codeInput;
    private Button submitBtn;
    private Button clientBtn;
    private string ID;
    private string firstname;
    private string surname;
    private string subject;
    public string cardname;
    public string cardnum;
    public string expirationdate;
    public string code;

	void Start () 
    {
        databaseClient = GameObject.FindGameObjectWithTag("DatabaseClient");
        gameInformation = GameObject.FindGameObjectWithTag("GameInformation").GetComponent<GameInformation>();
        peopleInformation = GameObject.FindGameObjectWithTag("PeopleInformation").GetComponent<PeopleInformation>();
        idText = GameObject.FindGameObjectWithTag("ID").GetComponent<Text>();
        firstnameText = GameObject.FindGameObjectWithTag("Firstname").GetComponent<Text>();
        surnameText = GameObject.FindGameObjectWithTag("Surname").GetComponent<Text>();
        subjectText = GameObject.FindGameObjectWithTag("Subject").GetComponent<Text>();
        cardnameText = GameObject.FindGameObjectWithTag("Cardname").GetComponent<Text>();
        cardnumText = GameObject.FindGameObjectWithTag("Cardnum").GetComponent<Text>();
        expirationdateText = GameObject.FindGameObjectWithTag("ExpirationDate").GetComponent<Text>();
        codeText = GameObject.FindGameObjectWithTag("Code").GetComponent<Text>();
        statusText = GameObject.FindGameObjectWithTag("Status").GetComponent<Text>();
        cardnameInput = GameObject.FindGameObjectWithTag("CardNameInput").GetComponent<InputField>();
        cardnumInput = GameObject.FindGameObjectWithTag("CardNumberInput").GetComponent<InputField>();
        expirationdateInput = GameObject.FindGameObjectWithTag("ExpirationDateInput").GetComponent<InputField>();
        codeInput = GameObject.FindGameObjectWithTag("SecurityCodeInput").GetComponent<InputField>();
        submitBtn = GameObject.FindGameObjectWithTag("SubmitBtn").GetComponent<Button>();
        clientBtn = GameObject.FindGameObjectWithTag("ClientBtn").GetComponent<Button>();
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
        subjectText.text = "Subject: " + subject;
    }

    public string getCardname()
    {
        return cardname;
    }

    public string getCardnum()
    {
        return cardnum;
    }

    public string getExpirationdate()
    {
        return expirationdate;
    }

    public string getCode()
    {
        return code;
    }

    public void nextDetails()
    {
        peopleInformation.nextPerson();
        statusText.text = "";
        cardnameInput.interactable = true;
        cardnameInput.text = "";
        cardnumInput.interactable = true;
        cardnumInput.text = "";
        expirationdateInput.interactable = true;
        expirationdateInput.text = "";
        codeInput.interactable = true;
        codeInput.text = "";
        submitBtn.interactable = true;
        clientBtn.interactable = false;
    }

    public void autoCorrect()
    {
        cardnameInput.text = getCardname();
        cardnumInput.text = getCardnum();
        expirationdateInput.text = getExpirationdate();
        codeInput.text = getCode();
        statusText.text = "<color=#33BB33>CARD INFORMATION DOWNLOADED!</color>";
        cardnameInput.interactable = false;
        cardnumInput.interactable = false;
        expirationdateInput.interactable = false;
        codeInput.interactable = false;
        submitBtn.interactable = false;
        clientBtn.interactable = true;
        submitBtn.interactable = false;
        GameInformation.peopleScammed++;
        Debug.Log("People Scammed: " + GameInformation.peopleScammed);
    }

    public void verifyDetails()
    {
        int correctNum = 0;

        if(cardnameText.text != cardname)
        {
        }
        else
        {
            correctNum++;
        }

        if (cardnumText.text != cardnum)
        {
        }
        else
        {
            correctNum++;
        }

        if (expirationdateText.text != expirationdate)
        {
        }
        else
        {
            correctNum++;
        }

        if (codeText.text != code)
        {
        }
        else
        {
            correctNum++;
        }

        if(correctNum == 4)
        {
            statusText.text = "<color=#33BB33>CARD INFORMATION ACCEPTED!</color>";
            cardnameInput.interactable = false;
            cardnumInput.interactable = false;
            expirationdateInput.interactable = false;
            codeInput.interactable = false;
            submitBtn.interactable = false;
            clientBtn.interactable = true;
            submitBtn.interactable = false;
            GameInformation.peopleScammed++;
            Debug.Log("People Scammed: " + GameInformation.peopleScammed);
        }
        else
        {
            statusText.text = "<color=#BB3333>CARD INFORMATION DENIED!</color>";
        }
    }
}
