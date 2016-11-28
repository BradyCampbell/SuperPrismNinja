using UnityEngine;
using System.Collections;

public class NavStart : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
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
