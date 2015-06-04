using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public Camera cam;

	// Use this for initialization
	void Start(){
		if (cam == null) {
			cam = Camera.main;
		}
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey (KeyCode.F1)) 
		{	
			
			Application.LoadLevel("level-3");
		}

	}
}
