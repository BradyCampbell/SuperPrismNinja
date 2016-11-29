using UnityEngine;
using System.Collections;

public class NavStart : MonoBehaviour {

	public AudioClip titleMusic;

	// Use this for initialization
	void Start () {
		SoundManagement.instance.playMusic(titleMusic);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp("return"))
		{
			Application.LoadLevel("Info");
		}
		if (Input.GetKeyUp("tab"))
		{
			Application.LoadLevel("Menu");
		}

		if (Input.GetKeyUp ("escape")) 
		{
			quitGame();
		}
	}

	public void quitGame()
	{
		Application.Quit();
	}
		
}
