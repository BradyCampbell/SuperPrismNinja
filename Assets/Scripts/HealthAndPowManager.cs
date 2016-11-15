using UnityEngine;
using System.Collections;

public class HealthAndPowManager : MonoBehaviour {

	public static HealthAndPowManager instance = null;
	public int hp;

	private GameObject sprite1;
	private SpriteRenderer sprite1renderer;
	private GameObject sprite2;
	private SpriteRenderer sprite2renderer;
	private GameObject sprite3;
	private SpriteRenderer sprite3renderer;
	private GameObject sprite4;
	private SpriteRenderer sprite4renderer;
	private GameObject sprite5;
	private SpriteRenderer sprite5renderer;
	// Use this for initialization
	void Start () {
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);
		DontDestroyOnLoad(gameObject);

		sprite1 = GameObject.Find("nin");
		sprite1renderer = sprite1.GetComponent<SpriteRenderer>;
		sprite2 = GameObject.Find("nin (1)");
		sprite2renderer = sprite2.GetComponent<SpriteRenderer>;
		sprite3 = GameObject.Find("nin (2)");
		sprite3renderer = sprite3.GetComponent<SpriteRenderer>;
		sprite4 = GameObject.Find("nin (3)");
		sprite4renderer = sprite4.GetComponent<SpriteRenderer>;
		sprite5 = GameObject.Find("nin (4)");
		sprite5renderer = sprite5.GetComponent<SpriteRenderer>;
	}
	
	// Update is called once per frame
	void Update () {
		if (hp > 0) {
			sprite1renderer.enabled = true;
			if (hp > 1) {
				sprite2renderer.enabled = true;
				if (hp > 2) {
					sprite3renderer.enabled = true;
					if (hp > 3) {
						sprite4renderer.enabled = true;
						if (hp > 4) {
							sprite5renderer.enabled = true;
						} else {
							sprite5renderer.enabled = false;
						}
					} else {
						sprite4renderer.enabled = false;
					}
				} else {
					sprite3renderer.enabled = false;
				}
			} else {
				sprite2renderer.enabled = false;
			}
		} else {
			sprite1renderer.enabled = false;
		}
	
	}
}
