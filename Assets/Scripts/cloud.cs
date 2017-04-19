using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloud : MonoBehaviour {

	Player player; 

	void OnTriggerEnter2D(Collider2D collision)
	{
		player = collision.gameObject.GetComponent<Player> ();
		if (player != null) 
		{
			player.fly = true;
		}
	}

	void OnTriggerExit2D(Collider2D collision)
	{
		
		if (player != null) 
		{
			player.fly = false;
		}
	}
	
}
