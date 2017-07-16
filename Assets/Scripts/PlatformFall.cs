using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformFall : MonoBehaviour
{

	public float fallDelay = 1f;
	public float respawnDelay = 5f;

	private Rigidbody2D rgb2d;
	private PolygonCollider2D pc2d;
	private Vector3 start;

	// Use this for initialization
	void Start ()
	{
		start = transform.position;
		rgb2d = GetComponent<Rigidbody2D> ();
		pc2d = GetComponent<PolygonCollider2D> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	void OnCollisionEnter2D (Collision2D col)
	{
		if (col.gameObject.CompareTag ("Player")) {
			Invoke ("Fall", fallDelay);
			Invoke ("Respawn", fallDelay + respawnDelay);
		}
	}

	void Fall ()
	{
		rgb2d.isKinematic = false;
		pc2d.isTrigger = true;
	}

	void Respawn ()
	{
		transform.position = start;
		rgb2d.isKinematic = true;
		rgb2d.velocity = Vector3.zero;
		pc2d.isTrigger = false;
	}

}
