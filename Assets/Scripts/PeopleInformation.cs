using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PeopleInformation : MonoBehaviour {

    private DatabaseClientScript databaseClient;
    private GameInformation gameInfo;
    private ChatClientScript chatClient;
    private int personCurrent;

	void Start () 
    {
        databaseClient = GameObject.FindGameObjectWithTag("DatabaseClient").GetComponent<DatabaseClientScript>();
        gameInfo = GameObject.FindGameObjectWithTag("GameInformation").GetComponent<GameInformation>();
        chatClient = GameObject.FindGameObjectWithTag("ChatClient").GetComponent<ChatClientScript>();
        personCurrent = 0;
        nextPerson();
	}

    public int getPersonCurrent()
    {
        return personCurrent;
    }

    public void nextPerson()
    {
        personCurrent++;

        if(personCurrent == 1)
        {
            databaseClient.setDetails(Random.Range(1000, 5000).ToString(), "James", "Johnson", "\"Child Porn\" Ransomware", "James Johnson", Random.Range(1000, 5000).ToString() + "-" + Random.Range(1000, 5000).ToString() + "-" + Random.Range(1000, 5000).ToString() + "-" + Random.Range(1000, 5000).ToString(), Random.Range(1, 12).ToString() + "/" + Random.Range(97, 99).ToString(), Random.Range(100, 900).ToString());
        }
        else if(personCurrent == 2)
        {
            databaseClient.setDetails(Random.Range(1000, 5000).ToString(), "totally mr", "radical", "pls fix my computer", "Susan Jenkins", Random.Range(1000, 5000).ToString() + "-" + Random.Range(1000, 5000).ToString() + "-" + Random.Range(1000, 5000).ToString() + "-" + Random.Range(1000, 5000).ToString(), Random.Range(1, 12).ToString() + "/" + Random.Range(97, 99).ToString(), Random.Range(100, 900).ToString());
            chatClient.NewConversation();
        }
        else if(personCurrent == 3)
        {
            databaseClient.setDetails(Random.Range(1000, 5000).ToString(), "Moira", "O'Flannigan", "USafe AntiVirus Subscription", "Brad O'Flannigan", Random.Range(1000, 5000).ToString() + "-" + Random.Range(1000, 5000).ToString() + "-" + Random.Range(1000, 5000).ToString() + "-" + Random.Range(1000, 5000).ToString(), Random.Range(1, 12).ToString() + "/" + Random.Range(97, 99).ToString(), Random.Range(100, 900).ToString());
            chatClient.NewConversation();
        }
        else
        {
            //End Game
        }
    }
}