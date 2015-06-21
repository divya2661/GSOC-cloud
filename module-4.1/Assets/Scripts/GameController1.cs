using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class GameController1 : MonoBehaviour {
	
	public Camera cam;
	private float maxWidth;
	private int i=0,j=0;
	public List<GameObject> Alphabets = new List<GameObject>();
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
		Alphabets.Add (GameObject.FindGameObjectWithTag ("mushroom"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("onion"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("orange"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("papaya"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("peach"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("pear"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("peas"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("pineapple"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("potato"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("strawberry"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("tomato"));

		//creating list of correct answee to corresponding alphabet list
		characters.Add("apple");
		characters.Add("banana");
		characters.Add("brinjal");
		characters.Add("carrot");
		characters.Add("coconut");
		characters.Add("grapes");
		characters.Add("guava");
		characters.Add("lemon");
		characters.Add("litchi");
		characters.Add("mango");
		characters.Add("mushroom");
		characters.Add("onion");
		characters.Add("orange");
		characters.Add("papaya");
		characters.Add("peach");
		characters.Add("pear");
		characters.Add("peas");
		characters.Add("pineapple");
		characters.Add("potato");
		characters.Add("strawberry");
		characters.Add("tomato");


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
		
		//yield return new WaitForSeconds (1.0f);
		while (gameOver == false && i<21) {

			user_input = 4;  
			//get the position and initiate object at the center
			Vector3 spawnPosition = new Vector3 (-1.2f,1.3f,0.0f);
			Quaternion spawnRotation = Quaternion.identity;
			clone.Add((GameObject)Instantiate (Alphabets[i], spawnPosition, spawnRotation));


			//Get the orange text object
			GameObject orangeGo = GameObject.FindGameObjectWithTag("orangeb");
			Text orangeCo = orangeGo.GetComponent<Text>();
			orangeCo.text = "";

			//Get the red text object
			GameObject redGo = GameObject.FindGameObjectWithTag("red");
			Text redCo = redGo.GetComponent<Text>();
			redCo.text = "";

			//Get the blue text object
			GameObject blueGo = GameObject.FindGameObjectWithTag("blue");
			Text blueCo = blueGo.GetComponent<Text>();
			blueCo.text = "";

			//Get the yellow text object
			GameObject yellowGo = GameObject.FindGameObjectWithTag("yellow");
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

					rand1 = Random.Range(0,18);
					if(rand1 == i){rand1 = rand1 + 1;}
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
				i=22;
				gameOver = true;
				GameoverCo.text = "Game Over";
				orangeCo.text  = "Press";
				blueCo.text = "Space";
				redCo.text = "To";
				yellowCo.text = "Restart";

			}
			else
			{
				if(Score>=1700 && i == 20)
				{

					GameoverCo.text = "Congrats";
					orangeCo.text  = "Press";
					blueCo.text = "F1";
					redCo.text = "For";
					yellowCo.text = "Next";
				}
				if(Score<1700 && i==20)
				{ 
					Destroy(clone[i]);
					gameOver = true;
					GameoverCo.text = "Game Over";
					orangeCo.text  = "Press";
					blueCo.text = "Space";
					redCo.text = "To";
					yellowCo.text = "Restart";
				}
			}




			Destroy(clone[i]);

			i++;


		}
	}






}
