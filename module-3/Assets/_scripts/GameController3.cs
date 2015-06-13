using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class GameController3 : MonoBehaviour {
	
	public Camera cam;
	private float maxWidth;
	private int i=0,j=0;
	public List<string> Alphabets = new List<string>();
	public List<string> characters = new List<string>();
	public List<GameObject>clone = new List<GameObject> ();
	public List<GameObject>balloons = new List<GameObject> ();
	public List<string>Show = new List<string> ();
	public GameObject explosion_obj;
	public GameObject explosion_bal;
	public GUIText ScoreText;
	public int Score=0;
	private int str_length;
	public int health=5;
	public string ans;
	public string val;
	private bool gameOver=false;
	public int success=0;
	//private bool Restart = false;
	private int count=0;
	void Start () {
		if (cam == null) {
			cam = Camera.main;
		}
		
		characters.Add("apple");
		characters.Add("adfix");
		characters.Add("box");
		characters.Add("ball");
		characters.Add("cat");
		characters.Add("cloth");
		characters.Add("dog");
		characters.Add("dish");
		characters.Add("elephant");
		characters.Add("ex");
		characters.Add("fish");
		characters.Add("face");
		characters.Add("lens");
		characters.Add("lion");
		characters.Add("matrass");
		characters.Add("inch");
		characters.Add("orange");
		characters.Add("jess");
		characters.Add("kite");
		characters.Add("monk");
		characters.Add("nest");
		characters.Add("orris");
		characters.Add("peacock");
		characters.Add("patch");
		characters.Add("queen");
		characters.Add("rich");
		characters.Add("rat");
		characters.Add("gun");
		characters.Add("gas");
		characters.Add("house");
		characters.Add("jess");
		characters.Add("kite");
		characters.Add("mouse");
		characters.Add("nest");
		characters.Add("inkpot");
		characters.Add("kish");
		characters.Add("ship");
		characters.Add("taxi");
		characters.Add("tree");
		characters.Add("umbrella");
		characters.Add("van");
		characters.Add("watch");
		characters.Add("taxi");
		characters.Add("tree");
		characters.Add("umbrella");
		characters.Add("van");
		characters.Add("watch");
		characters.Add("wood");
		characters.Add("xray");
		characters.Add("yak");
		characters.Add("yes");
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
		if (Input.GetKey (KeyCode.F1)) 
		{	
				
			Application.LoadLevel("mid2");
		}

		if (Input.GetKey (KeyCode.LeftArrow)) 
		{
			//Debug.Log("left");
			ans = "s";
		}
		if (Input.GetKey (KeyCode.RightArrow)) {

			//Debug.Log ("right");
			ans = "es";
		
		}
	}
	
	IEnumerator Spawn()
	{

		while (gameOver == false && i<52) 
		{


			//Debug.Log(ans);
			GameObject scoretext = GameObject.FindGameObjectWithTag("Score");
			Text scoretextco = scoretext.GetComponent<Text>();
			//Debug.Log(ans);

			GameObject leftGo = GameObject.FindGameObjectWithTag("left");
			Text leftCo = leftGo.GetComponent<Text>();

			GameObject rightGo = GameObject.FindGameObjectWithTag("right");
			Text rightCo = rightGo.GetComponent<Text>();

				
			GameObject Gameover = GameObject.FindGameObjectWithTag("GameOver");
			Text Gameoverco = Gameover.GetComponent<Text>();
			//Gameoverco.text = "";
			
			GameObject restartText = GameObject.FindGameObjectWithTag("Restart");
			Text restartTextco = restartText.GetComponent<Text>();
			//restartTextco.text = "";
			//Debug.Log(characters[i]);
			//leftCo.text = "oye hoye";
			if(i%2==0)
			{
				rightCo.text = "";
				leftCo.text = characters[i];
				val = leftCo.text;
			}
			else {
				leftCo.text = "";
				rightCo.text = characters[i];
				val = rightCo.text;
			
			}
			yield return new WaitForSeconds (3.0f);
			GameObject inputFieldGo = GameObject.FindGameObjectWithTag("UserField");
			InputField inputFieldCo = inputFieldGo.GetComponent<InputField>();
			inputFieldCo.text = ans;
			//Debug.Log("here");


			str_length = val.Length-1;
			//Debug.Log("last :" + val[str_length]);
			//Debug.Log("second last :"  + val[str_length-1]);
			//Debug.Log("text :" + inputFieldCo.text);
			if(val[str_length]== 's' || val[str_length] == 'x' || val[str_length] == 'o' )
			{
				if(inputFieldCo.text == "es")
				{
					success = 1;
				}
				else 
				{	
					success = 0;
				}
			}
			else if(val[str_length]== 'h' && val[str_length-1] == 'c')
			{	
				if(inputFieldCo.text == "es")
				{
					success = 1;
				}
				else 
				{
					success = 0;
				}

			}
			else if(val[str_length]== 'h' && val[str_length-1] == 's')
			{
				if(inputFieldCo.text == "es")
				{
					success = 1;
				}
				else 
				{
					success = 0;
				}
				
			}
			else if(val[str_length]== 's' && val[str_length-1] == 's')
			{
				if(inputFieldCo.text == "es")
				{
					success = 1;
				}
				else 
				{
					success = 0;
				}
			}
			else
			{
				if(inputFieldCo.text == "s")
				{
					success = 1;
				}
				else 
				{
					success = 0;
				}
			}
			//Debug.Log(success);
			if (success == 1) 
			{
				//Instantiate(explosion_obj , 1.0f , transform.rotation);
				Score = Score+100;
				scoretextco.text = ": " + Score; 
				inputFieldCo.text = "";
				ans = "";
				
				
			}
			
			else
			{
				
				Score = Score-100;
				scoretextco.text = ": "+Score; 
				inputFieldCo.text = "";
				ans = "";

			}
			i++;
			if(i>=52 && Score>3500)
			{
				Gameoverco.text = "Congrats! Level-3.2 Done :)";
				restartTextco.text = "Press 'F1' for next level";
			}
			Debug.Log(Score);
			if(Score==-500)
			{
				Debug.Log("if...");
				Gameoverco.text = "Sorry! Game Over :)";
				restartTextco.text = "Press 'Space' to restart  level";
				gameOver = true;
			}

		}
	}
}