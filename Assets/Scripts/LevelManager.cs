using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public void LoadLevel (string name){
		Debug.Log("Level load requested for: " + name);
        Application.LoadLevel(name);
	}
	
	public void QuitRequest (){
		Debug.Log("Run Away!!!!!");
		Application.Quit();
	}
	
	public void BackStart (string name){
		Debug.Log("Return to Start");
		Application.LoadLevel(name);
	}
	
	
}
