﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skewers : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Player") {
			col.SendMessage ("EnemyHitDead");
		}
	}
}
