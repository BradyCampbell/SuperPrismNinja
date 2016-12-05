using UnityEngine;
using System.Collections;

public class ReflectMovement : MonoBehaviour 
{
	private int posTrack;
	private int posTrackx;
	// Use this for initialization
	void Start ()
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
		if (!HealthAndPowManager.instance.paused) {
			if ((Input.GetKeyDown (KeyCode.DownArrow) && (posTrack > 0)) || (Input.GetKeyDown (KeyCode.S)) && (posTrack > 0)) {
				Vector3 position = this.transform.position;
				position.y += 1.32f;
				posTrack--;
				this.transform.position = position;
			}
			if ((Input.GetKeyDown (KeyCode.UpArrow) && (posTrack < 2)) || (Input.GetKeyDown (KeyCode.W)) && (posTrack < 2)) {
				Vector3 position = this.transform.position;
				position.y -= 1.32f;
				posTrack++;
				this.transform.position = position;
			}
			if ((Input.GetKeyDown (KeyCode.RightArrow) && (posTrackx < 2)) || (Input.GetKeyDown (KeyCode.D)) && (posTrackx < 2)) {
				Vector3 position = this.transform.position;
				position.x += 1.32f;
				posTrackx++;
				this.transform.position = position;
			}
			if ((Input.GetKeyDown (KeyCode.LeftArrow) && (posTrackx > 0)) || (Input.GetKeyDown (KeyCode.A)) && (posTrackx > 0)) {
				Vector3 position = this.transform.position;
				position.x -= 1.32f;
				posTrackx--;
				this.transform.position = position;
			}
		}
	}
}
