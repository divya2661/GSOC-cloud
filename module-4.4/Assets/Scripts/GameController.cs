using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class GameController : MonoBehaviour {
	
	public Camera cam;
	private int i=0,j=0;
	public List<GameObject>objs = new List<GameObject>();
	public List<string> characters = new List<string>();
	public List<string> numbers = new List<string> ();
	public List<Text>text_objects = new List<Text> ();
	public GUIText ScoreText;
	public int Score=0;
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
		numbers.Add("2");
		numbers.Add("3");
		numbers.Add("9");
		numbers.Add("10");
		numbers.Add("4");
		numbers.Add("0");
		numbers.Add("1");
		numbers.Add("5");
		numbers.Add("7");
		numbers.Add("8");
		numbers.Add("15");
		numbers.Add("16");
		numbers.Add("6");
		numbers.Add("17");
		numbers.Add("19");
		numbers.Add("20");
		numbers.Add("11");
		numbers.Add("18");
		numbers.Add("12");
		numbers.Add("14");
		numbers.Add("13");
		numbers.Add("0");
		numbers.Add("1");

		characters.Add("Two");
		characters.Add("Three");
		characters.Add("Nine");
		characters.Add("Ten");
		characters.Add("Four");
		characters.Add("Zero");
		characters.Add("One");
		characters.Add("Five");
		characters.Add("Seven");
		characters.Add("Eight");
		characters.Add("Fifteen");
		characters.Add("Sixteen");
		characters.Add("Six");
		characters.Add("Seventeen");
		characters.Add("Nineteen");
		characters.Add("Twenty");
		characters.Add("Eleven");
		characters.Add("Eighteen");
		characters.Add("Twelve");
		characters.Add("Fourteen");
		characters.Add("Thirteen");
		characters.Add("Zero");
		characters.Add("One");

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
		while (gameOver == false && i<23) {
			
			user_input = 4;  
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

			GameObject numberGo = GameObject.FindGameObjectWithTag("number");
			Text numberCo = numberGo.GetComponent<Text>();
			numberCo.text = numbers[i];
			
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
			
			for(int j=0;j<4;j++)
			{
				//Debug.Log("no if: "+characters[i]);
				
				if(j!=button_no)
				{
					
					rand1 = Random.Range(0,21);
					if(rand1 == i%20){rand1 = rand1 + 1;}
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
			if(Score<=-300)
			{
				numberCo.text = " ";
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
				if(Score>=2000 && i >= 22)
				{
					numberCo.text = " ";
					GameoverCo.text = "Congrats";
					downCo.text  = "Next";
					rightCo.text = "For";
					upCo.text = "F1";
					leftCo.text = "Press";
				}
				if(Score<2000 && i==22)
				{ 
					numberCo.text = " ";
					gameOver = true;
					GameoverCo.text = "Game Over";
					upCo.text  = "Space";
					downCo.text = "Restart";
					rightCo.text = "To";
					leftCo.text = "Press";
				}
			}

			i++;
			
			
		}
	}
	
	
	
	
	
	
}
