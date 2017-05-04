using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunGrenade : Throwable {

	public int radius = 4;

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
		var animator = e.GetComponent<Animator> ();

		e.enabled = false;
		if (animator != null) 
		{
			animator.enabled = false;
		}
		for (int i = 0; i < 6; i++) 
		{
			SR.color = new Color (1, 1, 1, 1-(i * .1f));
			yield return new WaitForSeconds (.1f);
		}
			
		yield return new WaitForSeconds (3);

		for (int i = 0; i < 11; i++) 
		{
			SR.color = new Color (1, 1, 1,i * .1f);
			yield return new WaitForSeconds (.1f);
		}
		if (animator != null) 
		{
			animator.enabled = true;
		}
		e.enabled = true;
	}
}
