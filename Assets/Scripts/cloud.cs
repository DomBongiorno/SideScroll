using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloud : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D collision)
	{
		var player = collision.gameObject.GetComponent<Player> ();
		if (player != null) 
		{
			player.fly = true;
		}
	}

	void OnTriggerExit2D(Collider2D collision)
	{
		var player = collision.gameObject.GetComponent<Player> ();
		if (player != null) 
		{
			player.fly = false;
		}
	}
	
}
