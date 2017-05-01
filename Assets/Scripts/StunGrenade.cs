using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunGrenade : Throwable {

	public int radius = 10;

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

	public void explode()
	{
		var enemies = FindObjectsOfType<Enemy> ();
		collider2D.enabled = false;
		GetComponent<SpriteRenderer> ().enabled = false;

		foreach (var e in enemies) 
		{
			if (Vector3.Distance (this.transform.position, e.transform.position) < radius) 
			{
				StartCoroutine( stun (e));
			}
		}

	}

	IEnumerator stun(Enemy e)
	{
		var SR = e.GetComponent<SpriteRenderer> ();
		SR.color = new Color (1, 1, 1, .5f);
		e.enabled = false;
		yield return new WaitForSeconds (3);

		e.enabled = true;
		SR.color = new Color (1, 1, 1, 1);
	}
}
