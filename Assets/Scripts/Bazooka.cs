using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bazooka : Weapon {

	public GameObject rocketPrefab;
	public GameObject firepoint;

	public override void PickUp (Player player)
	{
		transform.parent = player.transform;

		transform.localPosition = new Vector3 (0.0f, 0.15f);

		rigidBody2D.velocity = new Vector2 ();
		rigidBody2D.isKinematic = true;
		collider2D.enabled = false;

	}

	public override void Attack ()
	{
		var rocket = Instantiate (rocketPrefab);
		rocket.transform.position = firepoint.transform.position;
		rocket.GetComponent<Rigidbody2D> ().velocity = new Vector2 (10, 0);

		base.Attack ();
	}
}
