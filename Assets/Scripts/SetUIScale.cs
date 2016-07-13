using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SetUIScale : MonoBehaviour {

    int screenWidth = Screen.width;
    public Canvas canvas;
    private CanvasScaler canvasScaler;

	void Start () {
        canvasScaler = canvas.GetComponent<CanvasScaler>();
        canvasScaler.scaleFactor = 1/(1024f/screenWidth);
	}
}
