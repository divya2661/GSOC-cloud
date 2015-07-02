using UnityEngine;
using System.Collections;

public class GameControllermain : MonoBehaviour {


	public Camera cam;
	// Use this for initialization
	void Start () {
		if (cam == null) {
			cam = Camera.main;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.F1)) 
		{
			Application.LoadLevel("level1");
		}
	}
}
