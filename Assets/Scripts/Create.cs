﻿using UnityEngine;
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
	private int maxRange = 100;

	public int objMinPercent;
	public int obj1Percent;
	public int obj2Percent;
	public int obj3Percent;
	public int obj4Percent;
	public int obj5Percent;
	public int spaceshipPercent;

	private int obj1Range;
	private int obj2Range;
	private int obj3Range;
	private int obj4Range;
	private int obj5Range;
	private int spaceshipRange;

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

		calculateRanges ();

	}


	void calculateRanges()
	{
		spaceshipRange = maxRange - spaceshipPercent; 
		obj5Range = spaceshipRange - obj5Percent; 
		obj4Range = obj5Range - obj4Percent; 
		obj3Range = obj4Range - obj3Percent; 
		obj2Range = obj3Range - obj2Percent; 
		obj1Range = obj2Range - obj1Percent; 

		if (obj1Range < objMinPercent) {
			maxRange = maxRange + (objMinPercent - obj1Range);
			calculateRanges ();
		}
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

		int randNum = Random.Range (0, (maxRange - 1));

		if (spaceShipSpawn <= spaceShipTime) {
			randNum = Random.Range (0, (spaceshipRange - 1));
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
		if (num >= 0 && num < obj1Range) {


			zPosition = generationPoint.transform.position.z + Random.Range (0, 5);

			this.transform.position = new Vector3 (xPosition, this.transform.position.y, zPosition);

			Instantiate (obj, this.transform.position, this.transform.rotation);
		}
		if (num >= obj1Range && num < obj2Range) {


			zPosition = generationPoint.transform.position.z + Random.Range (0, 5);

			this.transform.position = new Vector3 (xPosition, this.transform.position.y, zPosition);

			Instantiate (obj1, this.transform.position, this.transform.rotation);
		}
		if (num >= obj2Range && num < obj3Range) {


			zPosition = generationPoint.transform.position.z + Random.Range (0, 5);

			this.transform.position = new Vector3 (xPosition, this.transform.position.y, zPosition);

			Instantiate (obj2, this.transform.position, this.transform.rotation);
		}
		if (num >= obj3Range && num < obj4Range) {


			zPosition = generationPoint.transform.position.z + Random.Range (0, 5);

			this.transform.position = new Vector3 (xPosition, this.transform.position.y, zPosition);

			Instantiate (obj3, this.transform.position, this.transform.rotation);
		}
		if (num >= obj4Range && num < obj5Range) {


			zPosition = generationPoint.transform.position.z + Random.Range (0, 5);

			this.transform.position = new Vector3 (xPosition, this.transform.position.y, zPosition);

			Instantiate (obj4, this.transform.position, this.transform.rotation);
		}
		if (num >= obj5Range && num < spaceshipRange) {


			zPosition = generationPoint.transform.position.z + Random.Range (0, 5);

			this.transform.position = new Vector3 (xPosition, this.transform.position.y, zPosition);

			Instantiate (obj5, this.transform.position, this.transform.rotation);
		}

		if (num >= spaceshipRange && num < maxRange) {

			zPosition = generationPoint.transform.position.z + Random.Range (0, 5);

			this.transform.position = new Vector3 (xPosition, this.transform.position.y, zPosition);

			Instantiate (spaceShip, this.transform.position, this.transform.rotation);
		}
	}
}
