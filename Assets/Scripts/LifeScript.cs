using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeScript : MonoBehaviour {
    
	private float currentLife;
	private float hitCd = 0.1f;
	private float hitTimer = 0;
	private bool hasRb;
	private bool beingHit;
	private Rigidbody parentRb;
	private Color normalColor;

	private GameObject destroyedBy;
	private GameObject hitBy;

	public float maxLife;
	public LayerMask getsHurtBy;
    public Color hitColor;
	public GameObject HitBy { get { return hitBy; } }

	void Awake() {
		currentLife = maxLife;
	}

	void Start () {
        if(GetComponentInParent<Rigidbody>() != null) {
            parentRb = GetComponentInParent<Rigidbody>();
            hasRb = true;
		} else {
            hasRb = false;
        }
        normalColor = GetComponentInParent<Renderer>().material.color;
        beingHit = false;
    }

    void Update() {
        if (hitTimer > 0)
            hitTimer -= Time.deltaTime;
        else if (beingHit) {
            SetParentColor(normalColor);
            beingHit = false;
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (((1 << col.gameObject.layer) & getsHurtBy) != 0) {
            //KNOCKBACK
            if (hasRb) {
				Bullet bulletComponent = col.GetComponent<Bullet>();
				ReceiveDamage (bulletComponent.BulletDamage);
				hitBy = bulletComponent.BulletSource;
				float knockback = bulletComponent.BulletKnockback;
                if (knockback == 0)
                    return;
                Vector3 colliderDir = bulletComponent.GetDirection();
                parentRb.AddForce(colliderDir * knockback, ForceMode.Impulse);
            }
        }
    }

	private void ReceiveDamage(float damage) {
		currentLife -= damage;

        SetParentColor(hitColor);
        beingHit = true;
        hitTimer = hitCd;

        if (currentLife <= 0) {
			Death ();
		}
	}

	private void RestoreHealth(int healing) {
		currentLife = (currentLife + healing > maxLife) ? maxLife : currentLife += healing;
	}

	private void Death() {
		destroyedBy = hitBy;
		transform.parent.gameObject.SetActive (false);
	}

    private void SetParentColor(Color color) {
        GetComponentInParent<Renderer>().material.color = color;
    }
}
