using UnityEngine;
using System.Collections;

public class PlayerHitAndDodge : MonoBehaviour {

	public AudioClip playerHit;
	public AudioClip enemyKill;
	public AudioClip playerDead;
	public AudioClip getPowerup;
	public AudioClip getGem;

    public SpriteRenderer spriteRenderer;
	private Animator animator;
	private int flickCount = 3;
	private float flickTime = 0.1f;
	public GameObject deathAnim;
	public GameObject enemyDeathAnim;
	public float invincibleTime = 6;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = true;
		animator = GetComponent<Animator> ();
    }

	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "DodgePow") {
			SoundManagement.instance.playSFX(getPowerup);
			Destroy (coll.gameObject);
			HealthAndPowManager.instance.getDodgePow();
		}
		if (coll.gameObject.tag == "InvinciblePow") {
			SoundManagement.instance.playSFX(getPowerup);
			Destroy (coll.gameObject);
			if (HealthAndPowManager.instance.invincible) {
				HealthAndPowManager.instance.invinStack = true;
			} else {
				SoundManagement.instance.jingleTime ();
				isInvincible ();
			}
		}
		if (coll.gameObject.tag == "lifeGem") {
			SoundManagement.instance.playSFX(getGem);
			Destroy (coll.gameObject);
			HealthAndPowManager.instance.lifeCounter++;
			HealthAndPowManager.instance.totalLifeCounter++;
		}
		if (coll.gameObject.tag == "Collectible1") 
		{
			SoundManagement.instance.playSFX(getPowerup);
			Destroy (coll.gameObject);
			Scoring.instance.num_c1++;
		}
		if (coll.gameObject.tag == "Collectible2") 
		{
			SoundManagement.instance.playSFX(getPowerup);
			Destroy (coll.gameObject);
			Scoring.instance.num_c2++;
		}
		if (coll.gameObject.tag == "Collectible3") 
		{
			SoundManagement.instance.playSFX(getPowerup);
			Destroy (coll.gameObject);
			Scoring.instance.num_c3++;
		}
		if (!HealthAndPowManager.instance.dodging && !HealthAndPowManager.instance.invincible) {
			if (coll.gameObject.tag == "Enemy" || coll.gameObject.tag == "spaceship") {
				Destroy (coll.gameObject);
				SoundManagement.instance.playSFX (playerHit);
				HealthAndPowManager.instance.hp--;
				if (HealthAndPowManager.instance.hp > 0) {
					flicker ();
				}
				if (HealthAndPowManager.instance.hp <= 0) {
					if (HealthAndPowManager.instance.extraLife) {
						HealthAndPowManager.instance.respawn ();
					} else {
						SoundManagement.instance.playSFX (playerDead);
						animator.SetTrigger ("dead");
						if (SoundManagement.instance.effectsOn) {
							Instantiate (deathAnim, transform.position, transform.rotation);
						}
						Invoke ("endGame", 1);
					}
				}
			}
		} else if (coll.gameObject.tag == "Enemy" && HealthAndPowManager.instance.invincible) {
			if (SoundManagement.instance.effectsOn) {
				Instantiate (enemyDeathAnim, coll.gameObject.transform.position, coll.gameObject.transform.rotation);
			}
			Destroy (coll.gameObject);
			SoundManagement.instance.playSFX (enemyKill);
			Scoring.instance.num_c1++;
		} else if (coll.gameObject.tag == "spaceship" && HealthAndPowManager.instance.invincible) {
			if (SoundManagement.instance.effectsOn) {
				Instantiate (enemyDeathAnim, coll.gameObject.transform.position, coll.gameObject.transform.rotation);
			}
			HealthAndPowManager.instance.spawnLock = false;
			Destroy (coll.gameObject);
			SoundManagement.instance.playSFX (enemyKill);
			Scoring.instance.num_c1++;
		}
	}

	void endGame()
	{
		SoundManagement.instance.musicSource.Stop ();
		Scoring.instance.dead = true;
		Application.LoadLevel("End");
	}

	void flicker()
	{
		if (flickCount > 0) {
			spriteRenderer.enabled = false;
			flickCount--;
			Invoke ("flickerFinish", flickTime);
		} 
		else {
			flickCount = 3;
		}
	}

	void flickerFinish()
	{
		spriteRenderer.enabled = true;
		Invoke("flicker", flickTime);
	}

    void Update()
    {
    }
		
	void isInvincible()
	{
		HealthAndPowManager.instance.invincible = true;
		HealthAndPowManager.instance.invincibleTrigger();
		Invoke("resetInvincible", invincibleTime);
	}

	void resetInvincible()
	{
		if (HealthAndPowManager.instance.invinStack) {
			HealthAndPowManager.instance.invinStack = false;
			Invoke ("resetInvincible", invincibleTime);
		} else {
			HealthAndPowManager.instance.invinFlicker ();
			SoundManagement.instance.jingleStop ();
		}
	}
}