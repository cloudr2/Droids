using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour {
    private Slider bar;
    private int maxLife, currentLife;
	void Awake () {
        bar = GetComponent<Slider>();
	}
	
    public void SetMaxLife(int value)
    {
        maxLife = value;
        bar.maxValue = value;
    }

    public void SetLife(int value)
    {
        currentLife = value;
        bar.value = value;
    }
}
