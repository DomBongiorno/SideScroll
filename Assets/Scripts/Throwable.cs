using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throwable : Weapon {

	Player player;
	public bool isActive = false;

	public override void Attack()
	{
		transform.parent = null;

		rigidBody2D.velocity = new Vector2 (5,0);
		rigidBody2D.isKinematic = false;
		collider2D.enabled = true;

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

}
