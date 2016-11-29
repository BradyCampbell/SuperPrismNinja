using UnityEngine;
using System.Collections;

public class objMoving : MonoBehaviour {

	public float movespeed;
	public Vector3 userDirection = Vector3.left;

	public float acceleration=1;
	public float maxSpeed=30;
	public float accTimer = 10f;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
		transform.Translate(userDirection * movespeed * Time.deltaTime);

		accTimer -= Time.deltaTime;
		if (accTimer <= 0) {

			movespeed += acceleration;

			if (movespeed > maxSpeed) {
				movespeed = maxSpeed;
			}

			accTimer = Time.deltaTime + 10f;
		}

	
	}
}
