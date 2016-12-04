using UnityEngine;
using System.Collections;

public class Create : MonoBehaviour
{

	public GameObject obj;
	public GameObject obj1;
	public GameObject obj2;
	public GameObject obj3;
	public GameObject obj4;
	public GameObject obj5;
	public Transform generationPoint;
	public GameObject spaceShip;

	private float xPosition;
	private float zPosition;

	public float spaceShipTime;
	private int spaceShipSpawn;

	float createRate = 1.5f, createRateTimer;
	float rateIncrease = 0.1f, initialCreateDelay = 3.0f;
	int callCounter = 0, callsBeforeRateIncrease = 10;


	public int movespeed = 1;
	public Vector3 userDirection = Vector3.left;



	// Use this for initializations
	void Start ()
	{
		xPosition = generationPoint.transform.position.x;

		spaceShipSpawn = 0;

		createRateTimer = createRate + initialCreateDelay;

	}


	void Update ()
	{
		createRateTimer -= Time.deltaTime;
		if (createRateTimer <= 0) {
			CustomInvoke ();
		}
	}

	void CustomInvoke ()
	{
		spaceShipSpawn++;

		int randNum = Random.Range (0, 20);

		if (spaceShipSpawn <= spaceShipTime) {
			randNum = Random.Range (0, 17);
		}

		spawn (randNum);

		callCounter++;
		if (callCounter >= callsBeforeRateIncrease) {
			createRate -= rateIncrease;
			callCounter = 0;
		}
		createRateTimer = createRate + Random.Range(0,4) + Time.deltaTime;
	}

	void spawn (int num)
	{
		if (num >= 0 && num <= 3) {


			zPosition = generationPoint.transform.position.z + Random.Range (0, 5);

			this.transform.position = new Vector3 (xPosition, this.transform.position.y, zPosition);

			Instantiate (obj, this.transform.position, this.transform.rotation);
		}
		if (num >= 4 && num <= 7) {


			zPosition = generationPoint.transform.position.z + Random.Range (0, 5);

			this.transform.position = new Vector3 (xPosition, this.transform.position.y, zPosition);

			Instantiate (obj1, this.transform.position, this.transform.rotation);
		}
		if (num >= 8 && num <= 11) {


			zPosition = generationPoint.transform.position.z + Random.Range (0, 5);

			this.transform.position = new Vector3 (xPosition, this.transform.position.y, zPosition);

			Instantiate (obj2, this.transform.position, this.transform.rotation);
		}
		if (num >= 12 && num <= 14) {


			zPosition = generationPoint.transform.position.z + Random.Range (0, 5);

			this.transform.position = new Vector3 (xPosition, this.transform.position.y, zPosition);

			Instantiate (obj3, this.transform.position, this.transform.rotation);
		}
		if (num == 15 || num == 16) {


			zPosition = generationPoint.transform.position.z + Random.Range (0, 5);

			this.transform.position = new Vector3 (xPosition, this.transform.position.y, zPosition);

			Instantiate (obj4, this.transform.position, this.transform.rotation);
		}
		if (num == 17) {


			zPosition = generationPoint.transform.position.z + Random.Range (0, 5);

			this.transform.position = new Vector3 (xPosition, this.transform.position.y, zPosition);

			Instantiate (obj5, this.transform.position, this.transform.rotation);
		}

		if (num >= 18 && num <= 20) {

			zPosition = generationPoint.transform.position.z + Random.Range (0, 5);

			this.transform.position = new Vector3 (xPosition, this.transform.position.y, zPosition);

			Instantiate (spaceShip, this.transform.position, this.transform.rotation);
		}
	}
}
