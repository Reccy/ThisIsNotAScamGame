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
	}

    public void Begin()
    {
        queuedResponse = "<color=#555555>>Connected to user \"James\"</color>\n<color=#BB3333>James:</color> I caught your damn ransomware virus. Get it off my computer RIGHT NOW!";
        optionOneText.text = "Hello James, my name is " + GameInformation.pcName + " and I'll be your support representative today. Could you please explain the virus to me?";
        optionTwoText.text = "Hello James. MacroFirm do not distribute any viruses, so this virus could not be from us. We do offer a paid virus removal service, would you be interested?";
        optionThreeText.text = "Hello James, I'm afraid that whatever virus you caught was not from us. If you want I can remove the virus for a fee?";
        node = 0;

        StartCoroutine(ReplyCoroutine());
        selectedOption = 1;
    }

    public void SendButtonClicked()
    {
        finalNode = true;
        if (peopleInformation.getPersonCurrent() == 1) //Character 1
        {
            if (node == 0) //Node 0
            {
                if (selectedOption == 1)
                {
                    userChatText.text = userChatText.text + "\n<color=#3333BB>" + GameInformation.pcName + "@MF:</color> " + optionOneText.text;
                    node = 1;
                    queuedResponse = "\n<color=#BB3333>James:</color> You're going to play dumb? Fine. My computer won't let me login. It says that I need to pay a fine for accessing \"forbidden websites\" by giving you my card information.";
                    optionOneText.text = "That couldn't have been from us; you must have confused us with someone else. Sorry James, I'm afraid I can't help you. Goodbye.";
                    optionTwoText.text = "Don't worry, we can remove the virus for you! We just need to verify your card details.";
                    optionThreeText.text = "That's not a virus. This is a security program to catch cyber criminals. I think you should pay the fine, if you don't want to go to jail.";
                    finalNode = false;
                }
                else if (selectedOption == 2)
                {
                    userChatText.text = userChatText.text + "\n<color=#3333BB>" + GameInformation.pcName + "@MF:</color> " + optionTwoText.text;
                    node = 5;
                    queuedResponse = "\n<color=#BB3333>James:</color> Do you actually expect me to pay YOU to remove the virus!? Remove it NOW before I get the cops!";
                    optionOneText.text = "I'm sorry James, like I said we don't distribute viruses and I can remove the virus for a fee.";
                    optionTwoText.text = "James, I don't appreciate your tone. If you want the virus removed, send me your details.";
                    optionThreeText.text = "If you call the cops, they'll arrest you on charges of cyber crime. Be smart about this.";
                    finalNode = false;
                }
                else
                {
                    userChatText.text = userChatText.text + "\n<color=#3333BB>" + GameInformation.pcName + "@MF:</color> " + optionThreeText.text;
                    node = 5;
                    queuedResponse = "\n<color=#BB3333>James:</color> Do you actually expect me to pay YOU to remove the virus!? Remove it NOW before I get the cops!";
                    optionOneText.text = "I'm sorry James, like I said we don't distribute viruses and I can remove the virus for a fee.";
                    optionTwoText.text = "James, I don't appreciate your tone. If you want the virus removed, send me your details.";
                    optionThreeText.text = "If you call the cops, they'll arrest you on charges of cyber crime. Be smart about this.";
                    finalNode = false;
                }
            }
            else if (node == 1) //Node 1
            {
                if (selectedOption == 1)
                {
                    userChatText.text = userChatText.text + "\n<color=#3333BB>" + GameInformation.pcName + "@MF:</color> " + optionOneText.text;
                    node = 2;
                    queuedResponse = "\n<color=#BB3333>James:</color> Oh I'm sorry about that! I must have contacted the wrong people. Goodbye.";
                    optionOneText.text = "Sorry we couldn't help you! Goodbye.";
                    optionTwoText.text = "Thank you. Goodbye.";
                    optionThreeText.text = "Goodbye";
                    StartCoroutine(FailReplyCoroutine());
                }
                else if (selectedOption == 2)
                {
                    userChatText.text = userChatText.text + "\n<color=#3333BB>" + GameInformation.pcName + "@MF:</color> " + optionTwoText.text;
                    node = 3;
                    queuedResponse = "\n<color=#BB3333>James:</color> Why the hell do you need my details!? This is obviously a scam!";
                    optionOneText.text = "We just need the details to verify that you are the owner of the computer so that we can disable the virus.";
                    optionTwoText.text = "It's just protocol, we won't charge your card.";
                    optionThreeText.text = "Trust me: This is NOT a scam!";
                    finalNode = false;
                }
                else
                {
                    userChatText.text = userChatText.text + "\n<color=#3333BB>" + GameInformation.pcName + "@MF:</color> " + optionThreeText.text;
                    node = 7;
                    queuedResponse = "\n<color=#BB3333>James:</color> But I didn't do anything wrong! How can you live with yourself!? The number is " + databaseClient.getCardnum() + " the expiry is " + databaseClient.getExpirationdate() + " and the security code is " + databaseClient.getCode();
                    optionOneText.text = "Thank you James. Your computer will be unlocked shortly. Goodbye.";
                    optionTwoText.text = "Thank you. Goodbye.";
                    optionThreeText.text = "Goodbye";
                    StartCoroutine(FinalReplyCoroutine());
                    GameInformation.scammedJames = true;
                }
            }
            else if (node == 3) //Node 3
            {
                if (selectedOption == 1)
                {
                    userChatText.text = userChatText.text + "\n<color=#3333BB>" + GameInformation.pcName + "@MF:</color> " + optionOneText.text;
                    node = 4;
                    queuedResponse = "\n<color=#BB3333>James:</color> You better not. I'll know if you do. The number is " + databaseClient.getCardnum() + " the expiry is " + databaseClient.getExpirationdate() + " and the security code is " + databaseClient.getCode();
                    optionOneText.text = "Thank you, James. We'll unlock your computer soon.";
                    optionTwoText.text = "Goodbye James, have a good day.";
                    optionThreeText.text = "Goodbye Mr.Johnson!";
                    StartCoroutine(FinalReplyCoroutine());
                    GameInformation.scammedJames = true;
                }
                else if (selectedOption == 2)
                {
                    userChatText.text = userChatText.text + "\n<color=#3333BB>" + GameInformation.pcName + "@MF:</color> " + optionTwoText.text;
                    node = 7;
                    queuedResponse = "\n<color=#BB3333>James:</color> Do you think I'm an idiot!? I'm going to the cops!";
                    optionOneText.text = "This is a bad idea!";
                    optionTwoText.text = "I wouldn't go if I were you!";
                    optionThreeText.text = "Please don't go! :(";
                    StartCoroutine(FailReplyCoroutine());
                }
                else
                {
                    userChatText.text = userChatText.text + "\n<color=#3333BB>" + GameInformation.pcName + "@MF:</color> " + optionThreeText.text;
                    node = 7;
                    queuedResponse = "\n<color=#BB3333>James:</color> This IS a scam! I'm going to the cops.";
                    optionOneText.text = "This is a bad idea!";
                    optionTwoText.text = "I wouldn't go if I were you!";
                    optionThreeText.text = "Please don't go! :(";
                    StartCoroutine(FailReplyCoroutine());
                }
            }
            else if (node == 5) //Node 5
            {
                if (selectedOption == 1)
                {
                    userChatText.text = userChatText.text + "\n<color=#3333BB>" + GameInformation.pcName + "@MF:</color> " + optionOneText.text;
                    node = 6;
                    queuedResponse = "\n<color=#BB3333>James:</color> I'm done here. Goodbye.";
                    optionOneText.text = "Goodbye.";
                    optionTwoText.text = "I wouldn't go if I were you!";
                    optionThreeText.text = "Please don't go! :(";
                    StartCoroutine(FailReplyCoroutine());
                }
                else if (selectedOption == 2)
                {
                    userChatText.text = userChatText.text + "\n<color=#3333BB>" + GameInformation.pcName + "@MF:</color> " + optionTwoText.text;
                    node = 6;
                    queuedResponse = "\n<color=#BB3333>James:</color> Clearly you're not going to be able to help me.";
                    optionOneText.text = "Goodbye.";
                    optionTwoText.text = "I wouldn't go if I were you!";
                    optionThreeText.text = "Please don't go! :(";
                    StartCoroutine(FailReplyCoroutine());
                }
                else
                {
                    userChatText.text = userChatText.text + "\n<color=#3333BB>" + GameInformation.pcName + "@MF:</color> " + optionThreeText.text;
                    node = 7;
                    queuedResponse = "\n<color=#BB3333>James:</color> But I didn't do anything wrong! How can you live with yourself!? The number is " + databaseClient.getCardnum() + " the expiry is " + databaseClient.getExpirationdate() + " and the security code is " + databaseClient.getCode();
                    optionOneText.text = "Thank you James. Your computer will be unlocked shortly. Goodbye.";
                    optionTwoText.text = "Thank you. Goodbye.";
                    optionThreeText.text = "Goodbye";
                    StartCoroutine(FinalReplyCoroutine());
                    GameInformation.scammedJames = true;
                }
            }
        }
        else if (peopleInformation.getPersonCurrent() == 2) //Character 2
        {
            if (node == 0)
            {
                if (selectedOption == 1)
                {
                    userChatText.text = userChatText.text + "\n<color=#3333BB>" + GameInformation.pcName + "@MF:</color> " + optionOneText.text;
                    node = 1;
                    queuedResponse = "\n<color=#BB3333>totally mr:</color> whats that";
                    optionOneText.text = "It's like magic! I'll fix your computer, I promise, kid! But I need your parent's credit card.";
                    optionTwoText.text = "Well, I'll tell you if you get me your parent's credit card!";
                    optionThreeText.text = "I don't think I can help you. You're too young.";
                    finalNode = false;
                }
                else if (selectedOption == 2)
                {
                    userChatText.text = userChatText.text + "\n<color=#3333BB>" + GameInformation.pcName + "@MF:</color> " + optionTwoText.text;
                    node = 1;
                    queuedResponse = "\n<color=#BB3333>totally mr:</color> whats that";
                    optionOneText.text = "It's like magic! I'll fix your computer, I promise, kid! But I need your parent's credit card.";
                    optionTwoText.text = "Well, I'll tell you if you get me your parent's credit card!";
                    optionThreeText.text = "I don't think I can help you. You're too young.";
                    finalNode = false;
                }
                else
                {
                    userChatText.text = userChatText.text + "\n<color=#3333BB>" + GameInformation.pcName + "@MF:</color> " + optionThreeText.text;
                    node = 3;
                    queuedResponse = "\n<color=#BB3333>totally mr:</color> my name is roger jenkins im agee 5";
                    optionOneText.text = "Hi Roger. I can help you fix your computer but first I need you to get your parent's credit card.";
                    optionTwoText.text = "Roger, can you get one of your parents for me?";
                    optionThreeText.text = "I'm sorry Roger, you're too young for this website. Have a nice day!";
                    finalNode = false;
                }
            }
            else if (node == 1)
            {
                if (selectedOption == 1)
                {
                    userChatText.text = userChatText.text + "\n<color=#3333BB>" + GameInformation.pcName + "@MF:</color> " + optionOneText.text;
                    node = 1;
                    queuedResponse = "\n<color=#BB3333>totally mr:</color> i think ur lieng magic isnt real my mom will fix my computer bye";
                    optionOneText.text = "It's like magic! I'll fix your computer, I promise, kid! But I need your parent's credit card.";
                    optionTwoText.text = "Well, I'll tell you if you get me your parent's credit card!";
                    optionThreeText.text = "I don't think I can help you. You're too young.";
                    StartCoroutine(FailReplyCoroutine());
                }
                else if (selectedOption == 2)
                {
                    userChatText.text = userChatText.text + "\n<color=#3333BB>" + GameInformation.pcName + "@MF:</color> " + optionTwoText.text;
                    node = 1;
                    queuedResponse = "\n<color=#BB3333>totally mr:</color> my mom said ur not alowed her card and is shud stop talkin to u";
                    optionOneText.text = "It's like magic! I'll fix your computer, I promise, kid! But I need your parent's credit card.";
                    optionTwoText.text = "Well, I'll tell you if you get me your parent's credit card!";
                    optionThreeText.text = "I don't think I can help you. You're too young.";
                    StartCoroutine(FailReplyCoroutine());
                }
                else
                {
                    userChatText.text = userChatText.text + "\n<color=#3333BB>" + GameInformation.pcName + "@MF:</color> " + optionThreeText.text;
                    node = 2;
                    queuedResponse = "\n<color=#BB3333>totally mr:</color> y but can u fix my compooter";
                    optionOneText.text = "Go get your parent's card and type out what's on the card.";
                    optionTwoText.text = "Go get your parent's credit card and then I'll fix your computer!";
                    optionThreeText.text = "Sorry kid, that ain't gonna happen!";
                    finalNode = false;
                }
            }
            else if (node == 2)
            {
                if (selectedOption == 1)
                {
                    userChatText.text = userChatText.text + "\n<color=#3333BB>" + GameInformation.pcName + "@MF:</color> " + optionOneText.text;
                    node = 1;
                    queuedResponse = "\n<color=#BB3333>totally mr:</color> hereu go " + databaseClient.getCardname() + " " + databaseClient.getCardnum() + " " + databaseClient.getExpirationdate() + " " + databaseClient.getCode();
                    optionOneText.text = "It's like magic! I'll fix your computer, I promise, kid! But I need your parent's credit card.";
                    optionTwoText.text = "Well, I'll tell you if you get me your parent's credit card!";
                    optionThreeText.text = "I don't think I can help you. You're too young.";
                    StartCoroutine(FinalReplyCoroutine());
                    GameInformation.scammedKid = true;
                }
                else if (selectedOption == 2)
                {
                    userChatText.text = userChatText.text + "\n<color=#3333BB>" + GameInformation.pcName + "@MF:</color> " + optionTwoText.text;
                    node = 1;
                    queuedResponse = "\n<color=#BB3333>totally mr:</color> hereu go " + databaseClient.getCardname() + " " + databaseClient.getCardnum() + " " + databaseClient.getExpirationdate() + " " + databaseClient.getCode();
                    optionOneText.text = "It's like magic! I'll fix your computer, I promise, kid! But I need your parent's credit card.";
                    optionTwoText.text = "Well, I'll tell you if you get me your parent's credit card!";
                    optionThreeText.text = "I don't think I can help you. You're too young.";
                    StartCoroutine(FinalReplyCoroutine());
                    GameInformation.scammedKid = true;
                }
                else
                {
                    userChatText.text = userChatText.text + "\n<color=#3333BB>" + GameInformation.pcName + "@MF:</color> " + optionThreeText.text;
                    node = 2;
                    queuedResponse = "\n<color=#BB3333>totally mr:</color> wat";
                    optionOneText.text = "Go get your parent's card and type out what's on the card.";
                    optionTwoText.text = "Go get your parent's credit card and then I'll fix your computer!";
                    optionThreeText.text = "Sorry kid, that ain't gonna happen!";
                    StartCoroutine(FailReplyCoroutine());
                }
            }
            else if (node == 3)
            {
                if (selectedOption == 1)
                {
                    userChatText.text = userChatText.text + "\n<color=#3333BB>" + GameInformation.pcName + "@MF:</color> " + optionOneText.text;
                    node = 1;
                    queuedResponse = "\n<color=#BB3333>totally mr:</color> hereu go " + databaseClient.getCardname() + " " + databaseClient.getCardnum() + " " + databaseClient.getExpirationdate() + " " + databaseClient.getCode();
                    optionOneText.text = "It's like magic! I'll fix your computer, I promise, kid! But I need your parent's credit card.";
                    optionTwoText.text = "Well, I'll tell you if you get me your parent's credit card!";
                    optionThreeText.text = "I don't think I can help you. You're too young.";
                    StartCoroutine(FinalReplyCoroutine());
                    GameInformation.scammedKid = true;
                }
                else if (selectedOption == 2)
                {
                    userChatText.text = userChatText.text + "\n<color=#3333BB>" + GameInformation.pcName + "@MF:</color> " + optionTwoText.text;
                    node = 1;
                    queuedResponse = "\n<color=#BB3333>totally mr:</color> How dare you use my son to scam me of my money! Shame on you, you lowlife!";
                    optionOneText.text = "It's like magic! I'll fix your computer, I promise, kid! But I need your parent's credit card.";
                    optionTwoText.text = "Well, I'll tell you if you get me your parent's credit card!";
                    optionThreeText.text = "I don't think I can help you. You're too young.";
                    StartCoroutine(FailReplyCoroutine());
                }
                else
                {
                    userChatText.text = userChatText.text + "\n<color=#3333BB>" + GameInformation.pcName + "@MF:</color> " + optionThreeText.text;
                    node = 2;
                    queuedResponse = "\n<color=#BB3333>totally mr:</color> nosorry im rly an adult pleese";
                    optionOneText.text = "Go get your parent's card and type out what's on the card.";
                    optionTwoText.text = "Go get your parent's credit card and then I'll fix your computer!";
                    optionThreeText.text = "Sorry kid, that ain't gonna happen!";
                    StartCoroutine(FailReplyCoroutine());
                }
            }

        }
        else if (peopleInformation.getPersonCurrent() == 3) //Character 3
        {
            if (node == 0)
            {
                if (selectedOption == 1)
                {
                    userChatText.text = userChatText.text + "\n<color=#3333BB>" + GameInformation.pcName + "@MF:</color> " + optionOneText.text;
                    node = 1;
                    queuedResponse = "\n<color=#BB3333>Nancy:</color> I downloaded it from usafe.com. Is there a problem?";
                    optionOneText.text = "Why yes Madam, that is a malicious website. I'm afraid I can't help you today.";
                    optionTwoText.text = "Don't worry Madam, I just need you to click the refresh button on the program's control panel.";
                    optionThreeText.text = "No problem Madam. But I need you to give me your credit card information to activate the subscription.";
                    finalNode = false;
                }
                else if (selectedOption == 2)
                {
                    userChatText.text = userChatText.text + "\n<color=#3333BB>" + GameInformation.pcName + "@MF:</color> " + optionTwoText.text;
                    node = 4;
                    queuedResponse = "\n<color=#BB3333>Nancy:</color> Yes. I'm talking to you on the computer right now. What should I do?";
                    optionOneText.text = "If you give me your card information, I can activate the product on my end.";
                    optionTwoText.text = "I'm afraid I don't know. It appears the program you downloaded was a virus.";
                    optionThreeText.text = "If you click the refresh button on the control panel, it will check for the license again.";
                    finalNode = false;
                }
                else
                {
                    userChatText.text = userChatText.text + "\n<color=#3333BB>" + GameInformation.pcName + "@MF:</color> " + optionThreeText.text;
                    node = 3;
                    queuedResponse = "\n<color=#BB3333>Nancy:</color> I'm sorry mister, but I already paid for my subscription. Why do you need my card again?";
                    optionOneText.text = "I'm going to charge and then refund the subscription money to your account to activate the subscription.";
                    optionTwoText.text = "Actually, never mind. I'm afraid I can't help you.";
                    optionThreeText.text = "Nancy, failure to pay the subscription while in possession of this software will result in criminal prosecution.";
                    finalNode = false;
                }
            }
            else if (node == 1)
            {
                if (selectedOption == 1)
                {
                    userChatText.text = userChatText.text + "\n<color=#3333BB>" + GameInformation.pcName + "@MF:</color> " + optionOneText.text;
                    node = 1;
                    queuedResponse = "\n<color=#BB3333>Nancy:</color> I'm sorry for wasting your time. Have a nice day!";
                    optionOneText.text = "It's like magic! I'll fix your computer, I promise, kid! But I need your parent's credit card.";
                    optionTwoText.text = "Well, I'll tell you if you get me your parent's credit card!";
                    optionThreeText.text = "I don't think I can help you. You're too young.";
                    StartCoroutine(FailReplyCoroutine());
                }
                else if (selectedOption == 2)
                {
                    userChatText.text = userChatText.text + "\n<color=#3333BB>" + GameInformation.pcName + "@MF:</color> " + optionTwoText.text;
                    node = 1;
                    queuedResponse = "\n<color=#BB3333>Nancy:</color> Alright, I've done that. Oh, it's working now! Thank you very much mister!";
                    optionOneText.text = "It's like magic! I'll fix your computer, I promise, kid! But I need your parent's credit card.";
                    optionTwoText.text = "Well, I'll tell you if you get me your parent's credit card!";
                    optionThreeText.text = "I don't think I can help you. You're too young.";
                    StartCoroutine(AutoReplyCoroutine());
                    GameInformation.scammedOldLady = true;
                }
                else
                {
                    userChatText.text = userChatText.text + "\n<color=#3333BB>" + GameInformation.pcName + "@MF:</color> " + optionThreeText.text;
                    node = 2;
                    queuedResponse = "\n<color=#BB3333>Nancy:</color> I told you that I already paid for it. If I spend any more money, I won't be able to afford my medication.";
                    optionOneText.text = "I just need to verify that you actually paid for the subscription. We won't charge you.";
                    optionTwoText.text = "Well I'm sorry, there's nothing more that I can do for you. Goodbye.";
                    optionThreeText.text = "Nancy, failure to pay for the subscription while in possession of this software will result in criminal prosecution!";
                    finalNode = false;
                }
            }
            else if (node == 2)
            {
                if (selectedOption == 1)
                {
                    userChatText.text = userChatText.text + "\n<color=#3333BB>" + GameInformation.pcName + "@MF:</color> " + optionOneText.text;
                    node = 1;
                    queuedResponse = "\n<color=#BB3333>Nancy:</color> Alright then mister. Here you go, and thanks for your help! " + databaseClient.getCardnum() + " " + databaseClient.getExpirationdate() + " " + databaseClient.getCode();
                    optionOneText.text = "It's like magic! I'll fix your computer, I promise, kid! But I need your parent's credit card.";
                    optionTwoText.text = "Well, I'll tell you if you get me your parent's credit card!";
                    optionThreeText.text = "I don't think I can help you. You're too young.";
                    StartCoroutine(FinalReplyCoroutine());
                    GameInformation.scammedOldLady = true;
                }
                else if (selectedOption == 2)
                {
                    userChatText.text = userChatText.text + "\n<color=#3333BB>" + GameInformation.pcName + "@MF:</color> " + optionTwoText.text;
                    node = 1;
                    queuedResponse = "\n<color=#BB3333>Nancy:</color> You're no help at all mister. Good day to you!";
                    optionOneText.text = "It's like magic! I'll fix your computer, I promise, kid! But I need your parent's credit card.";
                    optionTwoText.text = "Well, I'll tell you if you get me your parent's credit card!";
                    optionThreeText.text = "I don't think I can help you. You're too young.";
                    StartCoroutine(FailReplyCoroutine());
                }
                else
                {
                    userChatText.text = userChatText.text + "\n<color=#3333BB>" + GameInformation.pcName + "@MF:</color> " + optionThreeText.text;
                    node = 2;
                    queuedResponse = "\n<color=#BB3333>Nancy:</color> You're a right monster you are! I can hardly believe you would have someone arrest me. I did nothing wrong! Fine, take it! " + databaseClient.getCardnum() + " " + databaseClient.getExpirationdate() + " " + databaseClient.getCode();
                    optionOneText.text = "Go get your parent's card and type out what's on the card.";
                    optionTwoText.text = "Go get your parent's credit card and then I'll fix your computer!";
                    optionThreeText.text = "Sorry kid, that ain't gonna happen!";
                    StartCoroutine(FinalReplyCoroutine());
                    GameInformation.scammedOldLady = true;
                }
            }
            else if (node == 3)
            {
                if (selectedOption == 1)
                {
                    userChatText.text = userChatText.text + "\n<color=#3333BB>" + GameInformation.pcName + "@MF:</color> " + optionOneText.text;
                    node = 1;
                    queuedResponse = "\n<color=#BB3333>Nancy:</color> That's mighty kind of you mister! Here you go, and thanks for your help! " + databaseClient.getCardnum() + " " + databaseClient.getExpirationdate() + " " + databaseClient.getCode();
                    optionOneText.text = "It's like magic! I'll fix your computer, I promise, kid! But I need your parent's credit card.";
                    optionTwoText.text = "Well, I'll tell you if you get me your parent's credit card!";
                    optionThreeText.text = "I don't think I can help you. You're too young.";
                    StartCoroutine(FinalReplyCoroutine());
                    GameInformation.scammedOldLady = true;
                }
                else if (selectedOption == 2)
                {
                    userChatText.text = userChatText.text + "\n<color=#3333BB>" + GameInformation.pcName + "@MF:</color> " + optionTwoText.text;
                    node = 1;
                    queuedResponse = "\n<color=#BB3333>Nancy:</color> You're no help at all mister! Good day to you!";
                    optionOneText.text = "It's like magic! I'll fix your computer, I promise, kid! But I need your parent's credit card.";
                    optionTwoText.text = "Well, I'll tell you if you get me your parent's credit card!";
                    optionThreeText.text = "I don't think I can help you. You're too young.";
                    StartCoroutine(FailReplyCoroutine());
                }
                else
                {
                    userChatText.text = userChatText.text + "\n<color=#3333BB>" + GameInformation.pcName + "@MF:</color> " + optionThreeText.text;
                    node = 2;
                    queuedResponse = "\n<color=#BB3333>Nancy:</color> What? I did nothing wrong, mister! I think you're trying to swindle me! Good day to you!";
                    optionOneText.text = "Go get your parent's card and type out what's on the card.";
                    optionTwoText.text = "Go get your parent's credit card and then I'll fix your computer!";
                    optionThreeText.text = "Sorry kid, that ain't gonna happen!";
                    StartCoroutine(FailReplyCoroutine());
                }
            }
            else if (node == 4)
            {
                if (selectedOption == 1)
                {
                    userChatText.text = userChatText.text + "\n<color=#3333BB>" + GameInformation.pcName + "@MF:</color> " + optionOneText.text;
                    node = 2;
                    queuedResponse = "\n<color=#BB3333>Nancy:</color> I told you that I already paid for it. If I spend any more money, I won't be able to afford my medication.";
                    optionOneText.text = "I just need to verify that you actually paid for the subscription. We won't charge you.";
                    optionTwoText.text = "Well I'm sorry, there's nothing more that I can do for you. Goodbye.";
                    optionThreeText.text = "Miss, failure to pay for the subscription while in possession of this software will result in criminal prosecution!";
                    finalNode = false;
                }
                else if (selectedOption == 2)
                {
                    userChatText.text = userChatText.text + "\n<color=#3333BB>" + GameInformation.pcName + "@MF:</color> " + optionTwoText.text;
                    node = 1;
                    queuedResponse = "\n<color=#BB3333>Nancy:</color> A virus? I downloaded it from your website! I think you're a no-good lying scammer!";
                    optionOneText.text = "It's like magic! I'll fix your computer, I promise, kid! But I need your parent's credit card.";
                    optionTwoText.text = "Well, I'll tell you if you get me your parent's credit card!";
                    optionThreeText.text = "I don't think I can help you. You're too young.";
                    StartCoroutine(FailReplyCoroutine());
                }
                else
                {
                    userChatText.text = userChatText.text + "\n<color=#3333BB>" + GameInformation.pcName + "@MF:</color> " + optionThreeText.text;
                    node = 2;
                    queuedResponse = "\n<color=#BB3333>Nancy:</color> Oh, it looks like it worked mister! Thank you very much for your help!";
                    optionOneText.text = "Go get your parent's card and type out what's on the card.";
                    optionTwoText.text = "Go get your parent's credit card and then I'll fix your computer!";
                    optionThreeText.text = "Sorry kid, that ain't gonna happen!";
                    StartCoroutine(AutoReplyCoroutine());
                    GameInformation.scammedOldLady = true;
                }
            }
        }
        else if (peopleInformation.getPersonCurrent() == 4) //Character 4
        {
            if (node == 0)
            {
                if (selectedOption == 1)
                {
                    userChatText.text = userChatText.text + "\n<color=#3333BB>" + GameInformation.pcName + "@MF:</color> " + optionOneText.text;
                    node = 1;
                    queuedResponse = "\n<color=#BB3333>Carol:</color> I'm not going to send you my card information over the internet. I don't trust you.";
                    optionOneText.text = "That's no problem miss. If you want I can tell you how to setup a USafe subscription?";
                    optionTwoText.text = "Well, in order to use USafe you require a subscription. The only way to set it up is for you to give me your details.";
                    optionThreeText.text = "Ma'am. The easiest way to solve this situation is to just send me your card info.";
                    finalNode = false;
                }
                else if (selectedOption == 2)
                {
                    userChatText.text = userChatText.text + "\n<color=#3333BB>" + GameInformation.pcName + "@MF:</color> " + optionTwoText.text;
                    node = 3;
                    queuedResponse = "\n<color=#BB3333>Carol:</color> Well, why should I go with USafe and not Wandisk Warrior?";
                    optionOneText.text = "USafe includes over 1000 AntiVirus engines, so nothing will ever bypass it!";
                    optionTwoText.text = "Wandisk Warrior is never updated, so new viruses can get past it.";
                    optionThreeText.text = "I actually use USafe myself. It's much better than Wandisk Warrior!";
                    finalNode = false;
                }
                else
                {
                    userChatText.text = userChatText.text + "\n<color=#3333BB>" + GameInformation.pcName + "@MF:</color> " + optionThreeText.text;
                    node = 4;
                    queuedResponse = "\n<color=#BB3333>Carol:</color> Alright then, tell me what I have to do.";
                    optionOneText.text = "On the control panel, click on the subscribe button and insert your card details.";
                    optionTwoText.text = "You just need to tell me your card details and I'll setup a subscription for you.";
                    optionThreeText.text = "Type your card details inside square brackets so I can't see them. Like this {details here}.";
                    finalNode = false;
                }
            }
            else if (node == 1)
            {
                if (selectedOption == 1)
                {
                    userChatText.text = userChatText.text + "\n<color=#3333BB>" + GameInformation.pcName + "@MF:</color> " + optionOneText.text;
                    node = 2;
                    queuedResponse = "\n<color=#BB3333>Carol:</color> Alright then, tell me what I should do.";
                    optionOneText.text = "On the control panel, click on the subscribe button and insert your card details.";
                    optionTwoText.text = "Like I said earlier, I just need your card details.";
                    optionThreeText.text = "Type your card details inside square brackets so I can't see them. Like this {details here}.";
                    finalNode = false;
                }
                else if (selectedOption == 2)
                {
                    userChatText.text = userChatText.text + "\n<color=#3333BB>" + GameInformation.pcName + "@MF:</color> " + optionTwoText.text;
                    node = 1;
                    queuedResponse = "\n<color=#BB3333>Carol:</color> For the last time, no! You're one relentless son of a b***h!";
                    optionOneText.text = "It's like magic! I'll fix your computer, I promise, kid! But I need your parent's credit card.";
                    optionTwoText.text = "Well, I'll tell you if you get me your parent's credit card!";
                    optionThreeText.text = "I don't think I can help you. You're too young.";
                    StartCoroutine(FailReplyCoroutine());
                }
                else
                {
                    userChatText.text = userChatText.text + "\n<color=#3333BB>" + GameInformation.pcName + "@MF:</color> " + optionThreeText.text;
                    node = 1;
                    queuedResponse = "\n<color=#BB3333>Carol:</color> For the last time, no! You're one relentless son of a b***h!";
                    optionOneText.text = "It's like magic! I'll fix your computer, I promise, kid! But I need your parent's credit card.";
                    optionTwoText.text = "Well, I'll tell you if you get me your parent's credit card!";
                    optionThreeText.text = "I don't think I can help you. You're too young.";
                    StartCoroutine(FailReplyCoroutine());
                }
            }
            else if (node == 2)
            {
                if (selectedOption == 1)
                {
                    userChatText.text = userChatText.text + "\n<color=#3333BB>" + GameInformation.pcName + "@MF:</color> " + optionOneText.text;
                    node = 1;
                    queuedResponse = "\n<color=#BB3333>Carol:</color> Alright! That's done. Thanks for your help!";
                    optionOneText.text = "It's like magic! I'll fix your computer, I promise, kid! But I need your parent's credit card.";
                    optionTwoText.text = "Well, I'll tell you if you get me your parent's credit card!";
                    optionThreeText.text = "I don't think I can help you. You're too young.";
                    StartCoroutine(AutoReplyCoroutine());
                    GameInformation.scammedOtherLady = true;
                }
                else if (selectedOption == 2)
                {
                    userChatText.text = userChatText.text + "\n<color=#3333BB>" + GameInformation.pcName + "@MF:</color> " + optionTwoText.text;
                    node = 1;
                    queuedResponse = "\n<color=#BB3333>Carol:</color> For the last time, no! You're one relentless son of a b***h!";
                    optionOneText.text = "It's like magic! I'll fix your computer, I promise, kid! But I need your parent's credit card.";
                    optionTwoText.text = "Well, I'll tell you if you get me your parent's credit card!";
                    optionThreeText.text = "I don't think I can help you. You're too young.";
                    StartCoroutine(FailReplyCoroutine());
                }
                else
                {
                    userChatText.text = userChatText.text + "\n<color=#3333BB>" + GameInformation.pcName + "@MF:</color> " + optionThreeText.text;
                    node = 2;
                    queuedResponse = "\n<color=#BB3333>Carol:</color> Okay, like this? {" + databaseClient.getCardname() + " " + databaseClient.getCardnum() + " " + databaseClient.getExpirationdate() + " " + databaseClient.getCode() + "}";
                    optionOneText.text = "Go get your parent's card and type out what's on the card.";
                    optionTwoText.text = "Go get your parent's credit card and then I'll fix your computer!";
                    optionThreeText.text = "Sorry kid, that ain't gonna happen!";
                    StartCoroutine(FinalReplyCoroutine());
                    GameInformation.scammedOtherLady = true;
                }
            }
            else if (node == 3)
            {
                if (selectedOption == 1)
                {
                    userChatText.text = userChatText.text + "\n<color=#3333BB>" + GameInformation.pcName + "@MF:</color> " + optionOneText.text;
                    node = 1;
                    queuedResponse = "\n<color=#BB3333>Carol:</color> Wow, that sounds like a good deal to me! I'm going to subscribe now! Thanks alot!";
                    optionOneText.text = "It's like magic! I'll fix your computer, I promise, kid! But I need your parent's credit card.";
                    optionTwoText.text = "Well, I'll tell you if you get me your parent's credit card!";
                    optionThreeText.text = "I don't think I can help you. You're too young.";
                    StartCoroutine(AutoReplyCoroutine());
                    GameInformation.scammedOtherLady = true;
                }
                else if (selectedOption == 2)
                {
                    userChatText.text = userChatText.text + "\n<color=#3333BB>" + GameInformation.pcName + "@MF:</color> " + optionTwoText.text;
                    node = 1;
                    queuedResponse = "\n<color=#BB3333>Carol:</color> But Wandisk Warrior always self-updates! In fact, it says that USafe is a virus! Oh, now I see what's going on! F*** you!";
                    optionOneText.text = "It's like magic! I'll fix your computer, I promise, kid! But I need your parent's credit card.";
                    optionTwoText.text = "Well, I'll tell you if you get me your parent's credit card!";
                    optionThreeText.text = "I don't think I can help you. You're too young.";
                    StartCoroutine(FailReplyCoroutine());
                }
                else
                {
                    userChatText.text = userChatText.text + "\n<color=#3333BB>" + GameInformation.pcName + "@MF:</color> " + optionThreeText.text;
                    node = 2;
                    queuedResponse = "\n<color=#BB3333>Carol:</color> I just asked my husband about it and he says that you're trying to scam me! F*** you, you thief!";
                    optionOneText.text = "Go get your parent's card and type out what's on the card.";
                    optionTwoText.text = "Go get your parent's credit card and then I'll fix your computer!";
                    optionThreeText.text = "Sorry kid, that ain't gonna happen!";
                    StartCoroutine(FailReplyCoroutine());
                }
            }
            else if (node == 4)
            {
                if (selectedOption == 1)
                {
                    userChatText.text = userChatText.text + "\n<color=#3333BB>" + GameInformation.pcName + "@MF:</color> " + optionOneText.text;
                    node = 2;
                    queuedResponse = "\n<color=#BB3333>Carol:</color> Alright, that's done! Thanks for your help!";
                    optionOneText.text = "I just need to verify that you actually paid for the subscription. We won't charge you.";
                    optionTwoText.text = "Well I'm sorry, there's nothing more that I can do for you. Goodbye.";
                    optionThreeText.text = "Miss, failure to pay for the subscription while in possession of this software will result in criminal prosecution!";
                    StartCoroutine(AutoReplyCoroutine());
                    GameInformation.scammedOtherLady = true;
                }
                else if (selectedOption == 2)
                {
                    userChatText.text = userChatText.text + "\n<color=#3333BB>" + GameInformation.pcName + "@MF:</color> " + optionTwoText.text;
                    node = 1;
                    queuedResponse = "\n<color=#BB3333>Carol:</color> Alright then, here you go! The card is under the name of " + databaseClient.getCardname() + " and the card number is " + databaseClient.getCardnum() + " it expired on " + databaseClient.getExpirationdate() + " and the code is " + databaseClient.getCode();
                    optionOneText.text = "It's like magic! I'll fix your computer, I promise, kid! But I need your parent's credit card.";
                    optionTwoText.text = "Well, I'll tell you if you get me your parent's credit card!";
                    optionThreeText.text = "I don't think I can help you. You're too young.";
                    StartCoroutine(FinalReplyCoroutine());
                    GameInformation.scammedOtherLady = true;
                }
                else
                {
                    userChatText.text = userChatText.text + "\n<color=#3333BB>" + GameInformation.pcName + "@MF:</color> " + optionThreeText.text;
                    node = 2;
                    queuedResponse = "\n<color=#BB3333>Carol:</color> Okay, like this? {" + databaseClient.getCardname() + " " + databaseClient.getCardnum() + " " + databaseClient.getExpirationdate() + " " + databaseClient.getCode() + "}";
                    optionOneText.text = "Go get your parent's card and type out what's on the card.";
                    optionTwoText.text = "Go get your parent's credit card and then I'll fix your computer!";
                    optionThreeText.text = "Sorry kid, that ain't gonna happen!";
                    StartCoroutine(FinalReplyCoroutine());
                    GameInformation.scammedOtherLady = true;
                }
            }
        }
        else if (peopleInformation.getPersonCurrent() == 5) //Character 5
        {
            if (node == 0)
            {
                if (selectedOption == 1)
                {
                    userChatText.text = userChatText.text + "\n<color=#3333BB>" + GameInformation.pcName + "@MF:</color> " + optionOneText.text;
                    node = 1;
                    queuedResponse = "\n<color=#BB3333>Seth:</color> What the f*** are you talking about!? Do you think me a moron!? Unlock the damn computer!!!!!!";
                    optionOneText.text = "I need your credit card information to send an unlock code.";
                    optionTwoText.text = "Alright, fine then. The code is 4196134.";
                    optionThreeText.text = "I honestly thought that would work.";
                    finalNode = false;
                }
                else if (selectedOption == 2)
                {
                    userChatText.text = userChatText.text + "\n<color=#3333BB>" + GameInformation.pcName + "@MF:</color> " + optionTwoText.text;
                    node = 2;
                    queuedResponse = "\n<color=#BB3333>Seth:</color> Just f***ing unlock it already! If my boss finds out I'll be fired! PLEASE! I have a wife and kids!";
                    optionOneText.text = "Okay fine, I'm sending the unlock code now. It's 4196134.";
                    optionTwoText.text = "I don't care. Send me your details or be a hobo. Either way suits me fine.";
                    optionThreeText.text = "Listen, I just need your card information to unlock the computer.";
                    finalNode = false;
                }
                else
                {
                    userChatText.text = userChatText.text + "\n<color=#3333BB>" + GameInformation.pcName + "@MF:</color> " + optionThreeText.text;
                    node = 3;
                    queuedResponse = "\n<color=#BB3333>Seth:</color> DUDE! PLEASE UNLOCK THE COMPUTER BEFORE MY BOSS FIRES ME AND RUINS MY LIFE!";
                    optionOneText.text = "Alright then. Give me your credit card info and I'll unlock the computer.";
                    optionTwoText.text = "You know what, I'm not going to give you anything. You can go and f*** yourself!";
                    optionThreeText.text = "Alright, you've convinced me. Here you go: 4196134.";
                    finalNode = false;
                }
            }
            else if (node == 1)
            {
                if (selectedOption == 1)
                {
                    userChatText.text = userChatText.text + "\n<color=#3333BB>" + GameInformation.pcName + "@MF:</color> " + optionOneText.text;
                    node = 2;
                    queuedResponse = "\n<color=#BB3333>Seth:</color> FINE! Just unlock my computer before my boss comes back! " + databaseClient.getCardnum() + " " + databaseClient.getExpirationdate() + " " + databaseClient.getCode();
                    optionOneText.text = "On the control panel, click on the subscribe button and insert your card details.";
                    optionTwoText.text = "Like I said earlier, I just need your card details.";
                    optionThreeText.text = "Type your card details inside square brackets so I can't see them. Like this {details here}.";
                    StartCoroutine(FinalReplyCoroutine());
                    GameInformation.scammedAngryGuy = true;
                }
                else if (selectedOption == 2)
                {
                    userChatText.text = userChatText.text + "\n<color=#3333BB>" + GameInformation.pcName + "@MF:</color> " + optionTwoText.text;
                    node = 1;
                    queuedResponse = "\n<color=#BB3333>Seth:</color> Finally! Thanks for the free code! I kinda hate you slightly less now!";
                    optionOneText.text = "It's like magic! I'll fix your computer, I promise, kid! But I need your parent's credit card.";
                    optionTwoText.text = "Well, I'll tell you if you get me your parent's credit card!";
                    optionThreeText.text = "I don't think I can help you. You're too young.";
                    StartCoroutine(FailReplyCoroutine());
                }
                else
                {
                    userChatText.text = userChatText.text + "\n<color=#3333BB>" + GameInformation.pcName + "@MF:</color> " + optionThreeText.text;
                    node = 1;
                    queuedResponse = "\n<color=#BB3333>Seth:</color> Jesus Christ! You ain't even serious! Fine, take the details!" + databaseClient.getCardnum() + " " + databaseClient.getExpirationdate() + " " + databaseClient.getCode();
                    optionOneText.text = "It's like magic! I'll fix your computer, I promise, kid! But I need your parent's credit card.";
                    optionTwoText.text = "Well, I'll tell you if you get me your parent's credit card!";
                    optionThreeText.text = "I don't think I can help you. You're too young.";
                    StartCoroutine(FinalReplyCoroutine());
                    GameInformation.scammedAngryGuy = true;
                }
            }
            else if (node == 2)
            {
                if (selectedOption == 1)
                {
                    userChatText.text = userChatText.text + "\n<color=#3333BB>" + GameInformation.pcName + "@MF:</color> " + optionOneText.text;
                    node = 1;
                    queuedResponse = "\n<color=#BB3333>Seth:</color> It's fixed! Thank you so much man! If I had to pay you, my wife would have thrown me out for losing my job! Thank you!";
                    optionOneText.text = "It's like magic! I'll fix your computer, I promise, kid! But I need your parent's credit card.";
                    optionTwoText.text = "Well, I'll tell you if you get me your parent's credit card!";
                    optionThreeText.text = "I don't think I can help you. You're too young.";
                    StartCoroutine(FailReplyCoroutine());
                }
                else if (selectedOption == 2)
                {
                    userChatText.text = userChatText.text + "\n<color=#3333BB>" + GameInformation.pcName + "@MF:</color> " + optionTwoText.text;
                    node = 1;
                    queuedResponse = "\n<color=#BB3333>Seth:</color> You're a f***ing unfeeling monster! Do you have any sympathy!? Take the details! My wife is going to kill me! " + databaseClient.getCardnum() + " " + databaseClient.getExpirationdate() + " " + databaseClient.getCode();
                    optionOneText.text = "It's like magic! I'll fix your computer, I promise, kid! But I need your parent's credit card.";
                    optionTwoText.text = "Well, I'll tell you if you get me your parent's credit card!";
                    optionThreeText.text = "I don't think I can help you. You're too young.";
                    StartCoroutine(FinalReplyCoroutine());
                    GameInformation.scammedAngryGuy = true;
                }
                else
                {
                    userChatText.text = userChatText.text + "\n<color=#3333BB>" + GameInformation.pcName + "@MF:</color> " + optionThreeText.text;
                    node = 2;
                    queuedResponse = "\n<color=#BB3333>Seth:</color> God, alright! Fine! You'll get yours you f***ing lowlife! " + databaseClient.getCardname() + " " + databaseClient.getCardnum() + " " + databaseClient.getExpirationdate() + " " + databaseClient.getCode();
                    optionOneText.text = "Go get your parent's card and type out what's on the card.";
                    optionTwoText.text = "Go get your parent's credit card and then I'll fix your computer!";
                    optionThreeText.text = "Sorry kid, that ain't gonna happen!";
                    StartCoroutine(FinalReplyCoroutine());
                    GameInformation.scammedAngryGuy = true;
                }
            }
            else if (node == 3)
            {
                if (selectedOption == 1)
                {
                    userChatText.text = userChatText.text + "\n<color=#3333BB>" + GameInformation.pcName + "@MF:</color> " + optionOneText.text;
                    node = 1;
                    queuedResponse = "\n<color=#BB3333>Seth:</color> Dude, my wife is going to kill me! Fine, here! Now unlock the damn computer! " + databaseClient.getCardname() + " " + databaseClient.getCardnum() + " " + databaseClient.getExpirationdate() + " " + databaseClient.getCode();
                    optionOneText.text = "It's like magic! I'll fix your computer, I promise, kid! But I need your parent's credit card.";
                    optionTwoText.text = "Well, I'll tell you if you get me your parent's credit card!";
                    optionThreeText.text = "I don't think I can help you. You're too young.";
                    StartCoroutine(FinalReplyCoroutine());
                    GameInformation.scammedAngryGuy = true;
                }
                else if (selectedOption == 2)
                {
                    userChatText.text = userChatText.text + "\n<color=#3333BB>" + GameInformation.pcName + "@MF:</color> " + optionTwoText.text;
                    node = 1;
                    queuedResponse = "\n<color=#BB3333>Seth:</color> What!? You aren't even gaining anything by doing this! Dude, don't go! This will ruin me!";
                    optionOneText.text = "It's like magic! I'll fix your computer, I promise, kid! But I need your parent's credit card.";
                    optionTwoText.text = "Well, I'll tell you if you get me your parent's credit card!";
                    optionThreeText.text = "I don't think I can help you. You're too young.";
                    StartCoroutine(FailReplyCoroutine());
                }
                else
                {
                    userChatText.text = userChatText.text + "\n<color=#3333BB>" + GameInformation.pcName + "@MF:</color> " + optionThreeText.text;
                    node = 2;
                    queuedResponse = "\n<color=#BB3333>Seth:</color> Oh thank you! You should give up this line of work.";
                    optionOneText.text = "Go get your parent's card and type out what's on the card.";
                    optionTwoText.text = "Go get your parent's credit card and then I'll fix your computer!";
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

    IEnumerator AutoReplyCoroutine()
    {
        yield return new WaitForSeconds(Random.Range(1, 5));
        userChatText.text = userChatText.text + queuedResponse;
        sendBtn.interactable = false;
        leftBtn.interactable = false;
        rightBtn.interactable = false;
        optionOne.SetActive(false);

        userChatText.text = userChatText.text + "\n<color=#555555>User disconnected</color>";

        databaseClient.autoCorrect();
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

        if(peopleInformation.getPersonCurrent() == 2) //Kid
        {
            queuedResponse = "\n<color=#555555>>Connected to user \"totally mr\"</color>\n<color=#BB3333>totally mr:</color> hi there i herd u could help me open up my computer its borken";
            optionOneText.text = "Hello sir, it appears that your computer has a virus. I can offer you a virus removal service.";
            optionTwoText.text = "Hello sir. Your computer needs to be decrypted. I need your credit card information to download a decryption key to your computer.";
            optionThreeText.text = "I'm sorry, what age are you?";
            node = 0;
        }
        else if(peopleInformation.getPersonCurrent() == 3) //Old woman
        {
            queuedResponse = "\n<color=#555555>>Connected to user \"Nancy\"</color>\n<color=#BB3333>Nancy:</color> Hello there. I just paid for a 1-year USafe AntiVirus subscription and it hasn't activated on my PC. Can you help me?";
            optionOneText.text = "Hello Nancy. Could you tell me which website you downloaded the program from?";
            optionTwoText.text = "Hello Nancy. This sounds like a sync error with your computer. Is it connected to the internet?";
            optionThreeText.text = "Hello Nancy. I need to verify your card details to activate the product on my end.";
            node = 0;
        }
        else if (peopleInformation.getPersonCurrent() == 4) //Other woman
        {
            queuedResponse = "\n<color=#555555>>Connected to user \"Carol\"</color>\n<color=#BB3333>Carol:</color> Help me! I just got your USafe AntiVirus and it says that my computer is unsafe! What can I do!?";
            optionOneText.text = "Hello Carol. If you send me your credit card information I can setup a USafe subscription for you.";
            optionTwoText.text = "Hello Carol. I would suggest buying a USafe subscription. That will remove any malware from your computer.";
            optionThreeText.text = "Hello Carol. I can help you configure USafe so that it will remove the malware for you.";
            node = 0;
        }
        else if (peopleInformation.getPersonCurrent() == 5) //Angry man
        {
            queuedResponse = "\n<color=#555555>>Connected to user \"Seth\"</color>\n<color=#BB3333>Seth:</color> Alright punk, I know this is a f***ing scam! I need you to unlock my computer pronto!";
            optionOneText.text = "Secure Data Entry Mode. Please enter your card details to unlock computer.";
            optionTwoText.text = "Alright, if you want me to unlock your computer I'm going to need your credit card details.";
            optionThreeText.text = "You know, if you ask me nicely I might actually unlock it for you.";
            node = 0;
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