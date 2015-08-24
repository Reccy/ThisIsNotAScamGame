using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class EndManager : MonoBehaviour {

    private List<string> l;
    private Text term;
    private int cashStolen;

    void Start()
    {
        Debug.Log("James scammed: " + GameInformation.scammedJames);
        term = GameObject.Find("Terminal").GetComponent<Text>();
        cashStolen = 0;

        if(GameInformation.scammedJames)
        {
            cashStolen += 1523;
        }
        if(GameInformation.scammedKid)
        {
            cashStolen += 748;
        }
        if(GameInformation.scammedOldLady)
        {
            cashStolen += 102;
        }
        if(GameInformation.scammedOtherLady)
        {
            cashStolen += 3048;
        }
        if(GameInformation.scammedAngryGuy)
        {
            cashStolen += 12489;
        }

        l = new List<string>();

        if(GameInformation.peopleScammed == 0)
        {
            l.Add("\nYou scammed nobody");
            l.Add("\nThis was either by choice or by bad luck");
            l.Add("\nYour boss demands to see you in his office");
            l.Add("\nYou try to explain the situation, but he doesn't listen");
            l.Add("\nYou are under probation for a month");
            l.Add("\nIt's not nearly a good enough punishment after");
            l.Add("\nyou scammed thousands of people yesterday");
            l.Add("\nand the day before that");
            l.Add("\nand the week before that");
            l.Add("\nand the month before that");
            l.Add("\nand the year before that");
            l.Add("\nYou still have more than enough money to retire\nAfter all, \"You are the Monster\"");
            l.Add("\n");
            l.Add("\nThis is NOT a scam!");
            l.Add("\nGame by Aaron Meaney {RECCY}");
            l.Add("\nFor Ludum Dare 33");
            l.Add("\nSpecial thanks to XtremePrime for playtesting!");
            l.Add("\nThanks for Playing!");
        }
        else
        {
            l.Add("\nYou scammed a total of $" + cashStolen);
            if(GameInformation.peopleScammed == 1)
            {
                l.Add("\nfrom " + GameInformation.peopleScammed + " gullible yet innocent person");
            }
            else
            {
                l.Add("\nfrom " + GameInformation.peopleScammed + " gullible yet innocent people");
            }
            l.Add("\nI hope you're proud of yourself, you monster.\n");
            if(GameInformation.scammedJames)
            {
                l.Add("\nJames lost all of the money he was saving up for college");
                l.Add("\nHe dropped out because he couldn't pay his tuition\n");
            }
            else
            {
                l.Add("\nJames managed to evade your trickery and avoid your scam");
                l.Add("\nLater, he graduated from college with a BSc in Computer Science\n");
            }
            if(GameInformation.scammedKid)
            {
                l.Add("\nRoger's mom lost what little money she had after your scam");
                l.Add("\nSusan began to take illegal work to try and support her child\n");
            }
            else
            {
                l.Add("\nSusan's bank account is safe from harm after your scam attempt");
                l.Add("\nSoon after, she manages to find a well paying job\n");
            }
            if(GameInformation.scammedOldLady)
            {
                l.Add("\nOld Mrs. Clark couldn't afford her heart medication because of you");
                l.Add("\n4 days later, she died of a severe heart attack.\n");
            }
            else
            {
                l.Add("\nOld Mrs. Clark had just enough money left to pay for her medicine");
                l.Add("\nThe next month, she succesfully passed her heart operation\n");
            }
            if(GameInformation.scammedOtherLady)
            {
                l.Add("\nCarol installed USafe and it encrypted her entire hard drive");
                l.Add("\nShe lost all of her files and consequently, her job\n");
            }
            else
            {
                l.Add("\nCarol installed Wandisk Warrior and her computer was safe");
                l.Add("\nShe was promoted to head of marketing at her job soon after.\n");
            }
            if(GameInformation.scammedAngryGuy)
            {
                l.Add("\nSeth's wife divorced him after finding out he lost so much");
                l.Add("\nHe spent his final days begging on the streets\n");
            }
            else
            {
                l.Add("\nSeth was able to evade any major punishment from his boss");
                l.Add("\nA year later, he became the CEO of MicroFirm Corporation");
            }
            l.Add("\n");
            l.Add("\nThis is NOT a scam!\nGame by Aaron Meaney {RECCY}");
            l.Add("\nFor Ludum Dare 33");
            l.Add("\nSpecial thanks to XtremePrime for playtesting!");
            l.Add("\nThanks for Playing!");
        }
        StartCoroutine(bootUp());
    }

    void Update()
    {
        if (Input.GetKeyDown("enter") || Input.GetKeyDown("return"))
        {
            Application.LoadLevel("MainScene");
        }
    }

    IEnumerator bootUp()
    {
        Debug.Log("BOOTING");
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
