using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour {

	Player player; 
	public int value;

	void OnTriggerEnter2D(Collider2D collision)
	{
		player = collision.gameObject.GetComponent<Player> ();
		if (player != null) 
		{
			gameObject.SetActive(false);
			FindObjectOfType<GM> ().SetPoints (FindObjectOfType<GM> ().GetPoints () + value);
		}
	}
}
