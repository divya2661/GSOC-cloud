using UnityEngine;
using System.Collections;

public class GameControllermain : MonoBehaviour {
	
	public void restartclick()
	{
		
		Application.LoadLevel(Application.loadedLevel);
	}
	public void nextclick()
	{
		Application.LoadLevel("level-1");
	}
}
