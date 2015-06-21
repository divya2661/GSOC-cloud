using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class main : MonoBehaviour {
	
	public Camera cam;

	void Start () {
		if (cam == null) {
			cam = Camera.main;
		}

	}
	
	void Update()
	{
		if (Input.GetKeyDown ("space")) 
		{
			Application.LoadLevel(Application.loadedLevel);
		}
		if (Input.GetKeyDown (KeyCode.F1)) 
		{
			Application.LoadLevel("level1");
		}
		
	}
	

	
}
