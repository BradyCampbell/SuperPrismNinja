using UnityEngine;
using System.Collections;

public class PlayerHitAndDodge : MonoBehaviour {

    public SpriteRenderer spriteRenderer;
	public int health;
    private bool dodging = false;
	private int dodgePowCount = 0;
    public float dodgeTime = 1;
    private bool dodgeCooldown = false;
    public float coolTime = 2;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = true;
    }

	void OnCollisionEnter2D(Collision2D coll)
	{
        if (!dodging)
        {
			if (coll.gameObject.tag == "DodgePow") {
				dodgePowCount++;
			}
            if (coll.gameObject.tag == "Enemy")
            {
                Destroy(coll.gameObject);
				SoundManagement.instance.sfxSource.Play ();
                health--;
                if (health <= 0)
                {
                    Destroy(gameObject);
                }
            }
        }
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
}
