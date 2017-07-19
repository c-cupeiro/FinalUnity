using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_1_Trigger : MonoBehaviour {
	private GameObject parent;

	void Start(){
		parent = transform.parent.gameObject;
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Player") {
			//Debug.Log ("Player");
			float offset = 0.3f;
			//Debug.Log ("Enemy.y --> " + (parent.transform.position.y + offset));
			//Debug.Log ("Player.y --> " + col.transform.position.y);
			if ((parent.transform.position.y + offset) < col.transform.position.y) {
				col.SendMessage ("EnemyJump");
				parent.SendMessage ("StartSmoke");
				Destroy (parent);
			} else {
				col.SendMessage ("EnemyHitDead");
			}

		}
	}
}
