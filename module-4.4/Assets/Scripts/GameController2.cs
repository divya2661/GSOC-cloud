using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class GameController2 : MonoBehaviour {
	
	public Camera cam;
	
	private int i=0,j=0;
	
	public List<string> characters = new List<string>();
	public List<string> numbers = new List<string> ();
	public GUIText ScoreText;
	public int Score=0;
	public int button_no;
	public Text ans_button;
	public int rand1,rand2,user_input;
	public int health=5;
	private bool gameOver=false;
	void Start () {
		if (cam == null) {
			cam = Camera.main;
		}
		
		//creating list of all numbers
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
		numbers.Add("6");
		numbers.Add("17");

		//list of corresponding spellings
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
		characters.Add("Six");
		characters.Add("Seventeen");
		
		
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

		}
		//getting user input
		if (Input.GetKey (KeyCode.LeftArrow)) 
		{
			user_input = 0;
		}
		if (Input.GetKey (KeyCode.RightArrow)) 
		{
			user_input = 2;
		}
		if (Input.GetKey (KeyCode.UpArrow)) 
		{
			user_input = 1;
		}

		
	}
	
	IEnumerator Spawn()
	{
		yield return new WaitForSeconds (1.0f);
		
		while (gameOver == false && i<22) {
			user_input = 4;
			button_no = Random.Range(0,3);

			//get the left most spelling box
			GameObject leftGo = GameObject.FindGameObjectWithTag("left");
			Text leftCo = leftGo.GetComponent<Text>();

			//get the middle spelling box
			GameObject middleGo = GameObject.FindGameObjectWithTag("middle");
			Text middleCo = middleGo.GetComponent<Text>();

			//get the right spelling box
			GameObject rightGo = GameObject.FindGameObjectWithTag("right");
			Text rightCo = rightGo.GetComponent<Text>();

			//get the left most number box
			GameObject numleftGo = GameObject.FindGameObjectWithTag("numleft");
			Text numleftCo = numleftGo.GetComponent<Text>();

			//get the middle number box
			GameObject nummiddleGo = GameObject.FindGameObjectWithTag("nummiddle");
			Text nummiddleCo = nummiddleGo.GetComponent<Text>();

			//get the right most number box
			GameObject numrightGo = GameObject.FindGameObjectWithTag("numright");
			Text numrightCo = numrightGo.GetComponent<Text>();

			//get the Game Over text box
			GameObject scoreGo = GameObject.FindGameObjectWithTag("score");
			Text scoreCo = scoreGo.GetComponent<Text>();

			//get the Score text box
			GameObject GameoverGo = GameObject.FindGameObjectWithTag("Gameover");
			Text GameoverCo = GameoverGo.GetComponent<Text>();

			//setting numbers and spellings in the boxes according to the numbers
			if(button_no==0)
			{
				
				//Get the left one
				
				leftCo.text = characters[i];
				
				
				numleftCo.text = numbers[i];
				
				
				//Get the right object
				rand1 = Random.Range(0,15);
				if(rand1 == i){rand1 = rand1+1;}

				rand2 = Random.Range(0,18);
				if(rand2 == i){rand2 = rand2+1;}
				
				rightCo.text = characters[rand1];
				numrightCo.text = numbers[rand1+1];

				middleCo.text = characters[rand2];
				nummiddleCo.text = numbers[rand2+1];
				
			}
			if(button_no == 1)
			{
				rand1 = Random.Range(0,15);
				if(rand1 == i){rand1 = rand1+1;}

				rand2 = Random.Range(0,18);
				if(rand2 == i){rand2 = rand2+1;}

				leftCo.text = characters[rand1];
				numleftCo.text = numbers[rand1+1];

				rightCo.text = characters[rand2];
				numrightCo.text = numbers[rand2+1];

				middleCo.text = characters[i];
				nummiddleCo.text = numbers[i];
	
			}
			if(button_no == 2)
			{
				rand1 = Random.Range(0,15);
				if(rand1 == i){rand1 = rand1+1;}
				
				rand2 = Random.Range(0,18);
				if(rand2 == i){rand2 = rand2+1;}

				leftCo.text = characters[rand1];
				numleftCo.text = numbers[rand1+1];

				middleCo.text = characters[rand2];
				nummiddleCo.text = numbers[rand2+1];

				rightCo.text = characters[i];
				numrightCo.text = numbers[i];
			}

			//wait for user input
			yield return new WaitForSeconds (2.0f);
			//check user input with the answer
			if(user_input == button_no)
			{
				Score = Score+100;

			}
			else
			{
				Score = Score - 100;


			}
			scoreCo.text = "Score: " + Score;
			if(Score<-300)
			{
				gameOver = true;
				leftCo.text = " ";
				middleCo.text = " ";
				rightCo.text = " ";

				numleftCo.text = " ";
				nummiddleCo.text = " ";
				numrightCo.text = " ";
				GameoverCo.text = "Game Over, Plese press Space to restart";
			}
			if(Score >= 1500 && i>=20)
			{

				gameOver = true;
				Application.LoadLevel("end");
			}
			if(Score <= 1500 && i>=20)
			{
				gameOver = true;
				leftCo.text = " ";
				middleCo.text = " ";
				rightCo.text = " ";

				numleftCo.text = " ";
				numrightCo.text = " ";
				nummiddleCo.text = " ";
				GameoverCo.text = "Game Over, Plese press Space to restart";
			}
			
			
			i++;
			
		}
	}
	
	
	
	
	
	
}
