using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class GameController0 : MonoBehaviour {
	
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
		if (Input.GetKey(KeyCode.F1))
		{
			
			Application.LoadLevel("main1");
		}
	}

}
