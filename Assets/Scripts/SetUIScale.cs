using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SetUIScale : MonoBehaviour {

    int screenWidth = Screen.width; //Screen width
    public Canvas canvas;
    private CanvasScaler canvasScaler;

	void Start () {
        canvasScaler = canvas.GetComponent<CanvasScaler>();
        if(screenWidth < 1024)
        {
            canvasScaler.scaleFactor = 1/(1024f/screenWidth);
        }
        Debug.Log("Screen Width: " + screenWidth);
        Debug.Log("Target Size: " + 1/(1024f/screenWidth));
        Debug.Log("Canvas Scalefactor: " + canvasScaler.scaleFactor);
	}
}
