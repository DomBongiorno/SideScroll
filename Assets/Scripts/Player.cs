using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public int health = 100;
	public float speed = 5;
	public float jumpspeed = 6;
	public float deadZone = -6;
	public bool fly = false;

	private Vector3 startingposition;

	new Rigidbody2D rigidbody;
	GM _GM;

	private Animator anim;
	private bool air;

	void Start ()
	{
		rigidbody = GetComponent<Rigidbody2D> ();
		_GM = FindObjectOfType<GM> ();
		startingposition = transform.position;

		anim = GetComponent<Animator> ();
		air = false;
	}
	

	void FixedUpdate ()
	{
		float x = Input.GetAxisRaw ("Horizontal");

		Vector2 v = rigidbody.velocity;
		v.x = x * speed;

		if (v.x != 0) 
		{
			anim.SetBool ("Running", true);
		} 
		else 
		{
			anim.SetBool ("Running", false);
		}



		if (air) 
		{
			anim.SetBool ("Air", true);
		}
		else 
		{
			anim.SetBool ("Air", false);
		}

		if (Input.GetButtonDown ("Jump") && (v.y == 0 || fly)) 
		{
			v.y = jumpspeed; 
		}

		rigidbody.velocity = v;

		if (transform.position.y < deadZone) 
		{
			Debug.Log ("You're Out");

			GetOut ();
		}

	}

	public void GetOut()
	{
		_GM.SetLives (_GM.lives - 1);
		transform.position = startingposition;
		fly = false;
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		air = false;

	}

	void OnCollisionExit2D(Collision2D col)
	{
		air = true;
	}
}
