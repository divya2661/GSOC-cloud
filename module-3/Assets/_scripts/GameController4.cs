using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class GameController4 : MonoBehaviour {
	
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
		

		characters.Add ("apple");
		characters.Add("box");
		characters.Add("cat");
		characters.Add("cloth");
		characters.Add("dog");
		characters.Add("elephant");
		characters.Add("dish");
		characters.Add("ex");
		characters.Add("fish");
		characters.Add("face");
		characters.Add("orange");
		characters.Add("lens");
		characters.Add("lion");
		characters.Add("adfix");
		characters.Add("matrass");
		characters.Add("inch");
		characters.Add("orange");
		characters.Add("jess");
		characters.Add("kite");
		characters.Add("orris");
		characters.Add("monkey");
		characters.Add("nest");
		characters.Add("peacock");
		characters.Add("orange");
		characters.Add("patch");
		characters.Add("queen");
		characters.Add("icecube");
		characters.Add("rich");
		characters.Add("rat");
		characters.Add("gun");
		characters.Add("umbrella");
		characters.Add("house");
		characters.Add("umbrella");
		characters.Add("jess");
		characters.Add("kite");
		characters.Add("monkey");
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
		characters.Add("umbrella");
		characters.Add("wood");
		characters.Add("xray");
		characters.Add("umbrella");
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


		if (Input.GetKey (KeyCode.LeftArrow)) 
		{
			//Debug.Log("left");
			ans = "a";
		}
		if (Input.GetKey (KeyCode.RightArrow)) {

			//Debug.Log ("right");
			ans = "an";
		
		}
	}
	
	IEnumerator Spawn()
	{

		while (gameOver == false) 
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
			Gameoverco.text = "";
			
			GameObject restartText = GameObject.FindGameObjectWithTag("Restart");
			Text restartTextco = restartText.GetComponent<Text>();
			restartTextco.text = "";
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
			yield return new WaitForSeconds (2.0f);
			GameObject inputFieldGo = GameObject.FindGameObjectWithTag("UserField");
			InputField inputFieldCo = inputFieldGo.GetComponent<InputField>();
			inputFieldCo.text = ans;
			//Debug.Log("here");


			str_length = val.Length-1;
			//Debug.Log("last :" + val[str_length]);
			//Debug.Log("second last :"  + val[str_length-1]);
			//Debug.Log("text :" + inputFieldCo.text);
			if(val[0]== 'a' || val[0] == 'e' || val[0] == 'i' || val[0] == 'o' || val[0]=='u')
			{
				if(inputFieldCo.text == "an")
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
				if(inputFieldCo.text == "a")
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
			Debug.Log(i);
			if(i>=55 && Score>4500)
			{
				Gameoverco.text = "Congrats :)";
				Application.LoadLevel("end");
			}
			if(Score==-500)
			{
				gameOver = true;
				Gameoverco.text = "Sorry! Game Over :(";
				restartTextco.text = "Press 'Space' to restart level";
			}

		}
	}
}

