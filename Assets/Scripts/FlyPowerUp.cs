using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyPowerUp : MonoBehaviour {

	private float timeStarted = 0;
	Player player;

	public float poweruptime = 3;


	void OnTriggerEnter2D(Collider2D collision)
	{
		player = collision.gameObject.GetComponent<Player> ();
		if (player != null) 
		{
			player.fly = true;
			gameObject.GetComponent<Collider2D> ().enabled = false;
			gameObject.GetComponent<SpriteRenderer> ().enabled = false;

			timeStarted = Time.time;

			player.PowerUp ();
		}
	}

	void Update()
	{
		if (timeStarted != 0 && timeStarted + poweruptime < Time.time) 
		{
			timeStarted = 0;
			player.fly = false;
		}
	}
}
