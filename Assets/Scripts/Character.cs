using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : Entity {
    protected Animator ani;
    //private LifeScript lifeScript;
    
	protected override void Awake () {
        base.Awake();
        if (GetComponent<Animator>() != false)
            ani = GetComponent<Animator>();
	}
}
