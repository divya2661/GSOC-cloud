using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class GameController1 : MonoBehaviour {
	
	public Camera cam;

	private int i=0,j=0;

	public List<string> characters = new List<string>();
	public List<string> numbers = new List<string> ();
	public List<Text>text_objects = new List<Text> ();
	public GameObject explosion_obj;
	public GameObject explosion_bal;
	public GUIText ScoreText;
	public int Score=0;
	public int button_no;
	public Text ans_button;
	public int rand1,user_input;

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
			user_input = 2;
			button_no = Random.Range(0,2);

			GameObject leftGo = GameObject.FindGameObjectWithTag("left");
			Text leftCo = leftGo.GetComponent<Text>();

			GameObject rightGo = GameObject.FindGameObjectWithTag("right");
			Text rightCo = rightGo.GetComponent<Text>();

			GameObject numleftGo = GameObject.FindGameObjectWithTag("numleft");
			Text numleftCo = numleftGo.GetComponent<Text>();


			GameObject numrightGo = GameObject.FindGameObjectWithTag("numright");
			Text numrightCo = numrightGo.GetComponent<Text>();

			GameObject scoreGo = GameObject.FindGameObjectWithTag("score");
			Text scoreCo = scoreGo.GetComponent<Text>();
			
			GameObject GameoverGo = GameObject.FindGameObjectWithTag("Gameover");
			Text GameoverCo = GameoverGo.GetComponent<Text>();

			if(button_no==0)
			{

				//Get the left one

				leftCo.text = characters[i];


				numleftCo.text = numbers[i];

	
				//Get the right object
				rand1 = Random.Range(0,15);
				if(rand1 == i){rand1 = rand1+1;}

				rightCo.text = characters[rand1];
				numrightCo.text = numbers[rand1+1];

			}
			else
			{
				rand1 = Random.Range(0,15);
				if(rand1 == i){rand1 = rand1+1;}
				leftCo.text = characters[rand1];
				numleftCo.text = numbers[rand1+1];
				
				
				//Get the right object
				
				rightCo.text = characters[i];
				
				
				numrightCo.text = numbers[i];


			}
			yield return new WaitForSeconds (1.3f);
			if(user_input == button_no)
			{
				Score = Score+100;

			}
			else
			{
				Score = Score - 100;


			}
			scoreCo.text = "Score: " + Score;
			if(Score<=-300)
			{
				gameOver = true;
				leftCo.text = " ";
				rightCo.text = " ";
				numleftCo.text = " ";
				numrightCo.text = " ";
				GameoverCo.text = "Game Over, Plese press Space to restart";
			}
			if(Score >= 2000 && i>=20)
			{
				gameOver = true;
				leftCo.text = " ";
				rightCo.text = " ";
				numleftCo.text = " ";
				numrightCo.text = " ";
				GameoverCo.text = "Congrats, Please press F1 for next level";
			}
			if(Score <= 2000 && i>=20)
			{
				gameOver = true;
				leftCo.text = " ";
				rightCo.text = " ";
				numleftCo.text = " ";
				numrightCo.text = " ";
				GameoverCo.text = "Game Over, Plese press Space to restart";
			}


			i++;
			
		}
	}
	
	
	
	
	
	
}
