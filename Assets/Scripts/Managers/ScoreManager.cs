using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
	public static ScoreManager instance = null;

	private void Awake(){
		if (instance == null) {
			instance = this;
		} else {
			Destroy (this.gameObject);
		}
	}
}

