using UnityEngine;
using System.Collections;

public class PlayerHitAndDodge : MonoBehaviour {

    public SpriteRenderer spriteRenderer;
	private Animator animator;
	private int flickCount = 3;
	private float flickTime = 0.1f;
	private GameObject deathAnim;
	public float invincibleTime = 6;
	public int num_c1;
	public int num_c2;
	public int num_c3;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = true;
		animator = GetComponent<Animator> ();
		num_c1 = Scoring.num_c1;
		num_c2 = Scoring.num_c2;
		num_c3 = Scoring.num_c3;
    }

	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "DodgePow") {
			Destroy (coll.gameObject);
			HealthAndPowManager.instance.getDodgePow();
		}
		if (coll.gameObject.tag == "InvinciblePow") {
			Destroy (coll.gameObject);
			isInvincible();
		}
		if (coll.gameObject.tag == "lifeGem") {
			Destroy (coll.gameObject);
			HealthAndPowManager.instance.lifeCounter++;
			HealthAndPowManager.instance.totalLifeCounter++;
		}
		if (!HealthAndPowManager.instance.dodging && !HealthAndPowManager.instance.invincible)
        {
			if (coll.gameObject.tag == "Enemy")
            {
                Destroy(coll.gameObject);
				SoundManagement.instance.sfxSource.Play ();
				HealthAndPowManager.instance.hp--;
				if (HealthAndPowManager.instance.hp > 0) {
					flicker ();
				}
				if (HealthAndPowManager.instance.hp <= 0)
                {
					if (HealthAndPowManager.instance.extraLife) {
						HealthAndPowManager.instance.respawn();
					} 
					else {
						if (gameObject.tag == "PlayerShadow") {
							deathAnim = GameObject.Find ("ninjaShadowDeathEffect");
						} else {
							deathAnim = GameObject.Find ("ninjaDeathEffect");
						}
						animator.SetTrigger ("dead");
						Instantiate (deathAnim);
						Invoke ("endGame", 1);
					}
                }
            }
			if (coll.gameObject.tag == "Collectible1") 
			{
				Destroy (coll.gameObject);
				num_c1++;
			}
			if (coll.gameObject.tag == "Collectible2") 
			{
				Destroy (coll.gameObject);
				num_c2++;
			}
			if (coll.gameObject.tag == "Collectible3") 
			{
				Destroy (coll.gameObject);
				num_c3++;
			}
        }
		else if (coll.gameObject.tag == "Enemy" && HealthAndPowManager.instance.invincible) 
		{
			Destroy(coll.gameObject);
			//Maybe seperate sound?
		}
	}

	void endGame()
	{
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
		HealthAndPowManager.instance.invincible = false;
		HealthAndPowManager.instance.invincibleEnd ();
	}
}