using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnterButton : MonoBehaviour {

    public GameObject targetButton;

	void Update () {
        if (Input.GetKeyDown(KeyCode.KeypadEnter) || (Input.GetKeyDown(KeyCode.Return)))
        {
            targetButton.GetComponent<Button>().onClick.Invoke();
        }
	}
}
