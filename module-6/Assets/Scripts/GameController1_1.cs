using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class GameController1_1 : MonoBehaviour {

	public static GameController1_1 instace;
	public Camera cam;
	public float maxWidth;
	private int i=0,j=0;
	public List<GameObject> Alphabets = new List<GameObject>();
	public List<string> characters = new List<string>();
	public List<string> Show = new List<string>();
	public List<GameObject>clone = new List<GameObject> ();
	public List<Text>text_objects = new List<Text> ();
	public GameObject explosion_obj;
	public GameObject explosion_bal;
	public int Score;
	private bool gameOver=false;
	private bool Restart = false;
	private int count=0;


	
	
	void Start () {
		if (cam == null) {
			cam = Camera.main;
		}
		instace = this;
		//creating list of all objects
		Alphabets.Add (GameObject.FindGameObjectWithTag ("buffalo"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("camel"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("cat"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("cow"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("crane"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("crow"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("dog"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("donkey"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("duck"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("elephant"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("goat"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("hen"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("horse"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("monkey"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("panda"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("parrot"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("penguin"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("rabbit"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("rat"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("sheep"));


		Alphabets.Add (GameObject.FindGameObjectWithTag ("apple"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("banana"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("brinjal"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("carrot"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("coconut"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("grapes"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("guava"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("lemon"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("litchi"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("mango"));
	
		Vector3 upperCorner = new Vector3 (Screen.width, Screen.height, 0.0f);
		Vector3 targetWidth = cam.ScreenToWorldPoint (upperCorner);
		maxWidth = targetWidth.x;
		
		StartCoroutine(Spawn());
	}
	
	void Update()
	{
		if (Input.GetKeyDown ("space")) 
		{
			Application.LoadLevel(Application.loadedLevel);
		}
		if (Input.GetKeyDown (KeyCode.F1)) 
		{
			Application.LoadLevel("level-3");
		}

		GameObject scoreGo = GameObject.FindGameObjectWithTag("Score");
		Text scoreCo = scoreGo.GetComponent<Text>();
		scoreCo.text = "Score: " + Score;
		
	}
	
	IEnumerator Spawn()
	{

		
		yield return new WaitForSeconds (2.0f);
		while (gameOver == false && i<55) {
			

			//get the position and initiate object at the center
			
			Vector3 spawnPosition1 = new Vector3(Random.Range(-1.5f,2.0f),-7.0f,0.0f);
			Quaternion spawnRotation1 = Quaternion.identity;

			Vector3 spawnPosition2 = new Vector3(Random.Range(-1.5f,1.8f),-7.0f,0.0f);
			Quaternion spawnRotation2 = Quaternion.identity;

			Vector3 spawnPosition3 = new Vector3(Random.Range(-1.5f,1.8f),-7.0f,0.0f);
			Quaternion spawnRotation3 = Quaternion.identity;

			clone.Add((GameObject)Instantiate (Alphabets[Random.Range(0,21)], spawnPosition1, spawnRotation1));
			clone.Add((GameObject)Instantiate (Alphabets[Random.Range(21,30)], spawnPosition2, spawnRotation2));
			clone.Add((GameObject)Instantiate (Alphabets[Random.Range(0,21)], spawnPosition3, spawnRotation3));

			GameObject GameoverGo = GameObject.FindGameObjectWithTag("GameOver");
			Text GameoverCo = GameoverGo.GetComponent<Text>();
			if(Score>=10000)
			{
				GameoverCo.text = "Congrats, Level-2 complete";
			}
			if(Score<10000 && i>=52)
			{
				GameoverCo.text = "Game Over, Press restart";
			}
			yield return new WaitForSeconds (1.3f);
			i++;

		}
	}
	public void Spaceclick()
	{
		
		Application.LoadLevel(Application.loadedLevel);
	}
	
	public void f1click()
	{
		Application.LoadLevel("level-3");
	}

	public void backclick()
	{
		Application.LoadLevel("level-1");
	}
}
