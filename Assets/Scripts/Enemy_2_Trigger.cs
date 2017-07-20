using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_2_Trigger : MonoBehaviour {

	private GameObject parent;

	void Start(){
		parent = transform.parent.gameObject;
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Hit") {
			//Debug.Log ("Player");
			float offset = 0.4f;
			//Debug.Log ("Enemy.y --> " + (parent.transform.position.y + offset));
			//Debug.Log ("Player.y --> " + col.transform.position.y);
			if (!((parent.transform.position.y + offset) < col.transform.position.y)) {
				Destroy (parent);
				parent.SendMessage ("StartSmoke");
			} else {
				col.transform.parent.SendMessage ("EnemyHitDead");
			}

		} else if (col.gameObject.tag == "Player") {
			col.SendMessage ("EnemyHitDead");
		}
	}
}