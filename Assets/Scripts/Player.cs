using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character {

    //REFS
    public Transform shootingPoint;
    public GameObject bulletPrefab;
    //private LifeScript lifeScript;

    //PLAYER
    public int playerNumber;
	public int score;

    //MOVEMENT
    [Header ("Movement")]
    public float accel;
    public float maxSpeed;

    //COMBAT
    [Header("Combat")]
	public int bulletDamage;
    public float shootFireRate; //bullets per second
    public float bulletSpeed, bulletLife, bulletKnockback;

    //TIMERS
    private float shootTimer;

    //INPUTS
    private float horAxis, vertAxis;
    private bool shootButton, shootPressed;

    protected override void Awake()
    {
        base.Awake();
    }

	protected void Start () {
		score = 0;
	}
	
	protected override void Update () {
        base.Update();
        CheckInputs();
        CheckTimers();
        if (horAxis != 0 || vertAxis != 0)
            Move();

        if(shootButton && shootTimer <= 0)
            Shoot();
	}

    void Move()
    {
        //facing
        Vector3 newForward = new Vector3(horAxis, 0, vertAxis).normalized;
        transform.forward = newForward;


        if(rb.velocity.magnitude <= maxSpeed)
            rb.velocity += transform.forward * accel;
    }

    void Shoot()
    {
        GameObject newBullet = Instantiate(bulletPrefab, transform.root);
        newBullet.GetComponent<Bullet>().Initialize(this.gameObject, bulletDamage, bulletLife, shootingPoint.position, transform.forward, bulletSpeed, bulletKnockback);
        shootTimer = 1f / shootFireRate;
    }

    void CheckTimers()
    {
        if (shootTimer > 0)
            shootTimer -= Time.deltaTime;
    }

    void CheckInputs()
    {
        horAxis = Input.GetAxisRaw("Horizontal_" + playerNumber);
        vertAxis = Input.GetAxisRaw("Vertical_" + playerNumber);

        shootButton = Input.GetButton("Shoot_" + playerNumber);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, transform.forward * 2);
    }

	public void AddScore(int points)
	{
		score += points;
	}


}
