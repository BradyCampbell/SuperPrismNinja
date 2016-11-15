using UnityEngine;
using System.Collections;

public class PlayerHitAndDodge : MonoBehaviour {

    public SpriteRenderer spriteRenderer;
	private Animator animator;
	private int flickCount = 3;
	private float flickTime = 0.1f;
    private bool dodging = false;
	private int dodgePowCount = 0;
    public float dodgeTime = 1;
    private bool dodgeCooldown = false;
    public float coolTime = 2;
	private GameObject deathAnim;
	private bool invincible = false;
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
		if (!dodging && !invincible)
        {
			if (coll.gameObject.tag == "DodgePow") {
				dodgePowCount++;
			}
			if (coll.gameObject.tag == "InvinciblePow") {
				Destroy (coll.gameObject);
				isInvincible();
			}
			if (coll.gameObject.tag == "Enemy" && invincible== false)
            {
                Destroy(coll.gameObject);
				SoundManagement.instance.sfxSource.Play ();
				HealthAndPowManager.instance.hp--;
				if (HealthAndPowManager.instance.hp > 0) {
					flicker ();
				}
				if (HealthAndPowManager.instance.hp <= 0)
                {
					if (gameObject.tag == "PlayerShadow") {
						deathAnim = GameObject.Find ("ninjaShadowDeathEffect");
					} 
					else {
						deathAnim = GameObject.Find ("ninjaDeathEffect");
					}
					spriteRenderer.enabled = false;
					Instantiate (deathAnim);
					Invoke("endGame", 1);
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
		else if (coll.gameObject.tag == "Enemy" && invincible == true) 
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
        if (Input.GetKeyUp("space"))
        {
            if (!dodgeCooldown)
            {
                dodging = true;
                spriteRenderer.enabled = false;
				if (dodgePowCount == 0) {
					dodgeCooldown = true;
				} 
				else {
					dodgePowCount--;
				}
				Invoke ("resetDodge", dodgeTime);
            }
        }
    }

    void resetDodge()
    {
		dodging = false;
        spriteRenderer.enabled = true;
		if (dodgeCooldown == true) {
			Invoke ("resetCooldown", coolTime);
		}
    }

    void resetCooldown()
    {
        dodgeCooldown = false;
    }

	void isInvincible()
	{
		invincible = true;
		animator.SetBool ("invincibility", true);
		Invoke("resetInvincible", invincibleTime);
		//Change the character on some visual level i.e. rainbow glow?
	}

	void resetInvincible()
	{
		invincible = false;
		animator.SetBool("invincibility", false);
	}
}