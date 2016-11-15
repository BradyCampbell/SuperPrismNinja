using UnityEngine;
using System.Collections;

public class HealthAndPowManager : MonoBehaviour {

	public static HealthAndPowManager instance = null;
	public int hp;
	// Use this for initialization
	void Start () {
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);
		DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
