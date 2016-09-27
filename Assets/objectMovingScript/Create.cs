using UnityEngine;
using System.Collections;

public class Create : MonoBehaviour {

	public GameObject obj;
	public Transform generationPoint;
	public float distanceBetween;
	private float objectWidth;

	public float maxDistance;
	public float minDistance;

//	public pooling pool;
	// Use this for initialization
	void Start () {
		objectWidth = obj.GetComponent<BoxCollider>().size.x;

	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (transform.position.x < generationPoint.transform.transform.position.x) {

			distanceBetween = Random.Range (minDistance, maxDistance);

			transform.position = new Vector3 (transform.position.x + objectWidth + distanceBetween, transform.position.y, transform.position.z);

			Instantiate (obj, transform.position, transform.rotation);

//			GameObject newObj = pool.GetPooledObject (); 
//
//			newObj.transform.position = transform.position;
		}
	}
}
