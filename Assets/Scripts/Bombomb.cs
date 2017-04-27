using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bombomb : Weapon 
{

	public int radius = 10;
	public bool isActive = false;


	void Update()
	{

	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		var player = coll.gameObject.GetComponent<Player>();

		if (player == null && isActive) 
		{
			explode ();
		}
	}

	public override void PickUp (Player player)
	{
		if (isActive) 
		{
			return;
		}
		isActive = true;
		base.PickUp (player);
	}

	public override void Attack()
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
