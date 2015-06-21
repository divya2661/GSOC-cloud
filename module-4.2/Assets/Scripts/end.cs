using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class end : MonoBehaviour {
	
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
		
	}
	

	
}
