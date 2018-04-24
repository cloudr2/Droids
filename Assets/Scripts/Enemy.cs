using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character {

	//REFS
	public Transform shootingPoint;
	public GameObject bulletPrefab;

	//MOVEMENT
	[Header ("Movement")]
	public float accel;
	public float maxSpeed;

	public int score;

	private TargetingScript targetSystem;

	private List<Player> targetList = new List<Player>();

	protected override void Awake(){
        base.Awake();
		targetSystem = GetComponentInChildren<TargetingScript> ();
	}

	void Update () {
		LookAtTarget ();
		MoveTowardsTarget ();
	}

	public void LookAtTarget() {
		if (targetSystem.CurrentTarget != null) {
			Vector3 direction = targetSystem.CurrentTarget.transform.position - this.transform.position;
			this.transform.forward = direction.normalized;
		}
	}

	public void MoveTowardsTarget(){
		if (targetSystem.CurrentTarget != null) {
			if(rb.velocity.magnitude <= maxSpeed)
				rb.velocity = transform.forward * accel;
		}
	}
}
