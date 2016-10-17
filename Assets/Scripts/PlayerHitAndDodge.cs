using UnityEngine;
using System.Collections;

public class PlayerHitAndDodge : MonoBehaviour {

    public SpriteRenderer spriteRenderer;
	public int health;
    private bool dodging = false;
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
                dodgeCooldown = true;
                Invoke("resetDodge", dodgeTime);
            }
        }
    }

    void resetDodge()
    {
		dodging = false;
        spriteRenderer.enabled = true;
        Invoke("resetCooldown", coolTime);
    }

    void resetCooldown()
    {
        dodgeCooldown = false;
    }
}
