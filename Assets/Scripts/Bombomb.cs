using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bombomb : MonoBehaviour 
{

	public int radius = 10;
	public bool isActive = false;

	private new Rigidbody2D rigidBody2D;
	private new Collider2D collider2D;


	void Start()
	{
		rigidBody2D = GetComponent<Rigidbody2D> ();
		collider2D = GetComponent<Collider2D> ();
	}

	void Update()
	{
		if (Input.GetButtonDown ("Fire1")&& isActive) 
		{
			Throw ();
		}
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		var player = coll.gameObject.GetComponent<Player>();

		if (player != null && !isActive) 
		{
			PickUp (player);
		}

		if (player == null && isActive) 
		{
			explode ();
		}
	}

	public void PickUp (Player player)
	{
		isActive = true;
		transform.parent = player.transform;

		transform.localPosition = new Vector3 (0.35f, 0.2f);

		rigidBody2D.velocity = new Vector2 ();
		rigidBody2D.isKinematic = true;
		collider2D.enabled = false;
			
	}

	public void Throw()
	{
		transform.parent = null;

		rigidBody2D.velocity = new Vector2 (5,0);
		rigidBody2D.isKinematic = false;
		collider2D.enabled = true;	
	}

	public void explode()
	{
		var enemies = FindObjectsOfType<Enemy> ();
		gameObject.SetActive (false);

		foreach (var e in enemies) 
		{
			if (Vector3.Distance (this.transform.position, e.transform.position) < radius) 
			{
				e.gameObject.SetActive (false);
			}
		}

	}
	
}
