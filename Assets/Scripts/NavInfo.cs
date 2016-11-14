using UnityEngine;
using System.Collections;

public class NavInfo : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp("backspace")){
			Application.LoadLevel("Start");
		}
		if (Input.GetKeyUp ("return")) {
			Application.LoadLevel ("Info2");
		}
	
	}
}
