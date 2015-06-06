﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class GameController2 : MonoBehaviour {
	
	public Camera cam;
	private float maxWidth;
	private int i=0,j=0;
	public List<GameObject> Alphabets = new List<GameObject>();
	public List<string> characters = new List<string>();
	public List<GameObject>clone = new List<GameObject> ();
	public List<GameObject>balloons = new List<GameObject> ();
	public List<string>Show = new List<string> ();
	public GameObject explosion_obj;
	public GameObject explosion_bal;
	public GUIText ScoreText;
	public int Score=0;
	public int health=5;
	private bool gameOver=false;
	private bool Restart = false;
	private int count=0;
	
	
	void Start () {
		if (cam == null) {
			cam = Camera.main;
		}
		
		Alphabets.Add (GameObject.FindGameObjectWithTag ("n"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("c"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("g"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("d"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("e"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("a"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("o"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("f"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("h"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("j"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("b"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("l"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("i"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("q"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("m"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("t"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("r"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("x"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("u"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("v"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("k"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("p"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("w"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("s"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("z"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("y"));
		
		characters.Add ("nest");
		characters.Add ("cat");
		characters.Add ("gun");
		characters.Add ("dog");
		characters.Add ("elephant");
		characters.Add ("apple");
		characters.Add ("orange");
		characters.Add ("fish");
		characters.Add ("hen");
		characters.Add ("jug");
		characters.Add ("ball");
		characters.Add ("lion");
		characters.Add ("inkpot");
		characters.Add ("queen");
		characters.Add ("monkey");
		characters.Add ("tree");
		characters.Add ("rat");
		characters.Add ("xray");
		characters.Add ("umbrella");
		characters.Add ("van");
		characters.Add ("kite");
		characters.Add ("peacock");
		characters.Add ("watch");
		characters.Add ("ship");
		characters.Add ("zebra");
		characters.Add ("yak");

		Show.Add("n");
		Show.Add("c");
		Show.Add("g");
		Show.Add("d");
		Show.Add("e");
		Show.Add("a");
		Show.Add("o");
		Show.Add("f");
		Show.Add("h");
		Show.Add("j");
		Show.Add("b");
		Show.Add("l");
		Show.Add("i");
		Show.Add("q");
		Show.Add("m");
		Show.Add("t");
		Show.Add("r");
		Show.Add("x");
		Show.Add("u");
		Show.Add("v");
		Show.Add("k");
		Show.Add("p");
		Show.Add("w");
		Show.Add("s");
		Show.Add("z");
		Show.Add("y");
		balloons.Add(GameObject.FindGameObjectWithTag("blue"));
		balloons.Add(GameObject.FindGameObjectWithTag("red"));
		balloons.Add (GameObject.FindGameObjectWithTag ("sky"));
		balloons.Add(GameObject.FindGameObjectWithTag("yellow"));
		balloons.Add(GameObject.FindGameObjectWithTag("green"));
		

		Vector3 upperCorner = new Vector3 (Screen.width, Screen.height, 0.0f);
		Vector3 targetWidth = cam.ScreenToWorldPoint (upperCorner);
		maxWidth = targetWidth.x;
		StartCoroutine (Spawn ());
	}
	
	void Update()
	{
		if (Input.GetKeyDown ("space")) 
		{
			Application.LoadLevel(Application.loadedLevel);
		}

		if (Input.GetKey (KeyCode.F1)) 
		{	
			
			Application.LoadLevel("end");
		}
		
	}
	
	IEnumerator Spawn()
	{
		
		yield return new WaitForSeconds (1.0f);
		while (gameOver == false && i<26) 
		{

			GameObject show = GameObject.FindGameObjectWithTag("Show");
			Text showco = show.GetComponent<Text>();

			Vector3 spawnPosition = new Vector3 (Random.Range (-maxWidth, maxWidth), 5.0f, 0.0f);
			Quaternion spawnRotation = Quaternion.identity;
			yield return new WaitForSeconds (2.0f);
			clone.Add((GameObject)Instantiate (Alphabets[i], spawnPosition, spawnRotation));
			showco.text = Show[i];
			yield return new WaitForSeconds (3.5f);

			GameObject scoretext = GameObject.FindGameObjectWithTag("Score");
			Text scoretextco = scoretext.GetComponent<Text>();


			
			GameObject inputFieldGo = GameObject.FindGameObjectWithTag("UserField");
			InputField inputFieldCo = inputFieldGo.GetComponent<InputField>();



				
			GameObject Gameover = GameObject.FindGameObjectWithTag("GameOver");
			Text Gameoverco = Gameover.GetComponent<Text>();
			Gameoverco.text = "";
			
			GameObject restartText = GameObject.FindGameObjectWithTag("Restart");
			Text restartTextco = restartText.GetComponent<Text>();
			restartTextco.text = "";
			Debug.Log(inputFieldCo.text+ " == " + characters[i]);

			if (inputFieldCo.text == characters[i]&& count!=26) 
			{
				Debug.Log("if dkjnfsfjk");
				Vector3 pos = clone[i].transform.position;
				Instantiate(explosion_obj , pos ,transform.rotation);
				Destroy(clone[i].gameObject);
				Score = Score+100;
				scoretextco.text = "Score: " + Score; 
				inputFieldCo.text = "";
				
				
			}
			
			else
			{
				Vector3 bal_pos = balloons[j].transform.position;
				Instantiate(explosion_bal,bal_pos,transform.rotation);
				Destroy(balloons[j]);
				Destroy(clone[i].gameObject);
				health--;
				j++;
			if(health==0)
			{
					gameOver = true;
					Gameoverco.text = "Game Over";
					restartTextco.text = "Press 'Space' To Restart";

			}
				inputFieldCo.text = "";
			}
			i++;
			count++;
			Debug.Log (i);
			if(i==26)
			{
				Gameoverco.text = "Congrats! Level-2 Done :)";
				restartTextco.text = "Press 'F1' for next level";
			}
		}
	}
}