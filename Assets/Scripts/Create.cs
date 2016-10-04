using UnityEngine;
using System.Collections;

public class Create : MonoBehaviour {

	public GameObject obj;
	public Transform generationPoint;

	private float xPosition;
	private float zPosition;

	private float distanceBetween;
	private float time = 0;
	public float frame;

	public float maxDistance;
	public float minDistance;

	public int movespeed = 1;
	public Vector3 userDirection = Vector3.left;



	// Use this for initializations
	void Start () {
		xPosition = generationPoint.transform.position.x;


	
	}

	// Update is called once per frame
	void Update () {
//		Debug.Log (generationPoint.transform.position);
//		if (this.transform.position.x < generationPoint.transform.position.x) {
//			Debug.Log (transform.position);
//			distanceBetween = Random.Range (minDistance, maxDistance);
//
//			this.transform.position = new Vector3 (this.transform.position.x - objectWidth - distanceBetween, this.transform.position.y, this.transform.position.z);
//
//			Instantiate (obj, this.transform.position, this.transform.rotation);
//
//
//		}

		if (time == 0) {

			zPosition = generationPoint.transform.position.z + Random.Range(0,5);

			this.transform.position = new Vector3 (xPosition, this.transform.position.y, zPosition);

			Instantiate (obj, this.transform.position, this.transform.rotation);

			//transform.Translate(userDirection * movespeed * Time.deltaTime);

			//time = Random.Range (100, 200);

			time = frame;
		}

		time--;

	}
}
