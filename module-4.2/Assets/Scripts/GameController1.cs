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
		Alphabets.Add (GameObject.FindGameObjectWithTag ("buffalo"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("camel"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("cat"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("cow"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("crane"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("dog"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("crow"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("donkey"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("duck"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("elephant"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("goat"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("hen"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("horse"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("monkey"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("panda"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("peacock"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("parrot"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("penguin"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("rabbit"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("rat"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("sheep"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("snake"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("sparrow"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("tiger"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("turtle"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("yak"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("zebra"));

		//creating list of correct answee to corresponding alphabet list
		characters.Add("buffalo");
		characters.Add("camel");
		characters.Add("cat");
		characters.Add("cow");
		characters.Add("crane");
		characters.Add("dog");
		characters.Add("crow");
		characters.Add("donkey");
		characters.Add("duck");
		characters.Add("elephant");
		characters.Add("goat");
		characters.Add("hen");
		characters.Add("horse");
		characters.Add("monkey");
		characters.Add("panda");
		characters.Add("peacock");
		characters.Add("parrot");
		characters.Add("penguin");
		characters.Add("rabbit");
		characters.Add("rat");
		characters.Add("sheep");
		characters.Add("snake");
		characters.Add("sparrow");
		characters.Add("tiger");
		characters.Add("turtle");
		characters.Add("yak");
		characters.Add("zebra");


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
		while (gameOver == false && i<26) {

			user_input = 4;  
			//get the position and initiate object at the center
			Vector3 spawnPosition = new Vector3 (-1.2f,1.3f,0.0f);
			Quaternion spawnRotation = Quaternion.identity;
			clone.Add((GameObject)Instantiate (Alphabets[i], spawnPosition, spawnRotation));


			//Get the orange text object
			GameObject orangeGo = GameObject.FindGameObjectWithTag("orange_b");
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
			GameObject yellowGo = GameObject.FindGameObjectWithTag("green");
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
				if(Score>=2200 && i == 25)
				{

					GameoverCo.text = "Congrats";
					orangeCo.text  = "Press";
					blueCo.text = "F1";
					redCo.text = "For";
					yellowCo.text = "Next";
				}
				if(Score<2200 && i==25)
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