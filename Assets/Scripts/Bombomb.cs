using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bombomb : MonoBehaviour 
{

	public int radius = 10;

	void OnCollisionEnter2D(Collision2D coll)
	{
		var player = coll.gameObject.GetComponent<Player>();
		gameObject.SetActive (false);
		if (player != null) 
		{
			var enemies = FindObjectsOfType<Enemy> ();
			foreach (var e in enemies) 
			{
				if (Vector3.Distance (this.transform.position, e.transform.position) < radius) 
				{
					e.gameObject.SetActive (false);
				}
			}
		}
	}
	
}
