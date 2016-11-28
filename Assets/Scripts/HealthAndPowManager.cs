using UnityEngine;
using System.Collections;

public class HealthAndPowManager : MonoBehaviour {

	public static HealthAndPowManager instance = null;
	public int hp = 5;
	public int lifeCounter = 0;
	public int lifeGetCount = 100;
	public int totalLifeCounter = 0;
	public bool extraLife = false;
	public bool invincible = false;
	public bool dodging = false;

	public bool dodgePow;
	public float dodgeTime = 1;
	private bool dodgeCooldown = false;
	public float coolTime = 2;

	private GameObject player;
	private Animator playerAnimator;
	private GameObject playerShadow;
	private Animator playerShadowAnimator;

	private GameObject HPsprite1;
	private GameObject HPsprite2;
	private GameObject HPsprite3;
	private GameObject HPsprite4;
	private GameObject HPsprite5;
	private GameObject dodgeText;
	private GameObject extraLifeBar;
	private GameObject extraDodgeBar;

	// Use this for initialization
	void Start () {
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);
		DontDestroyOnLoad(gameObject);

		HPsprite1 = GameObject.Find("nin");
		HPsprite2 = GameObject.Find("nin (1)");
		HPsprite3 = GameObject.Find("nin (2)");
		HPsprite4 = GameObject.Find("nin (3)");
		HPsprite5 = GameObject.Find("nin (4)");
		dodgeText = GameObject.Find ("dodge");
		extraLifeBar = GameObject.Find ("extra life");
		extraLifeBar.SetActive (false);
		extraDodgeBar = GameObject.Find ("extra dodge");
		extraDodgeBar.SetActive (false);

		player = GameObject.Find ("Player");
		playerAnimator = player.GetComponent<Animator>();
		playerShadow = GameObject.Find ("Player Shadow");
		playerShadowAnimator = playerShadow.GetComponent<Animator>();
	}

	public void invincibleTrigger()
	{
		playerAnimator.SetBool ("invincibility", true);
		playerShadowAnimator.SetBool ("invincibility", true);
	}

	public void invincibleEnd()
	{
		playerAnimator.SetBool("invincibility", false);
		playerShadowAnimator.SetBool("invincibility", false);
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyUp("space"))
		{
			if (!dodgeCooldown)
			{
				dodging = true;
				playerAnimator.SetBool ("dodging", true);
				playerShadowAnimator.SetBool ("dodging", true);
				if (!dodgePow) {
					dodgeCooldown = true;
					dodgeText.SetActive(false);
				} 
				else {
					dodgePow = false;
					dodgeText.SetActive (false);
				}
				Invoke ("resetDodge", dodgeTime);
			}
		}

		if (hp <= 4){
			HPsprite5.SetActive(false);
		}
		if (hp <= 3) {
			HPsprite4.SetActive(false);
		}
		if (hp <= 2) {
			HPsprite3.SetActive(false);
		}
		if (hp <= 1) {
			HPsprite2.SetActive(false);
		}
		if (hp <= 0) {
			HPsprite1.SetActive(false);
		}

		if (lifeCounter >= lifeGetCount) 
		{
			extraLife = true;
			extraLifeBar.SetActive (true);
			lifeCounter -= lifeGetCount;
		}
	}

	public void getDodgePow()
	{
		dodgePow = true;
		dodgeText.SetActive (true);
	}

	void resetDodge()
	{
		dodging = false;
		playerAnimator.SetBool ("dodging", false);
		playerShadowAnimator.SetBool ("dodging", false);
		if (dodgeCooldown == true) {
			Invoke ("resetCooldown", coolTime);
		}
	}

	void resetCooldown()
	{
		dodgeCooldown = false;
		dodgeText.SetActive(true);
	}
		
	public void respawn()
	{
		hp = 5;
		HPsprite5.SetActive (true);
		HPsprite4.SetActive (true);
		HPsprite3.SetActive (true);
		HPsprite2.SetActive (true);
		HPsprite1.SetActive (true);
		extraLifeBar.SetActive (false);
		extraLife = false;
	}
}
