using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	Enemy enemy;

	void OnTriggerEnter2D(Collider2D coll)
	{
		
		var enemy = coll.gameObject.GetComponent<Enemy> ();


		if (enemy != null) 
		{
			Destroy (gameObject);
			enemy.death ();
		}

	}
}
