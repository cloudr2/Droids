using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TargetingScript : MonoBehaviour
{
	private GameObject currentTarget;
	private List<GameObject> targetList = new List<GameObject> ();

	public GameObject CurrentTarget { get {return currentTarget;} }

	private void Start() {
		TargetRandomPlayer ();
	}

	private void OnTriggerEnter(Collider col){
		if (col.gameObject.GetComponent<Player> ()) {
			targetList.Add(col.gameObject);
			TargetPlayer (targetList[targetList.Count-1]);
		}
	}

	private void OnTriggerExit(Collider col){
		if (col.gameObject.GetComponent<Player> ()) {
			targetList.Remove(col.gameObject);
			if (targetList.Count == 0) {
				TargetRandomPlayer ();
			} else {
				TargetPlayer (targetList[targetList.Count-1]);
			}
		}
	}

	private void TargetPlayer(GameObject target) {
		currentTarget = target;
	}

	private void TargetRandomPlayer(){
		Player[] players = GameObject.FindObjectsOfType<Player> ();
		currentTarget = players [Random.Range (0,players.Length)].gameObject;
	}
}

