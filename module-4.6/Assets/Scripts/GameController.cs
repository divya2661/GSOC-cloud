using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class GameController : MonoBehaviour {
	
	public Camera cam;
	private int i=0,j=0;
	public List<GameObject>objs = new List<GameObject>();
	public List<string> characters = new List<string>();
	public List<GameObject>clone = new List<GameObject> ();
	public List<string> numbers = new List<string> ();
	public List<Text>text_objects = new List<Text> ();
	public GUIText ScoreText;
	public int Score=0,destroy_clone;
	public int button_no;
	public Text ans_button;
	public int rand1,ans,user_input;
	public string str;
	public int string_len;
	private bool gameOver=false;
	
	
	void Start () {
		if (cam == null) {
			cam = Camera.main;
		}

		//creating list of correct answee to corresponding alphabet list
		objs.Add (GameObject.FindGameObjectWithTag ("cone"));
		objs.Add (GameObject.FindGameObjectWithTag ("cylinder"));
		objs.Add (GameObject.FindGameObjectWithTag ("circle"));
		objs.Add (GameObject.FindGameObjectWithTag ("hexagon"));
		objs.Add (GameObject.FindGameObjectWithTag ("octagon"));
		objs.Add (GameObject.FindGameObjectWithTag ("oval"));
		objs.Add (GameObject.FindGameObjectWithTag ("sphere"));
		objs.Add (GameObject.FindGameObjectWithTag ("pentagon"));
		objs.Add (GameObject.FindGameObjectWithTag ("pyramid"));
		objs.Add (GameObject.FindGameObjectWithTag ("rectangle"));
		objs.Add (GameObject.FindGameObjectWithTag ("square"));
		objs.Add (GameObject.FindGameObjectWithTag ("star"));
		objs.Add (GameObject.FindGameObjectWithTag ("trapezoid"));
		objs.Add (GameObject.FindGameObjectWithTag ("triangle"));
		objs.Add (GameObject.FindGameObjectWithTag ("cuboid"));
		objs.Add (GameObject.FindGameObjectWithTag ("pentagon"));
		objs.Add (GameObject.FindGameObjectWithTag ("pyramid"));
		objs.Add (GameObject.FindGameObjectWithTag ("rectangle"));
		objs.Add (GameObject.FindGameObjectWithTag ("cone"));
		objs.Add (GameObject.FindGameObjectWithTag ("cylinder"));
		objs.Add (GameObject.FindGameObjectWithTag ("circle"));
		objs.Add (GameObject.FindGameObjectWithTag ("hexagon"));
		objs.Add (GameObject.FindGameObjectWithTag ("octagon"));
		objs.Add (GameObject.FindGameObjectWithTag ("oval"));
		objs.Add (GameObject.FindGameObjectWithTag ("square"));
		objs.Add (GameObject.FindGameObjectWithTag ("star"));
		objs.Add (GameObject.FindGameObjectWithTag ("trapezoid"));
		objs.Add (GameObject.FindGameObjectWithTag ("triangle"));
		objs.Add (GameObject.FindGameObjectWithTag ("cuboid"));

		characters.Add("cone");
		characters.Add("cylinder");
		characters.Add("circle");
		characters.Add("hexagon");
		characters.Add("octagon");
		characters.Add("oval");
		characters.Add("sphere");
		characters.Add("pentagon");
		characters.Add("pyramid");
		characters.Add("rectangle");
		characters.Add("square");
		characters.Add("star");
		characters.Add("trapezoid");
		characters.Add("triangle");
		characters.Add("cuboid");
		characters.Add("pentagon");
		characters.Add("pyramid");
		characters.Add("rectangle");
		characters.Add("cone");
		characters.Add("cylinder");
		characters.Add("circle");
		characters.Add("hexagon");
		characters.Add("octagon");
		characters.Add("oval");
		characters.Add("square");
		characters.Add("star");
		characters.Add("trapezoid");
		characters.Add("triangle");
		characters.Add("cuboid");

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
		if (Input.GetKey (KeyCode.LeftArrow)) 
		{
			user_input = 0;
		}
		if (Input.GetKey (KeyCode.RightArrow)) 
		{
			user_input = 1;
		}
		if (Input.GetKey (KeyCode.UpArrow)) 
		{
			user_input = 2;
		}
		if (Input.GetKey (KeyCode.DownArrow)) 
		{
			user_input = 3;
		}

	}
	
	IEnumerator Spawn()
	{
		
		yield return new WaitForSeconds (2.0f);
		while (gameOver == false && i<25) {
			destroy_clone=1;
			user_input = 4;  
			//Get the answer text object
			GameObject answerGo = GameObject.FindGameObjectWithTag("answer");
			Text answerCo = answerGo.GetComponent<Text>();


			//Get the orange text object
			GameObject orangeGo = GameObject.FindGameObjectWithTag("borange");
			Text upCo = orangeGo.GetComponent<Text>();
			upCo.text = "";
			
			//Get the red text object
			GameObject redGo = GameObject.FindGameObjectWithTag("bred");
			Text downCo = redGo.GetComponent<Text>();
			downCo.text = "";
			
			//Get the blue text object
			GameObject blueGo = GameObject.FindGameObjectWithTag("bblue");
			Text rightCo = blueGo.GetComponent<Text>();
			rightCo.text = "";	
			
			//Get the yellow text object
			GameObject yellowGo = GameObject.FindGameObjectWithTag("bgreen");
			Text leftCo = yellowGo.GetComponent<Text>();
			leftCo.text = "";

			GameObject scoreGo = GameObject.FindGameObjectWithTag("score");
			Text scoreCo = scoreGo.GetComponent<Text>();
			
			GameObject GameoverGo = GameObject.FindGameObjectWithTag("Gameover");
			Text GameoverCo = GameoverGo.GetComponent<Text>();
			
			
			//create a list of text objects
			text_objects.Add(leftCo);
			text_objects.Add(rightCo);
			text_objects.Add(upCo);
			text_objects.Add(downCo);
			
			//getting a random number to appear the right answer
			button_no  = Random.Range(0,4);

			Vector3 spawnPosition1 = new Vector3 (-3.62f,0.0f,0.0f);
			clone.Add((GameObject)Instantiate (objs[i], spawnPosition1, transform.rotation));
			for(int j=0;j<4;j++)
			{
				//Debug.Log("no if: "+characters[i]);


				if(j!=button_no)
				{
					
					rand1 = Random.Range(0,13);
					if(rand1 == i%12){rand1 = rand1 + 1;}
					text_objects[j].text = characters[rand1];
					
					
				}
				else
				{
					ans = j;
					text_objects[button_no].text = characters[i];
					answerCo.text = characters[i];
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
			if(Score<=-300)
			{
				Destroy(clone[i].gameObject);

				answerCo.text = "";
				destroy_clone = 0;
				i=26;
				gameOver = true;

				GameoverCo.text = "Game Over";
				upCo.text  = "Space";
				downCo.text = "Restart";
				rightCo.text = "To";
				leftCo.text = "Press";
				
			}
			else
			{
				if(Score>=2000 && i >= 23)
				{
					Destroy(clone[i].gameObject);

					answerCo.text = "";
					destroy_clone = 0;
					GameoverCo.text = "Congrats";
					downCo.text  = "Next";
					rightCo.text = "For";
					upCo.text = "F1";
					leftCo.text = "Press";
				}
				if(Score<2000 && i>=23)
				{ 

					gameOver = true;
					Destroy(clone[i].gameObject);

					answerCo.text = "";
					destroy_clone = 0;
					GameoverCo.text = "Game Over";
					upCo.text  = "Space";
					downCo.text = "Restart";
					rightCo.text = "To";
					leftCo.text = "Press";
				}
			}
			if(destroy_clone == 1)
			{
				Destroy(clone[i].gameObject);

			}


			i++;
			
			
		}
	}
	
	
	
	
	
	
}
