﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	Enemy enemy;

	void OnTriggerEnter2D(Collider2D coll)
	{
		
		enemy = coll.gameObject.GetComponent<Enemy> ();
		if (enemy != null) 
		{
			FindObjectOfType<Enemy> ().death ();
		}
		if (this == null) 
		{
			Destroy (gameObject);
		}
	}
}
