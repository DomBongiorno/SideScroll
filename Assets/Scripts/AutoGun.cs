﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoGun : Weapon 
{
	private float timeStarted = 0;

	public Rigidbody2D bullet;
	public float speed = 10f;

	public GameObject firepoint;
	Player player;

	public int ammo = 5;
	 
	public override void PickUp (Player player)
	{
		transform.parent = player.transform;

		transform.localPosition = new Vector3 (0.15f, -0.1f);

		rigidBody2D.velocity = new Vector2 ();
		rigidBody2D.isKinematic = true;
		collider2D.enabled = false;
	}
		
	void Fire() 
	{
		Rigidbody2D bulletClone = (Rigidbody2D) Instantiate(bullet, firepoint.transform.position, firepoint.transform.rotation);
		bulletClone.velocity = transform.right * speed;

	}

	// Calls the fire method when holding down ctrl or mouse
	public override void Attack () {
		if (ammo > 0) {
			Fire();
			ammo = ammo - 1;
		}
		if (ammo == 0) 
		{
			this.gameObject.SetActive (false);
			transform.parent = null;
		}
	}



}
