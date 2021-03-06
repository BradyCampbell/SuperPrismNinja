﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthAndPowManager : MonoBehaviour {

	public static HealthAndPowManager instance = null;
	public int hp = 5;
	public int lifeCounter = 0;
	public int lifeGetCount = 100;
	public int totalLifeCounter = 0;
	public bool extraLife = false;

	public bool invincible = false;
	public int invinFlickCount = 3;
	private float invinFlickTime = 0.1f;
	public bool invinStack = false;

	public bool dodging = false;
	public bool dodgePow = false;
	public float dodgeTime = 1;
	private bool dodgeCooldown = false;
	public float coolTime = 2;

	private GameObject player;
	private Animator playerAnimator;
	private GameObject playerShadow;
	private Animator playerShadowAnimator;

	public GameObject smokeEffect;

	private GameObject HPsprite1;
	private GameObject HPsprite2;
	private GameObject HPsprite3;
	private GameObject HPsprite4;
	private GameObject HPsprite5;
	private GameObject dodgeText;
	private GameObject extraLifeBar;
	private GameObject extraDodgeBar;
	private GameObject pauseScreen;
	private GameObject starfield;
	public Text lifeCounterText;

	public AudioClip gameMusic;
	public AudioClip pauseSound;
	public AudioClip unpauseSound;
	public AudioClip dodgeSound;

	public bool spawnLock = false;
	public bool paused = false;
	private bool pauseResume = false;

	// Use this for initialization
	void Start () {
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);

		SoundManagement.instance.playMusic(gameMusic);

		HPsprite1 = GameObject.Find("nin");
		HPsprite2 = GameObject.Find("nin (1)");
		HPsprite3 = GameObject.Find("nin (2)");
		HPsprite4 = GameObject.Find("nin (3)");
		HPsprite5 = GameObject.Find("nin (4)");
		dodgeText = GameObject.Find ("Blink");
		extraLifeBar = GameObject.Find ("extra life");
		extraLifeBar.SetActive (false);
		extraDodgeBar = GameObject.Find ("extra dodge");
		extraDodgeBar.SetActive (false);

		player = GameObject.Find ("Player");
		playerAnimator = player.GetComponent<Animator>();
		playerShadow = GameObject.Find ("Player Shadow");
		playerShadowAnimator = playerShadow.GetComponent<Animator>();

		lifeCounterText.text = totalLifeCounter.ToString();

		starfield = GameObject.Find ("StarfieldBG");

		pauseScreen = GameObject.Find ("Pause");
		pauseScreen.SetActive (false);

		if (!SoundManagement.instance.effectsOn) {
			starfield.SetActive (false);
		} else {
			starfield.SetActive (true);
		}
	}

	public void invincibleTrigger()
	{
		playerAnimator.SetBool ("invincibility", true);
		playerShadowAnimator.SetBool ("invincibility", true);
	}

	public void invinFlicker()
	{
		if (invinFlickCount > 0) {
			playerAnimator.SetBool("invincibility", false);
			playerShadowAnimator.SetBool("invincibility", false);
			invinFlickCount--;
			Invoke ("invinFlickerFinish", invinFlickTime);
		} 
		else {
			invinFlickCount = 3;
			playerAnimator.SetBool("invincibility", false);
			playerShadowAnimator.SetBool("invincibility", false);
			invincible = false;
		}
	}

	void invinFlickerFinish()
	{
		playerAnimator.SetBool ("invincibility", true);
		playerShadowAnimator.SetBool ("invincibility", true);
		Invoke("invinFlicker", invinFlickTime);
	}
	
	// Update is called once per frame
	void Update () {
		lifeCounterText.text = totalLifeCounter.ToString();

		if (Input.GetKeyDown("space") && !invincible)
		{
			if (!dodgeCooldown && !paused)
			{
				dodging = true;
				SoundManagement.instance.playSFX (dodgeSound);
				playerAnimator.SetBool ("dodging", true);
				if (SoundManagement.instance.effectsOn) {
					Instantiate (smokeEffect, player.transform.position, player.transform.rotation);
				}
				playerShadowAnimator.SetBool ("dodging", true);
				if (SoundManagement.instance.effectsOn) {
					Instantiate (smokeEffect, playerShadow.transform.position, playerShadow.transform.rotation);
				}
				if (!dodgePow) {
					dodgeCooldown = true;
					dodgeText.SetActive(false);
				} 
				else {
					dodgePow = false;
					extraDodgeBar.SetActive (false);
				}
				Invoke ("resetDodge", dodgeTime);
			}
		}

		if (Input.GetKeyDown ("return") || Input.GetKeyDown ("escape")) {
			if (!paused) {
				paused = true;
				Time.timeScale = 0.0f;
				pauseScreen.SetActive (true);
				SoundManagement.instance.playSFX (pauseSound);
				if (SoundManagement.instance.musicSource.isPlaying) {
					SoundManagement.instance.musicSource.Pause();
					pauseResume = true;
				}
			} else {
				endPause ();
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
		extraDodgeBar.SetActive (true);
	}

	public void endPause()
	{
		paused = false;
		Time.timeScale = 1.0f;
		pauseScreen.SetActive (false);
		SoundManagement.instance.playSFX(unpauseSound);
		if (pauseResume) {
			SoundManagement.instance.musicSource.UnPause ();
			pauseResume = false;
		}
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
