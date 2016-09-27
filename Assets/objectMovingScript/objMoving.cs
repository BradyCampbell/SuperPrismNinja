using UnityEngine;
using System.Collections;

public class objMoving : MonoBehaviour {

	public int movespeed = 1;
	public Vector3 userDirection = Vector3.left;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(userDirection * movespeed * Time.deltaTime);
	
	}
}
