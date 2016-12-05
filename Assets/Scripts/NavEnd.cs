using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NavEnd : MonoBehaviour {

	public Text scoreDisplay;
	public Text highDisplay;
	private int highScore;

	// Use this for initialization
	void Start () {

		highScore = PlayerPrefs.GetInt ("highscore");
		if (Scoring.instance.timeScore > highScore) {
			highScore = Scoring.instance.timeScore;
			PlayerPrefs.SetInt ("highscore", highScore);
			PlayerPrefs.Save ();
		}

		scoreDisplay.text = Scoring.instance.timeScore.ToString();
		highDisplay.text = highScore.ToString();
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
