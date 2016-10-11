using UnityEngine;
using System.Collections;

public class ReflectMovement : MonoBehaviour 
{
	private int posTrack;
	// Use this for initialization
	void Start ()
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.DownArrow) && (posTrack > 0))
		{
			Vector3 position = this.transform.position;
			position.y += 1.32f;
			posTrack--;
			this.transform.position = position;
		}
		if (Input.GetKeyDown(KeyCode.UpArrow) && (posTrack < 2))
		{
			Vector3 position = this.transform.position;
			position.y -= 1.32f;
			posTrack++;
			this.transform.position = position;
		}
	}
}
