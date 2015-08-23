using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ChatClientScript : MonoBehaviour {

    private GameObject chatClient;
    private GameInformation gameInformation;
    private PeopleInformation peopleInformation;
    private Text userChatText;
    private GameObject optionOne;
    private Text optionOneText;
    private GameObject optionTwo;
    private Text optionTwoText;
    private GameObject optionThree;
    private Text optionThreeText;
    private int selectedOption;
    private int node;

	void Start () 
    {
        chatClient = GameObject.FindGameObjectWithTag("ChatClient");
        gameInformation = GameObject.FindGameObjectWithTag("GameInformation").GetComponent<GameInformation>();
        peopleInformation = GameObject.FindGameObjectWithTag("PeopleInformation").GetComponent<PeopleInformation>();
        userChatText = GameObject.FindGameObjectWithTag("UserChatText").GetComponent<Text>();
        optionOne = GameObject.FindGameObjectWithTag("OptionOne");
        optionOneText = optionOne.GetComponent<Text>();
        optionTwo = GameObject.FindGameObjectWithTag("OptionTwo");
        optionTwoText = optionTwo.GetComponent<Text>();
        optionThree = GameObject.FindGameObjectWithTag("OptionThree");
        optionThreeText = optionThree.GetComponent<Text>();
        optionTwo.SetActive(false);
        optionThree.SetActive(false);

        userChatText.text = "<color=#BB3333>James:</color> Hi, my computer won't start up and I was told to contact you to unlock it?";
        optionOneText.text = "Hi James, my name is Riley and I'm here to help you unlock your computer. In order to do this, I need you to provide me with your credit card information.";
        optionTwoText.text = "Alright James, in order to do that I need your credit card information.";
        optionThreeText.text = "Your computer has been locked because you accessed illegal pornography websites. You will need to pay a fine or face prison. I require your credit card information to make this transaction.";
        node = 0;
        
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

    public void SubmitButtonClicked()
    {
        if(peopleInformation.getPersonCurrent() == 1)
        {
            if (node == 0)
            {
                if(selectedOption == 1)
                {
                    userChatText.text = userChatText.text + "\n<color=#3333BB>Riley:</color> " + optionOneText.text;
                    node = 1;
                }
                else if(selectedOption == 2)
                {
                    userChatText.text = userChatText.text + "\n<color=#3333BB>Riley:</color> " + optionTwoText.text;
                    node = 1;
                }
                else
                {
                    userChatText.text = userChatText.text + "\n<color=#3333BB>Riley:</color> " + optionThreeText.text;
                    node = 1;
                }
                
            }
            else if (node == 1)
            {
                if (selectedOption == 1)
                {
                    userChatText.text = userChatText.text + "\n<color=#3333BB>Riley:</color> " + optionOneText.text;
                    node = 0;
                }
                else if (selectedOption == 2)
                {
                    userChatText.text = userChatText.text + "\n<color=#3333BB>Riley:</color> " + optionTwoText.text;
                    node = 0;
                }
                else
                {
                    userChatText.text = userChatText.text + "\n<color=#3333BB>Riley:</color> " + optionThreeText.text;
                    node = 0;
                }
            }
        }
        Canvas.ForceUpdateCanvases();
        GameObject.Find("UserChatTextBG").GetComponent<ScrollRect>().verticalNormalizedPosition = 0f;
    }

    public void ExitButtonClicked()
    {
        chatClient.SetActive(false);
    }
}