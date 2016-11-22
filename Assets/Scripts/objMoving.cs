using UnityEngine;
using System.Collections;

public class objMoving : MonoBehaviour {

	public float movespeed = 1;
	public Vector3 userDirection = Vector3.left;

	public float acceleration=1;
	public float maxSpeed=60;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
		transform.Translate(userDirection * movespeed * Time.deltaTime);

		if (Time.deltaTime >= 5.0f) {

			movespeed += acceleration;

			if (movespeed > maxSpeed)
				movespeed = maxSpeed;
		}

	
	}
}
