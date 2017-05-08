using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour 
{
	public int health;

	public void Update()
	{

	}

	public void death()
	{
		health = health - 1;
		if (health == 0) 
		{
			this.gameObject.SetActive (false);
		}
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		if (!enabled) 
		{
			return;
		}

		var player = coll.gameObject.GetComponent<Player> ();
		if (player != null)
			player.GetOut ();
	}
		
}
