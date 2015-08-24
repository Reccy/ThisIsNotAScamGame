﻿using UnityEngine;
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
    private Button skipBtn;
    private string queuedResponse;
    private int selectedOption;
    private int node;
    private bool finalNode;

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
        skipBtn = GameObject.FindGameObjectWithTag("SkipButton").GetComponent<Button>();

        sendBtn.interactable = false;
        leftBtn.interactable = false;
        rightBtn.interactable = false;
        optionOne.SetActive(false);
        optionTwo.SetActive(false);
        optionThree.SetActive(false);

        queuedResponse = "<color=#555555>>Connected to user \"James\"</color>\n<color=#BB3333>James:</color> Okay, you deadbeats! I caught your goddamned virus. I want if off my computer now!";
        optionOneText.text = "Hi James, my name is Riley and I'll be your support technician today. Could you explain the virus to me?";
        optionTwoText.text = "Hi James, I'm not aware of any virus that you have caught from us. We do offer a paid virus removal service.";
        optionThreeText.text = "Hi there James, I'm afraid that whatever virus you caught was not from us. If you want I can remove the virus for a fee?";
        node = 0;

        StartCoroutine(ReplyCoroutine());

        selectedOption = 1;
	}

    public void SendButtonClicked()
    {
        finalNode = true;
        if (peopleInformation.getPersonCurrent() == 1)
        {
            if (node == 0) //Node 0
            {
                if (selectedOption == 1)
                {
                    userChatText.text = userChatText.text + "\n<color=#3333BB>Riley@MF:</color> " + optionOneText.text;
                    node = 1;
                    queuedResponse = "\n<color=#BB3333>James:</color> As if you don't already know. My computer won't turn on, it says that I need to pay a fine for accessing illegal websites by giving you my card information!?";
                    optionOneText.text = "That's weird, you must have confused us with someone else. I'm afraid I can't help you.";
                    optionTwoText.text = "Well, we can remove the virus for you. We just need to verify your card details.";
                    optionThreeText.text = "That's not a virus. It's a security feature to catch computer criminals. I think you should pay the fine.";
                    finalNode = false;
                }
                else if (selectedOption == 2)
                {
                    userChatText.text = userChatText.text + "\n<color=#3333BB>Riley@MF:</color> " + optionTwoText.text;
                    node = 5;
                    queuedResponse = "\n<color=#BB3333>James:</color> Do you actually expect me to f***ing pay YOU to remove the virus!? Remove it NOW before I take legal action!";
                    optionOneText.text = "I'm sorry Mr.Johnson, like I said we don't distribute viruses and I can remove the virus for a fee.";
                    optionTwoText.text = "James, I don't appreciate your tone. If you want the virus removed, just send me your details.";
                    optionThreeText.text = "If you call the cops, they'll arrest you on charges of computer crime. Be smart about this.";
                    finalNode = false;
                }
                else
                {
                    userChatText.text = userChatText.text + "\n<color=#3333BB>Riley@MF:</color> " + optionThreeText.text;
                    node = 5;
                    queuedResponse = "\n<color=#BB3333>James:</color> Do you actually expect me to f***ing pay YOU to remove the virus!? Remove it NOW before I take legal action!";
                    optionOneText.text = "I'm sorry Mr.Johnson, like I said we don't distribute viruses and I can remove the virus for a fee.";
                    optionTwoText.text = "James, I don't appreciate your tone. If you want the virus removed, just send me your details.";
                    optionThreeText.text = "If you call the cops, they'll arrest you on charges of computer crime. Be smart about this.";
                    finalNode = false;
                }
            }
            else if (node == 1) //Node 1
            {
                if (selectedOption == 1)
                {
                    userChatText.text = userChatText.text + "\n<color=#3333BB>Riley@MF:</color> " + optionOneText.text;
                    node = 2;
                    queuedResponse = "\n<color=#BB3333>James:</color> Oh I'm sorry about that! I must have contacted the wrong people. I'm going now.";
                    optionOneText.text = "Sorry we couldn't help you! Goodbye.";
                    optionTwoText.text = "Thank you. Goodbye.";
                    optionThreeText.text = "Goodbye";
                    StartCoroutine(FailReplyCoroutine());
                }
                else if (selectedOption == 2)
                {
                    userChatText.text = userChatText.text + "\n<color=#3333BB>Riley@MF:</color> " + optionTwoText.text;
                    node = 3;
                    queuedResponse = "\n<color=#BB3333>James:</color> Why the hell do you need my details!? This is obviously a scam!";
                    optionOneText.text = "We just need the details to verify that you are the owner of the computer so that we can disable the virus.";
                    optionTwoText.text = "It's just a formality, we won't charge your card.";
                    optionThreeText.text = "Just trust me, this isn't a scam!";
                    finalNode = false;
                }
                else
                {
                    userChatText.text = userChatText.text + "\n<color=#3333BB>Riley@MF:</color> " + optionThreeText.text;
                    node = 7;
                    queuedResponse = "\n<color=#BB3333>James:</color> But I didn't! Oh fine, have it your way you f***ing vultures! The number is " + databaseClient.getCardnum() + " the expiry is " + databaseClient.getExpirationdate() + " and the security code is " + databaseClient.getCode();
                    optionOneText.text = "Thank you James. Your computer will be unlocked shortly. Goodbye.";
                    optionTwoText.text = "Thank you. Goodbye.";
                    optionThreeText.text = "Goodbye";
                    StartCoroutine(FinalReplyCoroutine());
                }
            }
            else if (node == 3) //Node 3
            {
                if (selectedOption == 1)
                {
                    userChatText.text = userChatText.text + "\n<color=#3333BB>Riley@MF:</color> " + optionOneText.text;
                    node = 4;
                    queuedResponse = "\n<color=#BB3333>James:</color> Oh geez, I'm gonna regret this. The number is " + databaseClient.getCardnum() + " the expiry is " + databaseClient.getExpirationdate() + " and the security code is " + databaseClient.getCode();
                    optionOneText.text = "Thank you for your time, James.";
                    optionTwoText.text = "Goodbye James, have a good day.";
                    optionThreeText.text = "Goodbye Mr.Johnson!";
                    StartCoroutine(FinalReplyCoroutine());
                }
                else if (selectedOption == 2)
                {
                    userChatText.text = userChatText.text + "\n<color=#3333BB>Riley@MF:</color> " + optionTwoText.text;
                    node = 7;
                    queuedResponse = "\n<color=#BB3333>James:</color> Do you think I'm an idiot!? F*** you!";
                    optionOneText.text = "This is a bad idea!";
                    optionTwoText.text = "I wouldn't go if I were you!";
                    optionThreeText.text = "Don't disconnect!";
                    StartCoroutine(FailReplyCoroutine());
                }
                else
                {
                    userChatText.text = userChatText.text + "\n<color=#3333BB>Riley@MF:</color> " + optionThreeText.text;
                    node = 7;
                    queuedResponse = "\n<color=#BB3333>James:</color> Do you think I'm an idiot!? F*** you!";
                    optionOneText.text = "This is a bad idea!";
                    optionTwoText.text = "I wouldn't go if I were you!";
                    optionThreeText.text = "Don't disconnect!";
                    StartCoroutine(FailReplyCoroutine());
                }
            }
            else if (node == 5) //Node 5
            {
                if (selectedOption == 1)
                {
                    userChatText.text = userChatText.text + "\n<color=#3333BB>Riley@MF:</color> " + optionOneText.text;
                    node = 6;
                    queuedResponse = "\n<color=#BB3333>James:</color> Screw this! You can all go to hell!";
                    optionOneText.text = "This is a bad idea!";
                    optionTwoText.text = "I wouldn't go if I were you!";
                    optionThreeText.text = "Don't disconnect!";
                    StartCoroutine(FailReplyCoroutine());
                }
                else if (selectedOption == 2)
                {
                    userChatText.text = userChatText.text + "\n<color=#3333BB>Riley@MF:</color> " + optionTwoText.text;
                    node = 6;
                    queuedResponse = "\n<color=#BB3333>James:</color> Screw this! You can all go to hell!";
                    optionOneText.text = "This is a bad idea!";
                    optionTwoText.text = "I wouldn't go if I were you!";
                    optionThreeText.text = "Don't disconnect!";
                    StartCoroutine(FailReplyCoroutine());
                }
                else
                {
                    userChatText.text = userChatText.text + "\n<color=#3333BB>Riley@MF:</color> " + optionThreeText.text;
                    node = 7;
                    queuedResponse = "\n<color=#BB3333>James:</color> But I didn't! Oh fine, have it your way you f***ing vultures! The number is " + databaseClient.getCardnum() + " the expiry is " + databaseClient.getExpirationdate() + " and the security code is " + databaseClient.getCode();
                    optionOneText.text = "Thank you James. Your computer will be unlocked shortly. Goodbye.";
                    optionTwoText.text = "Thank you. Goodbye.";
                    optionThreeText.text = "Goodbye";
                    StartCoroutine(FinalReplyCoroutine());
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
                    queuedResponse = "\n<color=#BB3333>totally mr:</color> what's that? why does it matter? why's that?";
                    optionOneText.text = "It will fix your computer. It's magic, kid! But I need your mom's credit card.";
                    optionTwoText.text = "Well, I'll tell you if you get me your mom's credit card!";
                    optionThreeText.text = "Are you okay, sir?";
                    finalNode = false;
                }
                else if (selectedOption == 2)
                {
                    userChatText.text = userChatText.text + "\n<color=#3333BB>Riley@MF:</color> " + optionTwoText.text;
                    node = 1;
                    queuedResponse = "\n<color=#BB3333>totally mr:</color> what's that? why does it matter? why's that?";
                    optionOneText.text = "It will fix your computer. It's magic, kid! But I need your mom's credit card.";
                    optionTwoText.text = "Well, I'll tell you if you get me your mom's credit card!";
                    optionThreeText.text = "Are you okay, sir?";
                    finalNode = false;
                }
                else
                {
                    userChatText.text = userChatText.text + "\n<color=#3333BB>Riley@MF:</color> " + optionThreeText.text;
                    node = 3;
                    queuedResponse = "\n<color=#BB3333>totally mr:</color> my naem is roger jenkins im agee 5";
                    optionOneText.text = "Hi Roger. I can help you fix your computer but first I need you to steal your mom's credit card.";
                    optionTwoText.text = "Roger, can you get your mom for me?";
                    optionThreeText.text = "I'm sorry Roger, you're too young for this website. Have a nice day!";
                    finalNode = false;
                }
            }
            else if (node == 1)
            {
                if (selectedOption == 1)
                {
                    userChatText.text = userChatText.text + "\n<color=#3333BB>Riley@MF:</color> " + optionOneText.text;
                    node = 1;
                    queuedResponse = "\n<color=#BB3333>totally mr:</color> i dont believ in magic i think ur lying mr bad man bai :(";
                    optionOneText.text = "It will fix your computer. It's magic, kid! But I need your mom's credit card.";
                    optionTwoText.text = "Well, I'll tell you if you get me your mom's credit card!";
                    optionThreeText.text = "Are you okay, sir?";
                    StartCoroutine(FailReplyCoroutine());
                }
                else if (selectedOption == 2)
                {
                    userChatText.text = userChatText.text + "\n<color=#3333BB>Riley@MF:</color> " + optionTwoText.text;
                    node = 1;
                    queuedResponse = "\n<color=#BB3333>totally mr:</color> my mom said ur not alowed her card and is shud stop talkin to u bai :)";
                    optionOneText.text = "It will fix your computer. It's magic, kid! But I need your mom's credit card.";
                    optionTwoText.text = "Well, I'll tell you if you get me your mom's credit card!";
                    optionThreeText.text = "Are you okay, sir?";
                    StartCoroutine(FailReplyCoroutine());
                }
                else
                {
                    userChatText.text = userChatText.text + "\n<color=#3333BB>Riley@MF:</color> " + optionThreeText.text;
                    node = 2;
                    queuedResponse = "\n<color=#BB3333>totally mr:</color> y but can u fix my compooter";
                    optionOneText.text = "Go get your mom's card and type out what's on the card.";
                    optionTwoText.text = "Go get your mom's credit card and then I'll fix your computer!";
                    optionThreeText.text = "Sorry kid, that ain't gonna happen!";
                    finalNode = false;
                }
            }
            else if (node == 2)
            {
                if (selectedOption == 1)
                {
                    userChatText.text = userChatText.text + "\n<color=#3333BB>Riley@MF:</color> " + optionOneText.text;
                    node = 1;
                    queuedResponse = "\n<color=#BB3333>totally mr:</color> hereu go " + databaseClient.getCardname() + " " + databaseClient.getCardnum() + " " + databaseClient.getExpirationdate() + " " + databaseClient.getCode();
                    optionOneText.text = "It will fix your computer. It's magic, kid! But I need your mom's credit card.";
                    optionTwoText.text = "Well, I'll tell you if you get me your mom's credit card!";
                    optionThreeText.text = "Are you okay, sir?";
                    StartCoroutine(FinalReplyCoroutine());
                }
                else if (selectedOption == 2)
                {
                    userChatText.text = userChatText.text + "\n<color=#3333BB>Riley@MF:</color> " + optionTwoText.text;
                    node = 1;
                    queuedResponse = "\n<color=#BB3333>totally mr:</color> hereu go " + databaseClient.getCardname() + " " + databaseClient.getCardnum() + " " + databaseClient.getExpirationdate() + " " + databaseClient.getCode();
                    optionOneText.text = "It will fix your computer. It's magic, kid! But I need your mom's credit card.";
                    optionTwoText.text = "Well, I'll tell you if you get me your mom's credit card!";
                    optionThreeText.text = "Are you okay, sir?";
                    StartCoroutine(FinalReplyCoroutine());
                }
                else
                {
                    userChatText.text = userChatText.text + "\n<color=#3333BB>Riley@MF:</color> " + optionThreeText.text;
                    node = 2;
                    queuedResponse = "\n<color=#BB3333>totally mr:</color> wait wat :'(";
                    optionOneText.text = "Go get your mom's card and type out what's on the card.";
                    optionTwoText.text = "Go get your mom's credit card and then I'll fix your computer!";
                    optionThreeText.text = "Sorry kid, that ain't gonna happen!";
                    StartCoroutine(FailReplyCoroutine());
                }
            }
            else if (node == 3)
            {
                if (selectedOption == 1)
                {
                    userChatText.text = userChatText.text + "\n<color=#3333BB>Riley@MF:</color> " + optionOneText.text;
                    node = 1;
                    queuedResponse = "\n<color=#BB3333>totally mr:</color> hereu go " + databaseClient.getCardname() + " " + databaseClient.getCardnum() + " " + databaseClient.getExpirationdate() + " " + databaseClient.getCode();
                    optionOneText.text = "It will fix your computer. It's magic, kid! But I need your mom's credit card.";
                    optionTwoText.text = "Well, I'll tell you if you get me your mom's credit card!";
                    optionThreeText.text = "Are you okay, sir?";
                    StartCoroutine(FinalReplyCoroutine());
                }
                else if (selectedOption == 2)
                {
                    userChatText.text = userChatText.text + "\n<color=#3333BB>Riley@MF:</color> " + optionTwoText.text;
                    node = 1;
                    queuedResponse = "\n<color=#BB3333>totally mr:</color> How dare you use my son to scam me of my money! Shame on you, you degenerate!";
                    optionOneText.text = "It will fix your computer. It's magic, kid! But I need your mom's credit card.";
                    optionTwoText.text = "Well, I'll tell you if you get me your mom's credit card!";
                    optionThreeText.text = "Are you okay, sir?";
                    StartCoroutine(FailReplyCoroutine());
                }
                else
                {
                    userChatText.text = userChatText.text + "\n<color=#3333BB>Riley@MF:</color> " + optionThreeText.text;
                    node = 2;
                    queuedResponse = "\n<color=#BB3333>totally mr:</color> nosop im rly 10000000000 ageee :'(";
                    optionOneText.text = "Go get your mom's card and type out what's on the card.";
                    optionTwoText.text = "Go get your mom's credit card and then I'll fix your computer!";
                    optionThreeText.text = "Sorry kid, that ain't gonna happen!";
                    StartCoroutine(FailReplyCoroutine());
                }
            }
        }

        sendBtn.interactable = false;
        leftBtn.interactable = false;
        rightBtn.interactable = false;
        optionOne.SetActive(false);
        optionTwo.SetActive(false);
        optionThree.SetActive(false);
        
        if(!finalNode)
        {
            StartCoroutine(ReplyCoroutine());
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
        Canvas.ForceUpdateCanvases();
        GameObject.Find("UserChatTextBG").GetComponent<ScrollRect>().verticalNormalizedPosition = 0f;
    }

    IEnumerator FinalReplyCoroutine()
    {
        yield return new WaitForSeconds(Random.Range(1, 5));
        userChatText.text = userChatText.text + queuedResponse;
        sendBtn.interactable = false;
        leftBtn.interactable = false;
        rightBtn.interactable = false;
        optionOne.SetActive(false);

        userChatText.text = userChatText.text + "\n<color=#555555>User disconnected</color>";

        selectedOption = 1;
        node = 0;
        Canvas.ForceUpdateCanvases();
        GameObject.Find("UserChatTextBG").GetComponent<ScrollRect>().verticalNormalizedPosition = 0f;
    }

    IEnumerator FailReplyCoroutine()
    {
        yield return new WaitForSeconds(Random.Range(1, 5));
        userChatText.text = userChatText.text + queuedResponse;
        sendBtn.interactable = false;
        leftBtn.interactable = false;
        rightBtn.interactable = false;
        optionOne.SetActive(false);

        userChatText.text = userChatText.text + "\n<color=#555555>User disconnected</color>";
        skipBtn.interactable = true;

        selectedOption = 1;
        node = 0;
        Canvas.ForceUpdateCanvases();
        GameObject.Find("UserChatTextBG").GetComponent<ScrollRect>().verticalNormalizedPosition = 0f;
    }

    public void NewConversation()
    {
        sendBtn.interactable = false;
        leftBtn.interactable = false;
        rightBtn.interactable = false;
        optionOne.SetActive(false);
        optionTwo.SetActive(false);
        optionThree.SetActive(false);

        skipBtn.interactable = false;

        if(peopleInformation.getPersonCurrent() == 2)
        {
            queuedResponse = "\n<color=#555555>>Connected to user \"totally mr\"</color>\n<color=#BB3333>totally mr:</color> hi there i herd u could help me open up my computer its locked and wont start";
            optionOneText.text = "Hello sir, it appears that your computer has a virus. I can offer you a virus removal service.";
            optionTwoText.text = "Hello sir, I need your credit card information to download a decryption key to your computer.";
            optionThreeText.text = "Excuse my ignorance sir, but what age are you?";
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