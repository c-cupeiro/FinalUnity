using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

	public float speed = 1f;
	public float maxSpeed = 1f;

	private Rigidbody2D rgb2d;
	private Animator anim;

	// Use this for initialization
	void Start ()
	{
		rgb2d = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		rgb2d.AddForce (Vector2.right * speed);
		float limitedSpeed = Mathf.Clamp (rgb2d.velocity.x, -maxSpeed, maxSpeed);
		rgb2d.velocity = new Vector2 (limitedSpeed, rgb2d.velocity.y);


		if (rgb2d.velocity.x == 0f) {
			speed = -speed;
			rgb2d.velocity = new Vector2 (speed, rgb2d.velocity.y);
		}

	}
}
