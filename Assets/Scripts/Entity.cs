using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (Rigidbody))]

public class Entity : MonoBehaviour {
    protected Rigidbody rb;
    protected MeshRenderer mr;

    public float floorDrag, airDrag;

    protected bool isOnFloor;

	protected virtual void Awake () {
        rb = GetComponent<Rigidbody>();
		//TODO: por que una ref al meshrenderer?
		mr = GetComponent<MeshRenderer>(); 
	}
	
    protected virtual void Update()
    {
        CheckFloorCollision();
        Drag();
    }

    protected void CheckFloorCollision()
    {
        isOnFloor = rb.velocity.y == 0 ? true : false;
    }

    protected void Drag()
    {
        if(isOnFloor)
            rb.velocity = new Vector3(rb.velocity.x * (1 - floorDrag), rb.velocity.y, rb.velocity.z * (1 - floorDrag));
        else
            rb.velocity = new Vector3(rb.velocity.x * (1 - airDrag), rb.velocity.y, rb.velocity.z * (1 - airDrag));
    }
}
