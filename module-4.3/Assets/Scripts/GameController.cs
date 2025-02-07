﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class GameController : MonoBehaviour {
	
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
		objs.Add (GameObject.FindGameObjectWithTag ("brown"));
		objs.Add (GameObject.FindGameObjectWithTag ("pink"));
		objs.Add (GameObject.FindGameObjectWithTag ("purple")); 
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
		characters.Add("brown");
		characters.Add("pink");
		characters.Add("purple");
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
			Application.LoadLevel("level2");
		}
		if (Input.GetKey (KeyCode.UpArrow)) 
		{
			user_input = 0;
		}
		if (Input.GetKey (KeyCode.DownArrow)) 
		{
			user_input = 1;
		}
		if (Input.GetKey (KeyCode.RightArrow)) 
		{
			user_input = 2;
		}
		if (Input.GetKey (KeyCode.LeftArrow)) 
		{
			user_input = 3;
		}
		
	}
	
	IEnumerator Spawn()
	{
		
		yield return new WaitForSeconds (2.0f);
		while (gameOver == false && i<24) {
			
			user_input = 4;  
			//get the position and initiate object at the center
			Vector3 spawnPosition = new Vector3 (0.0f,0.0f,0.0f);
			Quaternion spawnRotation = Quaternion.identity;
			clone.Add((GameObject)Instantiate (objs[i], spawnPosition, spawnRotation));
			
			
			//Get the orange text object
			GameObject orangeGo = GameObject.FindGameObjectWithTag("borange");
			Text orangeCo = orangeGo.GetComponent<Text>();
			orangeCo.text = "";
			
			//Get the red text object
			GameObject redGo = GameObject.FindGameObjectWithTag("bred");
			Text redCo = redGo.GetComponent<Text>();
			redCo.text = "";
			
			//Get the blue text object
			GameObject blueGo = GameObject.FindGameObjectWithTag("bblue");
			Text blueCo = blueGo.GetComponent<Text>();
			blueCo.text = "";
			
			//Get the yellow text object
			GameObject yellowGo = GameObject.FindGameObjectWithTag("bgreen");
			Text yellowCo = yellowGo.GetComponent<Text>();
			yellowCo.text = "";
			
			GameObject scoreGo = GameObject.FindGameObjectWithTag("score");
			Text scoreCo = scoreGo.GetComponent<Text>();
			
			GameObject GameoverGo = GameObject.FindGameObjectWithTag("Gameover");
			Text GameoverCo = GameoverGo.GetComponent<Text>();
			
			
			//create a list of text objects
			text_objects.Add(orangeCo);
			text_objects.Add(redCo);
			text_objects.Add(blueCo);
			text_objects.Add(yellowCo);
			
			//getting a random number to appear the right answer
			button_no  = Random.Range(0,4);
			
			for(int j=0;j<4;j++)
			{
				//Debug.Log("no if: "+characters[i]);
				
				if(j!=button_no)
				{
					
					rand1 = Random.Range(0,12);
					if(rand1 == i%12){rand1 = rand1 + 1;}
					text_objects[j].text = characters[rand1];
					
					
				}
				else
				{
					ans = j;
					text_objects[button_no].text = characters[i];
				}
			}
			
			yield return new WaitForSeconds (2.1f);
			if(user_input == ans)
			{
				Score = Score + 100;
			}
			else
			{
				Score = Score-100;
			}
			scoreCo.text = "Score: " + Score;
			if(Score<-300)
			{
				Destroy(clone[i]);
				i=26;
				gameOver = true;
				GameoverCo.text = "Game Over";
				orangeCo.text  = "Space";
				blueCo.text = "Restart";
				redCo.text = "To";
				yellowCo.text = "Press";
				
			}
			else
			{
				if(Score>=2000 && i >= 23)
				{
					
					GameoverCo.text = "Congrats";
					orangeCo.text  = "F1";
					blueCo.text = "Next";
					redCo.text = "For";
					yellowCo.text = "Press";
				}
				if(Score<2000 && i==23)
				{ 
					Destroy(clone[i]);
					gameOver = true;
					GameoverCo.text = "Game Over";
					orangeCo.text  = "Space";
					blueCo.text = "Restart";
					redCo.text = "To";
					yellowCo.text = "Press";
				}
			}
			
			
			
			
			Destroy(clone[i]);
			
			i++;
			
			
		}
	}
	
	
	
	
	
	
}
