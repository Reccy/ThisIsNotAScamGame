using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CaretPatch : MonoBehaviour {

	/*
     * This code aims to fix the Unity caret bug 
     * Change the x and y pivot values to move the pivot
     * Place this script on the caret's parent object
     */

    private GameObject caret;
    private bool patchApplied;
    public float xOffset, yOffset;

    void Start ()
    {
        patchApplied = false;
    }

    void Update ()
    {
        if(!patchApplied)
        {
            try
            {
                caret.GetComponent<RectTransform>().pivot = new Vector2(caret.GetComponent<RectTransform>().pivot.x + xOffset, caret.GetComponent<RectTransform>().pivot.y + yOffset);
                patchApplied = true;
            }
            catch (System.NullReferenceException e)
            {
                try
                {
                    caret = transform.Find(transform.name + " Input Caret").gameObject;
                }
                catch (System.NullReferenceException f)
                {}
            }
        }
    }
}
