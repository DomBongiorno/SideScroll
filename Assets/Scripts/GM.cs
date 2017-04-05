using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour 
{

	public int lives;
	public int points;
	public GameObject Gameover;

	public void SetLives(int newValue)
	{
		lives = newValue;
		if (lives == 0) 
		{
			GameOver ();
		}
		Debug.Log ("Lives:" + lives);
	}

	void GameOver()
	{
		Gameover.SetActive (true);
	}

}
