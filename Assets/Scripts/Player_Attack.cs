using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Attack : MonoBehaviour {

	private bool attacking = false;
	private float attackTimer = 0;
	private float attackCd = 0.4f;

	public Collider2D attackTrigger;

	private Animator anim;
	void Awake(){
		anim = gameObject.GetComponent<Animator> ();
		attackTrigger.enabled = false;
	}

	void Update(){
		if ((Input.GetKeyDown (KeyCode.Z) || Input.GetKeyDown (KeyCode.X))&& !attacking) {
			attacking = true;
			attackTimer = attackCd;
			attackTrigger.enabled = true;
			if(Input.GetKeyDown (KeyCode.Z)){
				//Attack_1
				anim.SetBool ("Attack_1",true);
			}else{
				//Attack_2
				anim.SetBool ("Attack_2",true);
			}
		}
		if (attacking) {
			if (attackTimer > 0) {
				attackTimer -= Time.deltaTime;
			} else {
				attacking = false;
				attackTrigger.enabled = false;
				anim.SetBool ("Attack_1",false);
				anim.SetBool ("Attack_2",false);
			}
		}

	}

}
