using UnityEngine;
using System.Collections;

public class HealthAndPowManager : MonoBehaviour {

	public static HealthAndPowManager instance = null;
	public int hp = 5;
	public bool invincible = false;

	private GameObject sprite1;
	private GameObject sprite2;
	private GameObject sprite3;
	private GameObject sprite4;
	private GameObject sprite5;

	// Use this for initialization
	void Start () {
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);
		DontDestroyOnLoad(gameObject);

		sprite1 = GameObject.Find("nin");
		sprite2 = GameObject.Find("nin (1)");
		sprite3 = GameObject.Find("nin (2)");
		sprite4 = GameObject.Find("nin (3)");
		sprite5 = GameObject.Find("nin (4)");
	}
	
	// Update is called once per frame
	void Update () {
		if (hp == 4){
			Destroy (sprite5);
		}
		if (hp == 3) {
			Destroy (sprite4);
		}
		if (hp == 2) {
			Destroy (sprite3);
		}
		if (hp == 1) {
			Destroy (sprite2);
		}
		if (hp == 0) {
			Destroy (sprite1);
		}
	}
}
