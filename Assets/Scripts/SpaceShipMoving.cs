using UnityEngine;
using System.Collections;

public class SpaceShipMoving : MonoBehaviour
{
	public int movespeed;
	public Vector3 upDirection = Vector3.up;
	public Vector3 downDirection = Vector3.down;
	private float yPosition;
	private int rand;
	private float destory= 200;
	private int count = 0;

	// Use this for initialization
	void Start ()
	{
		yPosition = this.transform.position.y;
		rand = Random.Range (0, 3);


	}

	// Update is called once per frame
	void Update ()
	{
		count++;

		if (yPosition <= 0) {
			if (rand == 0) {
				if (this.transform.position.y < -.5) {
				
					transform.Translate (upDirection * movespeed * Time.deltaTime, Space.World);
				} 
			} else if (rand == 1) {
				if (this.transform.position.y < -1.79) {

					transform.Translate (upDirection * movespeed * Time.deltaTime, Space.World);
				} 
			} else if (rand == 2) {
				if (this.transform.position.y < -3.11) {

					transform.Translate (upDirection * movespeed * Time.deltaTime, Space.World);
				} 
			}

		} else if (yPosition > 0) {
			if (rand == 0) {
				if (this.transform.position.y >= 1.7) {
				
					transform.Translate (downDirection * movespeed * Time.deltaTime, Space.World);
				} else {
				
					Destroy (gameObject);
				}
			}
			if (rand == 1) {
				if (this.transform.position.y >= 3.12) {

					transform.Translate (downDirection * movespeed * Time.deltaTime, Space.World);
				}
			}
			if (rand == 2) {
				if (this.transform.position.y >= 4.4) {

					transform.Translate (downDirection * movespeed * Time.deltaTime, Space.World);
				}
			}
		}



		if (count > destory) {
			Destroy (gameObject);
		}
	
	}
}
