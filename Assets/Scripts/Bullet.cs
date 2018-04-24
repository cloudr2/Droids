using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour {
    private Rigidbody rb;
    private MeshRenderer mr;

	private float bulletDamage;
    private float bulletSpeed;
    private Vector3 bulletDirection;
	private GameObject bulletSource;

    private float bulletLife;
    private float bulletKnockback;

	public float BulletDamage { get { return bulletDamage; } }
	public float BulletKnockback { get { return bulletLife; } }
	public GameObject BulletSource { get { return bulletSource; } }

	public LayerMask collideWith;

    protected virtual void Awake()
    {
        mr = GetComponent<MeshRenderer>();
        rb = GetComponent<Rigidbody>();
    }

	public virtual void Initialize(GameObject source, float damage, float lifeTime, Vector3 position, Vector3 direction, float speed)
    {
		bulletSource = source;
		bulletDamage = damage;
		bulletSpeed = speed;
        bulletDirection = direction;
        bulletLife = lifeTime;
        bulletKnockback = 0;
        transform.position = position;
        transform.forward = bulletDirection;
        rb.velocity = bulletDirection * bulletSpeed;
        Destroy(this.gameObject, bulletLife);
    }

    public virtual void Initialize(GameObject source, float damage, float lifeTime, Vector3 position, Vector3 direction, float speed, float knockback)
    {
		bulletSource = source;
		bulletDamage = damage;
        bulletSpeed = speed;
        bulletDirection = direction;
        bulletLife = lifeTime;
        bulletKnockback = knockback;
        transform.position = position;
        transform.forward = bulletDirection;
        rb.velocity = bulletDirection * bulletSpeed;
        Destroy(this.gameObject, bulletLife);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (((1 << other.gameObject.layer) & collideWith) != 0)
        {
            Destroy(this.gameObject, 0.05f);
            rb.velocity *= 0;
            mr.enabled = false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.forward * 2);
    }

    public Vector3 GetDirection()
    {
        return bulletDirection;
    }
}
