using UnityEngine;
using System.Collections;

public class Scoring : MonoBehaviour {
	
	float startTime;
	int timeScore;
	public static int num_c1= 0;
	public static int num_c2= 0;
	public static int num_c3= 0;

	// Use this for initialization
	void Start () 
	{
		startTime = Time.time;
	}

	// Update is called once per frame
	void Update () {
		timeScore = (int)(Time.time- startTime);
	}

	int calculateScore()
	{
		return timeScore+ (num_c1*1)+ (num_c2*5)+ (num_c3*10);
	}
}