using UnityEngine;
using System.Collections;

public class spaceShipCreate : MonoBehaviour
{
	
	public GameObject spaceShip;
	private float xPosition;
	private float zPosition;
	public Transform generationPoint;

	float createRate = 5.0f, createRateTimer;
	float rateIncrease = 0.1f, initialCreateDelay = 3.0f;
	int callCounter = 0, callsBeforeRateIncrease = 10;


	// Use this for initialization
	void Start ()
	{

		xPosition = generationPoint.transform.position.x;
		createRateTimer = createRate + initialCreateDelay;
	
	}

	void Update ()
	{
//		if (Time.deltaTime >= 10f) {
			createRateTimer -= Time.deltaTime;
			if (createRateTimer <= 0) {
				CustomInvoke ();
			}
//		}
	}

	void CustomInvoke ()
	{
		spawn ();

		callCounter++;
		if (callCounter >= callsBeforeRateIncrease) {
			createRate -= rateIncrease;
			callCounter = 0;
		}
		createRateTimer = createRate + Random.Range(0,2) + Time.deltaTime;
	}

	void spawn ()
	{
		zPosition = generationPoint.transform.position.z + Random.Range (0, 5);

		this.transform.position = new Vector3 (xPosition, this.transform.position.y, zPosition);

		Instantiate (spaceShip, this.transform.position, this.transform.rotation);



	}
}
