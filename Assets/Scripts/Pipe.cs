using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour {
	
	Player player;

	private Animator anim;



	void Update()
	{
		player = FindObjectOfType<Player> ();

		if (player != null && Input.GetKeyDown("down"))
		{
			Debug.Log ("went down pipe");
			StartCoroutine(downpipe ());
		}
	}

	IEnumerator downpipe()
	{
		this.GetComponent<Collider2D> ().enabled = false;
		player.enabled = false;

		yield return new WaitForSeconds (.8f);

		player.transform.position = new Vector3 (7.35f, -1.46f);
		player.enabled = true;
	}

}
