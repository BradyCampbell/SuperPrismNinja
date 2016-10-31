using UnityEngine;
using System.Collections;

public class Create : MonoBehaviour {

	public GameObject obj;
	public GameObject obj1;
	public GameObject obj2;
	public GameObject obj3;
	public GameObject obj4;
	public GameObject obj5;
	public Transform generationPoint;

	private float xPosition;
	private float zPosition;

	private float distanceBetween;
	public float timeBetween;
	private float timeincrease;
	public float speedUpTime;


	public int movespeed = 1;
	public Vector3 userDirection = Vector3.left;



	// Use this for initializations
	void Start () {
		xPosition = generationPoint.transform.position.x;
		 timeincrease = 0;


	
	}

	// Update is called once per frame
	void Update () {
		if (Time.time == speedUpTime) {
			timeincrease += 0.2F;
			speedUpTime += Time.time;
		}


		if (Time.time > distanceBetween) {

			int gameobj = Random.Range (0, 5);
			distanceBetween = Time.time + timeBetween + timeincrease + gameobj;
			if(gameobj == 0){
				

				zPosition = generationPoint.transform.position.z + Random.Range (0, 5);

				this.transform.position = new Vector3 (xPosition, this.transform.position.y, zPosition);

				Instantiate (obj, this.transform.position, this.transform.rotation);
			}
			if(gameobj == 1){


				zPosition = generationPoint.transform.position.z + Random.Range (0, 5);

				this.transform.position = new Vector3 (xPosition, this.transform.position.y, zPosition);

				Instantiate (obj1, this.transform.position, this.transform.rotation);
			}
			if(gameobj == 2){


				zPosition = generationPoint.transform.position.z + Random.Range (0, 5);

				this.transform.position = new Vector3 (xPosition, this.transform.position.y, zPosition);

				Instantiate (obj2, this.transform.position, this.transform.rotation);
			}
			if(gameobj == 3){


				zPosition = generationPoint.transform.position.z + Random.Range (0, 5);

				this.transform.position = new Vector3 (xPosition, this.transform.position.y, zPosition);

				Instantiate (obj3, this.transform.position, this.transform.rotation);
			}
			if(gameobj == 4){


				zPosition = generationPoint.transform.position.z + Random.Range (0, 5);

				this.transform.position = new Vector3 (xPosition, this.transform.position.y, zPosition);

				Instantiate (obj4, this.transform.position, this.transform.rotation);
			}
			if(gameobj == 5){


				zPosition = generationPoint.transform.position.z + Random.Range (0, 5);

				this.transform.position = new Vector3 (xPosition, this.transform.position.y, zPosition);

				Instantiate (obj5, this.transform.position, this.transform.rotation);
			}

		}



	}
}
