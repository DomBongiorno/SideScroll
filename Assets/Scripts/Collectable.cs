using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour 
{

	public int value;

	void OnCollisionEnter2D(Collision2D coll)
	{
		var player = coll.gameObject.GetComponent<Player> ();
		if (player != null) 
		{
			gameObject.SetActive(false);
			FindObjectOfType<GM> ().SetPoints (FindObjectOfType<GM> ().GetPoints () + value);
		}
	}
}
