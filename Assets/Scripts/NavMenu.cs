﻿using UnityEngine;
using System.Collections;

public class NavMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp("tab")){
			Application.LoadLevel("Start");
		}
	
	}

	public void turnOffSound()
	{
		SoundManagement.instance.SoundOff ();
	}

	public void turnOnSound()
	{
		SoundManagement.instance.SoundOn ();
	}

	public void turnOffEffects()
	{
		SoundManagement.instance.effectsOn = false;
	}

	public void turnOnEffects()
	{
		SoundManagement.instance.effectsOn = true;
	}

	public void deleteHighScore()
	{
		PlayerPrefs.DeleteKey ("highscore");
	}
}
