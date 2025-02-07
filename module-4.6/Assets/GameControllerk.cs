﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class GameControllerk : MonoBehaviour {
	
	public Camera cam;
	private float maxWidth;
	private int i=0,j=0;
	public List<GameObject>objs = new List<GameObject>();
	public List<string> characters = new List<string>();
	public List<GameObject>clone = new List<GameObject> ();
	public List<Text>text_objects = new List<Text> ();
	public GameObject explosion_obj;
	public GameObject explosion_bal;
	public GUIText ScoreText;
	public int Score=0;
	public int button_no;
	public Text ans_button;
	public int rand1,ans,user_input;
	public char swap1,swap2;
	public string str;
	public int string_len;
	public int health=5;
	private bool gameOver=false;
	private bool Restart = false;
	private int count=0;
	public string vo;
	
	
	void Start () {
		if (cam == null) {
			cam = Camera.main;
		}
		
		//creating list of all objects
		objs.Add (GameObject.FindGameObjectWithTag ("red"));
		objs.Add (GameObject.FindGameObjectWithTag ("blue"));
		objs.Add (GameObject.FindGameObjectWithTag ("green"));
		objs.Add (GameObject.FindGameObjectWithTag ("yellow"));
		objs.Add (GameObject.FindGameObjectWithTag ("orange"));
		objs.Add (GameObject.FindGameObjectWithTag ("black"));
		objs.Add (GameObject.FindGameObjectWithTag ("white"));
		objs.Add (GameObject.FindGameObjectWithTag ("silver"));
		objs.Add (GameObject.FindGameObjectWithTag ("golden"));
		objs.Add (GameObject.FindGameObjectWithTag ("pink"));
		objs.Add (GameObject.FindGameObjectWithTag ("brown"));
		objs.Add (GameObject.FindGameObjectWithTag ("pink"));
		objs.Add (GameObject.FindGameObjectWithTag ("purple")); 
		objs.Add (GameObject.FindGameObjectWithTag ("white"));
		objs.Add (GameObject.FindGameObjectWithTag ("red"));
		objs.Add (GameObject.FindGameObjectWithTag ("blue"));
		objs.Add (GameObject.FindGameObjectWithTag ("green"));
		objs.Add (GameObject.FindGameObjectWithTag ("yellow"));
		objs.Add (GameObject.FindGameObjectWithTag ("orange"));
		objs.Add (GameObject.FindGameObjectWithTag ("black"));
		objs.Add (GameObject.FindGameObjectWithTag ("white"));
		objs.Add (GameObject.FindGameObjectWithTag ("silver"));
		objs.Add (GameObject.FindGameObjectWithTag ("golden"));
		objs.Add (GameObject.FindGameObjectWithTag ("brown"));
		objs.Add (GameObject.FindGameObjectWithTag ("pink"));
		objs.Add (GameObject.FindGameObjectWithTag ("purple")); 
		objs.Add (GameObject.FindGameObjectWithTag ("white"));
		objs.Add (GameObject.FindGameObjectWithTag ("pink"));
		
		//creating list of correct answee to corresponding alphabet list
		characters.Add("red");
		characters.Add("blue");
		characters.Add("green");
		characters.Add("yellow");
		characters.Add("orange");
		characters.Add("black");
		characters.Add("white");
		characters.Add("silver");
		characters.Add("golden");
		characters.Add("pink");
		characters.Add("brown");
		characters.Add("pink");
		characters.Add("purple");
		characters.Add("white");
		characters.Add("red");
		characters.Add("blue");
		characters.Add("green");
		characters.Add("yellow");
		characters.Add("orange");
		characters.Add("black");
		characters.Add("white");
		characters.Add("silver");
		characters.Add("golden");
		characters.Add("brown");
		characters.Add("pink");
		characters.Add("purple");
		characters.Add("white");
		characters.Add("pink");

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
		if (Input.GetKeyDown (KeyCode.F1)) 
		{
			Application.LoadLevel("level3");
		}
		if (Input.GetKey (KeyCode.RightArrow)) 
		{
			user_input = 1;
		}
		if (Input.GetKey (KeyCode.LeftArrow)) 
		{
			user_input = 0;
		}
		
	}
	
	IEnumerator Spawn()
	{
		yield return new WaitForSeconds (1.0f);

		while (gameOver == false && i<22) {
			Debug.Log(i);
			user_input = 2;
			Vector3 spawnPosition1 = new Vector3 (-3.81f,.16f,0.0f);
			Vector3 spawnPosition2 = new Vector3 (3.87f,.19f,0.0f);
			Quaternion spawnRotation = Quaternion.identity;
			button_no = Random.Range(0,2);
			if(button_no==0)
			{

				//get the position and initiate object at the center

				clone.Add((GameObject)Instantiate (objs[i], spawnPosition1, transform.rotation));
				//Get the red right object
				GameObject leftGo = GameObject.FindGameObjectWithTag("bred");
				Text leftCo = leftGo.GetComponent<Text>();
				leftCo.text = characters[i];

				clone.Add((GameObject)Instantiate(objs[i+1], spawnPosition2,transform.rotation));
				//Get the red right object
				GameObject orangeGo = GameObject.FindGameObjectWithTag("borange");
				Text rightCo = orangeGo.GetComponent<Text>();
				rightCo.text = characters[i+2];

			}
			else
			{

				clone.Add((GameObject)Instantiate (objs[i], spawnPosition2, spawnRotation));
				//Get the red right object
				GameObject orangeGo = GameObject.FindGameObjectWithTag("borange");
				Text rightCo = orangeGo.GetComponent<Text>();
				rightCo.text = characters[i];

				clone.Add((GameObject)Instantiate (objs[i+1], spawnPosition1, spawnRotation));
				//Get the red right object
				GameObject leftGo = GameObject.FindGameObjectWithTag("bred");
				Text leftCo = leftGo.GetComponent<Text>();
				leftCo.text = characters[i+2];		

			}

			yield return new WaitForSeconds (1.4f);
			GameObject scoreGo = GameObject.FindGameObjectWithTag("score");
			Text scoreCo = scoreGo.GetComponent<Text>();
			
			GameObject GameoverGo = GameObject.FindGameObjectWithTag("Gameover");
			Text GameoverCo = GameoverGo.GetComponent<Text>();

			if(button_no == user_input)
			{
				Score = Score+100;
				scoreCo.text = "Score: " + Score;
			}
			else
			{
				Score = Score-100;
				scoreCo.text = "Score: " + Score;
			}

			if(Score<-300)
			{
				gameOver = true;
				GameoverCo.text = "Game Over! Press Space to restart";
			}
			if(Score>=2000)
			{
				gameOver = true;
				GameoverCo.text = "Congrats! Press F1 for next level";

			}
			if(i==21 && Score<2000)
			{
				gameOver = true;
				GameoverCo.text = "Game Over! Press Space to restart";
			}
			Destroy(clone[i]);
			Destroy(clone[i+1]);
			i++;
			
			
		}
	}
	
	
	
	
	
	
}
