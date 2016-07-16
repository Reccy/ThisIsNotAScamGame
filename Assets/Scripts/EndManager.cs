using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class EndManager : MonoBehaviour {

    private List<string> l;
    private Text term;
    private int cashStolen;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
            Debug.Log("QUIT");
        }
    }

    void Start()
    {
        term = GameObject.Find("Terminal").GetComponent<Text>();
        cashStolen = 0;

        if(GameInformation.scammedJames)
        {
            cashStolen += 1523;
        }
        if(GameInformation.scammedKid)
        {
            cashStolen += 1748;
        }
        if(GameInformation.scammedOldLady)
        {
            cashStolen += 52;
        }
        if(GameInformation.scammedOtherLady)
        {
            cashStolen += 3048;
        }
        if(GameInformation.scammedAngryGuy)
        {
            cashStolen += 8489;
        }

        l = new List<string>();

        if(GameInformation.peopleScammed == 0)
        {
            l.Add("\nYou didn't scam anybody.");
            l.Add("\nThis was either by choice or by bad luck.");
            l.Add("\nYour boss demands to see you in his office.");
            l.Add("\nYou try to explain the situation, but he doesn't listen.");
            l.Add("\nYou are under probation for a month.");
            l.Add("\nIt's not nearly a good enough punishment.");
            l.Add("\nYou scammed thousands of people yesterday.");
            l.Add("\nand the day before that...");
            l.Add("\nand the week before that...");
            l.Add("\nand the month before that...");
            l.Add("\nand the year before that...");
            l.Add("\nYou still have more than enough money to retire.");
            l.Add("\n");
            l.Add("\nThis is NOT a scam!");
            l.Add("\nGame by Aaron Meaney {RECCY}");
            l.Add("\nOriginally for Ludum Dare 33");
            l.Add("\nSpecial thanks to XtremePrime for playtesting!");
            l.Add("\nThanks for Playing!\n\n\n[Press ESC to Exit!]");
        }
        else
        {
            l.Add("\nYou gained a total of $" + cashStolen);
            if(GameInformation.peopleScammed == 1)
            {
                l.Add("\nfrom " + GameInformation.peopleScammed + " gullible yet innocent person");
            }
            else
            {
                l.Add("\nfrom " + GameInformation.peopleScammed + " gullible yet innocent people");
            }
            l.Add("\nI hope you're proud of yourself.\n");
            if(GameInformation.scammedJames)
            {
                l.Add("\nJames lost all of the money he was saving up for college.");
                l.Add("\nHe dropped out because he couldn't pay his tuition.\n");
            }
            else
            {
                l.Add("\nJames managed to evade your trickery and avoid your scam.");
                l.Add("\nLater, he graduated from college with an accounting degree.\n");
            }
            if(GameInformation.scammedKid)
            {
                l.Add("\nRoger's mom lost what little money she had after your scam.");
                l.Add("\nHer child was taken from her soon afterwards.\n");
            }
            else
            {
                l.Add("\nSusan's bank account is safe from harm after your scam attempt.");
                l.Add("\nSoon after, she manages to find a well paying job.\n");
            }
            if(GameInformation.scammedOldLady)
            {
                l.Add("\nOld Nancy Clark couldn't afford her heart medication because of you.");
                l.Add("\nA week later, she died of a severe heart attack.\n");
            }
            else
            {
                l.Add("\nOld Nancy Clark had just enough money left to pay for her medicine.");
                l.Add("\nThe next month, she succesfully passed her heart operation.\n");
            }
            if(GameInformation.scammedOtherLady)
            {
                l.Add("\nCarol installed USafe and it encrypted her entire hard drive.");
                l.Add("\nShe lost all of her important files and consequently, her job.\n");
            }
            else
            {
                l.Add("\nCarol installed Wandisk Warrior and her computer was safe.");
                l.Add("\nShe was promoted to head of marketing at her job soon after.\n");
            }
            if(GameInformation.scammedAngryGuy)
            {
                l.Add("\nSeth lost his job after his bank account was hacked.");
                l.Add("\nHe was subsequently divorced by his wife.\n");
            }
            else
            {
                l.Add("\nSeth was able to delete the ransomware with the help of IT.");
                l.Add("\nA year later, he became the CTO of his company.");
            }
            l.Add("\n\nThis is NOT a scam!\nGame by Aaron Meaney {RECCY}");
            l.Add("\nOriginally for Ludum Dare 33");
            l.Add("\nSpecial thanks to XtremePrime for playtesting!");
            l.Add("\nThanks for Playing!\n\n\n[Press ESC to Exit!]");
        }
        StartCoroutine(bootUp());
    }

    IEnumerator bootUp()
    {
        yield return new WaitForSeconds(2);
        term.text = term.text + l[0];
        yield return new WaitForSeconds(2);
        term.text = term.text + l[1];
        yield return new WaitForSeconds(2);
        term.text = term.text + l[2];
        yield return new WaitForSeconds(2);
        term.text = term.text + l[3];
        yield return new WaitForSeconds(2);
        term.text = term.text + l[4];
        yield return new WaitForSeconds(2);
        term.text = term.text + l[5];
        yield return new WaitForSeconds(2);
        term.text = term.text + l[6];
        yield return new WaitForSeconds(2);
        term.text = term.text + l[7];
        yield return new WaitForSeconds(2);
        term.text = term.text + l[8];
        yield return new WaitForSeconds(2);
        term.text = term.text + l[9];
        yield return new WaitForSeconds(2);
        term.text = term.text + l[10];
        yield return new WaitForSeconds(2);
        term.text = term.text + l[11];
        yield return new WaitForSeconds(2);
        term.text = term.text + l[12];
        yield return new WaitForSeconds(2);
        term.text = term.text + l[13];
        yield return new WaitForSeconds(2);
        term.text = term.text + l[14];
        yield return new WaitForSeconds(2);
        term.text = term.text + l[15];
        yield return new WaitForSeconds(2);
        term.text = term.text + l[16];
        yield return new WaitForSeconds(2);
        term.text = term.text + l[17];
    }
}
