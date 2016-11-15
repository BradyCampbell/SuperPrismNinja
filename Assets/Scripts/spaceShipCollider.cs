using UnityEngine;
using System.Collections;

public class spaceShipCollider : MonoBehaviour {

	private BoxCollider2D laserCollider;


	// Use this for initialization
	void Start () {
		laserCollider = this.GetComponent<BoxCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 v = this.GetComponent<SpriteRenderer>().bounds.size;

		laserCollider.size = v;
	}
}
