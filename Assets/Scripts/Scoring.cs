using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Scoring : MonoBehaviour {

	public static Scoring instance = null;


	float startTime;
	public int timeScore;
	public int num_c1 = 0;
	public int num_c2 = 0;
	public int num_c3 = 0;

	public bool dead = false;

	// Use this for initialization
	void Start () 
	{
		if (instance == null) {
			instance = this;
		}
		else if (instance != this)
			Destroy (gameObject);
		DontDestroyOnLoad (gameObject);

		startTime = Time.time;
	}

	// Update is called once per frame
	void Update () {
		if (!dead) {
			timeScore = (int)(Time.time - startTime);
		} else {
			calculateScore ();
		}
	}

	void calculateScore()
	{
		timeScore = timeScore + (num_c1*1)+ (num_c2*5)+ (num_c3*10);

	}
}