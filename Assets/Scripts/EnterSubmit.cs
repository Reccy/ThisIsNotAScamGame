using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnterSubmit : MonoBehaviour {

    public GameObject targetedButton;
    private Queue focusQueue;

    void Start() { 
        //Create queue to keep the state of the text field in the previous frame
        focusQueue = new Queue();
        focusQueue.Enqueue(false);
        focusQueue.Enqueue(false);
    }
    
	void Update () {
        UpdateQueue();
        if ((bool)focusQueue.Peek() && (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return)))
        {
            targetedButton.GetComponent<Button>().onClick.Invoke();
        }
	}

    //Updates the queue
    void UpdateQueue()
    {
        focusQueue.Enqueue(GetComponent<InputField>().isFocused);
        focusQueue.Dequeue();
    }
}
