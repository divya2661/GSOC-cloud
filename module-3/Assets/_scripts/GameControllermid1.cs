using UnityEngine;
using System.Collections;

public class GameControllermid1 : MonoBehaviour {

	public Camera cam;
	public GameObject Cons;
	public GameObject vow;
	// Use this for initialization
	void Start () {
		if (cam == null) {
			cam = Camera.main;
		}
	}

	void Update () {
		if (Input.GetKey (KeyCode.Space)) 
		{
			Application.LoadLevel(Application.loadedLevel);
		}
		if (Input.GetKey (KeyCode.F1)) 
		{
			Application.LoadLevel("main2");
			
		}
	}
}
