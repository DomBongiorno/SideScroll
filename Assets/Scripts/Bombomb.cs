using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bombomb : Throwable 
{

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
