using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public int health = 100;
	public float speed = 5;
	public float jumpspeed = 5;
	public float deadZone = -6;

	new Rigidbody2D rigidbody;
	GM _GM;

	void Start ()
	{
		rigidbody = GetComponent<Rigidbody2D> ();
		_GM = FindObjectOfType<_GM> ();
	}
	

	void FixedUpdate ()
	{
		float x = Input.GetAxisRaw ("Horizontal");

		Vector2 v = rigidbody.velocity;
		v.x = x * speed;

		if (Input.GetButtonDown ("Jump")) 
		{
			v.y = jumpspeed; 
		}

		rigidbody.velocity = v;

		if (transform.position.y < deadZone) 
		{
			Debug.Log ("You're Out");
		}

	}

	public void GetOut()
	{
		_GM.SetLives (_GM.lives - 1);
	}
}
