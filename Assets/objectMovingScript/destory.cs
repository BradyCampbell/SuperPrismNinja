using UnityEngine;
using System.Collections;

public class destory : MonoBehaviour {

	public GameObject objDestoryPoint;

	// Use this for initialization
	void Start () {

		objDestoryPoint = GameObject.Find ("destoryObject ");
	
	}
	
	// Update is called once per frame
	void Update () {

		if (gameObject.transform.position.x < objDestoryPoint.transform.position.x) {
			
			Destroy (gameObject);

			//gameObject.SetActive (false);
		}
	
	}
}
