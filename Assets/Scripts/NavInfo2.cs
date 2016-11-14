using UnityEngine;
using System.Collections;

public class NavInfo2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp("backspace")){
			Application.LoadLevel("Info");
		}
		if (Input.GetKeyUp ("return")) {
			Application.LoadLevel ("GameBasic");
		}
	}
}
