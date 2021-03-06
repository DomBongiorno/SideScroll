﻿using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour
{

	protected Rigidbody2D rigidBody2D;
	protected new Collider2D collider2D;


	void Start()
	{
		rigidBody2D = GetComponent<Rigidbody2D> ();
		collider2D = GetComponent<Collider2D> ();
	}

	
	public virtual void Attack ()
	{
		
	}

	public virtual void PickUp(Player player)
	{
		
		transform.parent = player.transform;

		transform.localPosition = new Vector3 (0.35f, 0.2f);

		rigidBody2D.velocity = new Vector2 ();
		rigidBody2D.isKinematic = true;
		collider2D.enabled = false;
	}
}

