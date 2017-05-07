using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public new Camera camera;

	Vector3 offset; 

	void Start () 
	{
		if (camera == null) 
		{
			camera = FindObjectOfType<Camera> ();
		}

		offset = camera.transform.position - this.transform.position;

	}

	void Update () 
	{
		camera.transform.position = Vector3.Lerp(camera.transform.position, this.transform.position + offset, Time.deltaTime*5);
	}
}
