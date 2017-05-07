using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public int health = 100;
	public float speed = 5;
	public float jumpspeed = 6;
	public float deadZone = -6;
	public bool fly = false;

	public Weapon currentweapon;

	private Vector3 startingposition;

	new Rigidbody2D rigidbody;
	GM _GM;

	private Animator anim;
	private bool air;
	private SpriteRenderer sr;

	void Start ()
	{
		rigidbody = GetComponent<Rigidbody2D> ();
		_GM = FindObjectOfType<GM> ();
		startingposition = transform.position;
		sr = GetComponent<SpriteRenderer>();

		anim = GetComponent<Animator> ();
		air = false;

	}
	

	void FixedUpdate ()
	{
		float x = Input.GetAxisRaw ("Horizontal");

		Vector2 v = rigidbody.velocity;
		v.x = x * speed;


		if (v.x != 0) 
		anim.SetBool ("Running", true);
		else 
		anim.SetBool ("Running", false);


		if (v.x > 0) 
		{
			sr.flipX = false;
		} 
		else if (v.x<0)
		{
			sr.flipX = true;
		}

		if (v.y != 0) 
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

		if (Input.GetButtonDown ("Fire1")&& currentweapon != null) 
		{
			currentweapon.Attack ();
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

	void OnTriggerEnter2D(Collider2D coll)
	{
		var weapon = coll.gameObject.GetComponent<Weapon> ();
		if (weapon != null && transform.childCount == 0) 
		{
			currentweapon = weapon;
			weapon.PickUp (this);
		}
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		air = false;


	}

	void OnCollisionExit2D(Collision2D col)
	{
		air = true;
	}

	public void PowerUp()
	{
		anim.SetTrigger ("PowerUP");
	}


}
