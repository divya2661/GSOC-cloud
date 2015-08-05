using UnityEngine;
using System.Collections;

public class GameControllerMain : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("space")) 
		{
			Application.LoadLevel(Application.loadedLevel);
		}
		if (Input.GetKeyDown (KeyCode.F1)) 
		{
			Application.LoadLevel("level-1");
		}
	}

	public void Spaceclick()
	{
		
		Application.LoadLevel(Application.loadedLevel);
	}
	
	public void f1click()
	{
		Application.LoadLevel("level-1");
	}


}
