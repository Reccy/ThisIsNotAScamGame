using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ChatClientScript : MonoBehaviour {

    private GameObject chatClient;
    private GameInformation gameInformation;
    private PeopleInformation peopleInformation;
    private DatabaseClientScript databaseClient;
    private Text userChatText;
    private GameObject optionOne;
    private Text optionOneText;
    private GameObject optionTwo;
    private Text optionTwoText;
    private GameObject optionThree;
    private Text optionThreeText;
    private Button leftBtn;
    private Button rightBtn;
    private Button sendBtn;
    private string queuedResponse;
    private int selectedOption;
    private int node;
    private bool gotInfo;

	void Start () 
    {
        chatClient = GameObject.FindGameObjectWithTag("ChatClient");
        gameInformation = GameObject.FindGameObjectWithTag("GameInformation").GetComponent<GameInformation>();
        peopleInformation = GameObject.FindGameObjectWithTag("PeopleInformation").GetComponent<PeopleInformation>();
        databaseClient = GameObject.FindGameObjectWithTag("DatabaseClient").GetComponent<DatabaseClientScript>();
        userChatText = GameObject.FindGameObjectWithTag("UserChatText").GetComponent<Text>();
        optionOne = GameObject.FindGameObjectWithTag("OptionOne");
        optionOneText = optionOne.GetComponent<Text>();
        optionTwo = GameObject.FindGameObjectWithTag("OptionTwo");
        optionTwoText = optionTwo.GetComponent<Text>();
        optionThree = GameObject.FindGameObjectWithTag("OptionThree");
        optionThreeText = optionThree.GetComponent<Text>();
        leftBtn = GameObject.FindGameObjectWithTag("LeftButton").GetComponent<Button>();
        rightBtn = GameObject.FindGameObjectWithTag("RightButton").GetComponent<Button>();
        sendBtn = GameObject.FindGameObjectWithTag("SendButton").GetComponent<Button>();

        sendBtn.interactable = false;
        leftBtn.interactable = false;
        rightBtn.interactable = false;
        optionOne.SetActive(false);
        optionTwo.SetActive(false);
        optionThree.SetActive(false);

        queuedResponse = "<color=#555555>>Connected to user \"James\"</color>\n<color=#BB3333>James:</color> Hi, my computer won't start up and I was told to contact you to unlock it?";
        optionOneText.text = "Hi James, my name is Riley and I'm here to help you unlock your computer. In order to do this, I need you to provide me with your credit card information.";
        optionTwoText.text = "Alright James, in order to do that I need your credit card information.";
        optionThreeText.text = "Your computer has been locked because you accessed illegal pornography websites. You will need to pay a fine or face prison. I require your credit card information to make this transaction.";
        node = 0;

        StartCoroutine(ReplyCoroutine());

        selectedOption = 1;
	}

    public void SendButtonClicked()
    {
        gotInfo = true;
        if (peopleInformation.getPersonCurrent() == 1)
        {
            if (node == 0)
            {
                if (selectedOption == 1)
                {
                    userChatText.text = userChatText.text + "\n<color=#3333BB>Riley@MF:</color> " + optionOneText.text;
                    node = 1;
                    queuedResponse = "\n<color=#BB3333>James:</color> Wait, why do you need my credit card? Why should I pay you?";
                    optionOneText.text = "Well, James. Under the Data Protection Act Section 7-A1 you have to pay a fine for accessing illegal materials. In this case, porn.";
                    optionTwoText.text = "Well, neither of us want to be in this situation. Give me your credit card information or I'll leak this all over the internet!";
                    optionThreeText.text = "I just need your credit card information for verifaction purposes. Your card won't be charged.";
                    gotInfo = false;
                }
                else if (selectedOption == 2)
                {
                    userChatText.text = userChatText.text + "\n<color=#3333BB>Riley@MF:</color> " + optionTwoText.text;
                    node = 1;
                    queuedResponse = "\n<color=#BB3333>James:</color> Wait, why do you need my credit card? Why should I pay you?";
                    optionOneText.text = "Well, James. Under the Data Protection Act Section 7-A1 you have to pay a fine for accessing illegal materials. In this case, porn.";
                    optionTwoText.text = "Well, neither of us want to be in this situation. Give me your credit card information or I'll leak this all over the internet!";
                    optionThreeText.text = "I just need your credit card information for verifaction purposes. Your card won't be charged.";
                    gotInfo = false;
                }
                else
                {
                    userChatText.text = userChatText.text + "\n<color=#3333BB>Riley@MF:</color> " + optionThreeText.text;
                    node = 1;
                    queuedResponse = "\n<color=#BB3333>James:</color> What the f*** are you talking about? I wasn't on any illegal porn websites!";
                    optionOneText.text = "Our monitoring systems seem to suggest otherwise. We wouldn't want that information to leak onto the internet, would we?";
                    optionTwoText.text = "That is irrelevant. You will go to prison unless you pay the fine. We can do this the easy way or the hard way.";
                    optionThreeText.text = "We have records, Mr. Johnson. I think the Federal Bureau of Investigation would be interested in these. Now, the card info?";
                    gotInfo = false;
                }
            }
            else if (node == 1)
            {
                if (selectedOption == 1)
                {
                    userChatText.text = userChatText.text + "\n<color=#3333BB>Riley@MF:</color> " + optionOneText.text;
                    node = 2;
                    queuedResponse = "\n<color=#BB3333>James:</color> Okay, Fine! Here's my details: " + databaseClient.getCardname() + " Number:" + databaseClient.getCardnum() + " Expiry:" + databaseClient.getExpirationdate() + " Code:" + databaseClient.getCode();
                    optionOneText.text = "Thank you James. Your computer will be unlocked shortly. Goodbye.";
                    optionTwoText.text = "Thank you. Goodbye.";
                    optionThreeText.text = "Goodbye";
                    gotInfo = false;
                }
                else if (selectedOption == 2)
                {
                    userChatText.text = userChatText.text + "\n<color=#3333BB>Riley@MF:</color> " + optionTwoText.text;
                    node = 2;
                    queuedResponse = "\n<color=#BB3333>James:</color> Okay, Fine! Here's my details: " + databaseClient.getCardname() + " Number:" + databaseClient.getCardnum() + " Expiry:" + databaseClient.getExpirationdate() + " Code:" + databaseClient.getCode();
                    optionOneText.text = "Thank you James. Your computer will be unlocked shortly. Goodbye.";
                    optionTwoText.text = "Thank you. Goodbye.";
                    optionThreeText.text = "Goodbye";
                    gotInfo = false;
                }
                else
                {
                    userChatText.text = userChatText.text + "\n<color=#3333BB>Riley@MF:</color> " + optionThreeText.text;
                    node = 2;
                    queuedResponse = "\n<color=#BB3333>James:</color> Okay, Fine! Here's my details: " + databaseClient.getCardname() + " Number:" + databaseClient.getCardnum() + " Expiry:" + databaseClient.getExpirationdate() + " Code:" + databaseClient.getCode();
                    optionOneText.text = "Thank you James. Your computer will be unlocked shortly. Goodbye.";
                    optionTwoText.text = "Thank you. Goodbye.";
                    optionThreeText.text = "Goodbye";
                    gotInfo = false;
                }
            }
        }
        else if (peopleInformation.getPersonCurrent() == 2)
        {
            if (node == 0)
            {
                if (selectedOption == 1)
                {
                    userChatText.text = userChatText.text + "\n<color=#3333BB>Riley@MF:</color> " + optionOneText.text;
                    node = 1;
                    queuedResponse = "\n<color=#BB3333>Name:</color> Dialogue?";
                    optionOneText.text = "Option One";
                    optionTwoText.text = "Option Two";
                    optionThreeText.text = "Option Three";
                    gotInfo = false;
                }
                else if (selectedOption == 2)
                {
                    userChatText.text = userChatText.text + "\n<color=#3333BB>Riley@MF:</color> " + optionOneText.text;
                    node = 1;
                    queuedResponse = "\n<color=#BB3333>Name:</color> Dialogue?";
                    optionOneText.text = "Option One";
                    optionTwoText.text = "Option Two";
                    optionThreeText.text = "Option Three";
                    gotInfo = false;
                }
                else
                {
                    userChatText.text = userChatText.text + "\n<color=#3333BB>Riley@MF:</color> " + optionOneText.text;
                    node = 1;
                    queuedResponse = "\n<color=#BB3333>Name:</color> Dialogue?";
                    optionOneText.text = "Option One";
                    optionTwoText.text = "Option Two";
                    optionThreeText.text = "Option Three";
                    gotInfo = false;
                }
            }
        }

        sendBtn.interactable = false;
        leftBtn.interactable = false;
        rightBtn.interactable = false;
        optionOne.SetActive(false);
        optionTwo.SetActive(false);
        optionThree.SetActive(false);
        
        if(!gotInfo)
        {
            StartCoroutine(ReplyCoroutine());
        }
        else
        {
            if(selectedOption == 1)
            {
                userChatText.text = userChatText.text + "\n<color=#3333BB>Riley@MF:</color> " + optionOneText.text;
                userChatText.text = userChatText.text + "\n<color=#555555>User disconnected</color>";
            }
            else if(selectedOption == 2)
            {
                userChatText.text = userChatText.text + "\n<color=#3333BB>Riley@MF:</color> " + optionTwoText.text;
                userChatText.text = userChatText.text + "\n<color=#555555>User disconnected</color>";
            }
            else
            {
                userChatText.text = userChatText.text + "\n<color=#3333BB>Riley@MF:</color> " + optionThreeText.text;
                userChatText.text = userChatText.text + "\n<color=#555555>User disconnected</color>";
            }
            node = 0;
        }
        
        Canvas.ForceUpdateCanvases();
        GameObject.Find("UserChatTextBG").GetComponent<ScrollRect>().verticalNormalizedPosition = 0f;
    }

    IEnumerator ReplyCoroutine()
    {
        yield return new WaitForSeconds(Random.Range(1, 5));
        userChatText.text = userChatText.text + queuedResponse;
        sendBtn.interactable = true;
        leftBtn.interactable = true;
        rightBtn.interactable = true;
        optionOne.SetActive(true);
        selectedOption = 1;
    }

    public void NewConversation()
    {
        sendBtn.interactable = false;
        leftBtn.interactable = false;
        rightBtn.interactable = false;
        optionOne.SetActive(false);
        optionTwo.SetActive(false);
        optionThree.SetActive(false);

        if(peopleInformation.getPersonCurrent() == 2)
        {
            queuedResponse = "\n<color=#555555>>Connected to user \"James\"</color>\n<color=#BB3333>James:</color> Hi, my computer won't start up and I was told to contact you to unlock it?";
            optionOneText.text = "Hi James, my name is Riley and I'm here to help you unlock your computer. In order to do this, I need you to provide me with your credit card information.";
            optionTwoText.text = "Alright James, in order to do that I need your credit card information.";
            optionThreeText.text = "Your computer has been locked because you accessed illegal pornography websites. You will need to pay a fine or face prison. I require your credit card information to make this transaction.";
            node = 0;
        }
        else if(peopleInformation.getPersonCurrent() == 3)
        {

        }

        StartCoroutine(ReplyCoroutine());

        selectedOption = 1;
    }

    public void NextButtonClicked()
    {
        if (selectedOption == 1)
        {
            optionOne.SetActive(false);
            optionTwo.SetActive(true);
            selectedOption = 2;
        }
        else if (selectedOption == 2)
        {
            optionTwo.SetActive(false);
            optionThree.SetActive(true);
            selectedOption = 3;
        }
        else
        {
            optionThree.SetActive(false);
            optionOne.SetActive(true);
            selectedOption = 1;
        }
    }

    public void PrevButtonClicked()
    {
        if (selectedOption == 1)
        {
            optionOne.SetActive(false);
            optionThree.SetActive(true);
            selectedOption = 3;
        }
        else if (selectedOption == 2)
        {
            optionTwo.SetActive(false);
            optionOne.SetActive(true);
            selectedOption = 1;
        }
        else
        {
            optionThree.SetActive(false);
            optionTwo.SetActive(true);
            selectedOption = 2;
        }
    }

    public void ExitButtonClicked()
    {
        chatClient.SetActive(false);
    }
}