using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour {
	Player player;
	GM gm;

	void OnCollisionEnter2D (Collision2D coll)
	{
		var player = coll.gameObject.GetComponent<Player>();
		var gm = FindObjectOfType<GM> ();
		if (player != null) 
		{
			gm.Win ();
		}
	}
}
