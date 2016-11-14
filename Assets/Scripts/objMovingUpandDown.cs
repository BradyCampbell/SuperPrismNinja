using UnityEngine;
using System.Collections;

public class objMovingUpandDown : MonoBehaviour {
	public int movespeed = 1;
	public Vector3 upDirection = Vector3.up;
	public Vector3 downDirection = Vector3.down;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float tim = Time.time;
		if (tim % 2 < 1) {
			transform.Translate (upDirection * movespeed * Time.deltaTime);
		} else if(tim % 2 >= 1){
			transform.Translate (downDirection * movespeed * Time.deltaTime);
		}
	}
}
