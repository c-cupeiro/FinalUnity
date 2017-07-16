using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed = 2f;
	public float maxSpeed = 5f;
	public bool grounded;
	public float jumpingPower = 6.5f;


	private Rigidbody2D rgb2d;
	private Animator anim;
	private SpriteRenderer sprite;
	private bool jump;
	private bool doubleJump;

	// Use this for initialization
	void Start () {
		rgb2d = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		sprite = GetComponent<SpriteRenderer> ();
		jump = false;
	}
	
	// Update is called once per frame
	void Update () {
		anim.SetFloat ("Speed",Mathf.Abs (rgb2d.velocity.x));
		anim.SetBool ("Ground",grounded);
		if (grounded) {
			doubleJump = true;
		}
		if(Input.GetKeyDown (KeyCode.UpArrow)){
			if (grounded) {
				jump = true;
				doubleJump = true;
			} else if (doubleJump) {
				jump = true;
				doubleJump = false;
			}
		}
	}


	//Ya no es necesario multiplicar por el Time.deltaTime
	void FixedUpdate(){

		Vector3 fixedVelocity = rgb2d.velocity;
		fixedVelocity.x *= 0.75f;

		if (grounded) {
			rgb2d.velocity = fixedVelocity;		
		}

		float dir_horizontal = Input.GetAxis ("Horizontal");

		rgb2d.AddForce (Vector2.right * speed * dir_horizontal);

		float limitedSpeed = Mathf.Clamp (rgb2d.velocity.x, -maxSpeed, maxSpeed);
		rgb2d.velocity = new Vector2 (limitedSpeed, rgb2d.velocity.y);

		if (dir_horizontal > 0.1f) {
			//Derecha
			//sprite.flipX = false;
			transform.localScale = new Vector3(1f,1f,1f);
		}
		if (dir_horizontal < -0.1f) {
			//Izquierda
			//sprite.flipX = true;
			transform.localScale = new Vector3(-1f,1f,1f);
		}

		if (jump) {
			rgb2d.velocity = new Vector2 (rgb2d.velocity.x, 0);
			rgb2d.AddForce (Vector2.up * jumpingPower, ForceMode2D.Impulse);
			jump = false;
		}

	}

	//Esto es por si nos caemos mientras probamos pero sirve para quitar vida
	// en un futuro
	void OnBecameInvisible(){
		transform.position = Vector3.zero;
	}
}
