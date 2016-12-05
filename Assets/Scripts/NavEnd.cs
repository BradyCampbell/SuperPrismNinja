using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NavEnd : MonoBehaviour {

	public Text scoreDisplay;
	public Text highDisplay;
	// Use this for initialization
	void Start () {
		
		scoreDisplay.text = Scoring.instance.timeScore.ToString();
		highDisplay.text = PlayerPrefs.GetInt("highscore").ToString();
		Destroy (Scoring.instance);
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKeyUp("return"))
		{
			Application.LoadLevel("GameBasic");
		}
		if (Input.GetKeyUp ("escape")) 
		{
			Application.LoadLevel ("Start");
		}

	}
}
