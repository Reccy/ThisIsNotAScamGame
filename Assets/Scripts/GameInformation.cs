﻿using UnityEngine;
using System.Collections;

public class GameInformation : MonoBehaviour {

    public static string pcName;
    public static int peopleScammed;
    public static bool scammedJames;
    public static bool scammedKid;
    public static bool scammedOldLady;
    public static bool scammedOtherLady;
    public static bool scammedAngryGuy;

	void Start () 
    {
        DontDestroyOnLoad(this);
        pcName = "Riley";
        scammedJames = false;
        scammedKid = false;
        scammedOldLady = false;
        scammedOtherLady = false;
        scammedAngryGuy = false;
        peopleScammed = 0;
	}
}