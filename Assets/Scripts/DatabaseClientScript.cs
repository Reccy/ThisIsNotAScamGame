using UnityEngine;
using System.Collections;

public class DatabaseClientScript : MonoBehaviour {

    GameObject databaseClient;
    

	void Start () 
    {
        databaseClient = GameObject.FindGameObjectWithTag("DatabaseClient");
	}

    public void ExitButtonClicked()
    {
        databaseClient.SetActive(false);
    }
}
