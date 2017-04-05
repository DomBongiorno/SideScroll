using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GM : MonoBehaviour 
{

	public int lives;
	public int points;
	public GameObject Gameover;
	public Text LivesValue;
	public Text ScoreValue;  

	public void SetLives(int newValue)
	{
		lives = newValue;
		if (lives == 0) {
			GameOver ();
		}
		Debug.Log ("Lives:" + lives);
		LivesValue.text = lives.ToString ();
	}

	void GameOver()
	{
		Gameover.SetActive (true);
	}

}
