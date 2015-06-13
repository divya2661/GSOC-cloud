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
	public List<GameObject>balloons = new List<GameObject> ();
	public GameObject explosion_obj;
	public GameObject explosion_bal;
	public GUIText ScoreText;
	public int Score=0;
	public int health=5;
	private bool gameOver=false;
	private bool Restart = false;
	private int count=0;
	public string vo;

	
	void Start () {
		if (cam == null) {
			cam = Camera.main;
		}

		Alphabets.Add (GameObject.FindGameObjectWithTag ("n"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("c"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("e"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("g"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("d"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("e"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("a"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("o"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("f"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("u"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("h"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("a"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("j"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("b"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("u"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("l"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("i"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("e"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("q"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("o"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("m"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("t"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("r"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("x"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("u"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("e"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("a"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("v"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("u"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("o"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("k"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("p"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("w"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("o"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("s"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("z"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("o"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("y"));


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
		if (Input.GetKey(KeyCode.F1))
		{

			Application.LoadLevel("mid1");

		}
		if (Input.GetKey (KeyCode.V)) {

			vo = "v";

		
		}
		if (Input.GetKey (KeyCode.C)) {
			//vow.GetComponent<SpriteRenderer>().enabled = false;
			vo = "c";
			//Cons.GetComponent<SpriteRenderer> ().enabled = true;
			
		}

	}

	IEnumerator Spawn()
	{
		
		//yield return new WaitForSeconds (1.0f);
		while (gameOver == false && i<38) {
			Vector3 spawnPosition = new Vector3 (Random.Range (-maxWidth, maxWidth), transform.position.y, 0.0f);
			Quaternion spawnRotation = Quaternion.identity;
			yield return new WaitForSeconds (1.0f);
			clone.Add((GameObject)Instantiate (Alphabets[i], spawnPosition, spawnRotation));
			yield return new WaitForSeconds (2.1f);


			GameObject inputFieldGo = GameObject.FindGameObjectWithTag("UserField");
			InputField inputFieldCo = inputFieldGo.GetComponent<InputField>();
			inputFieldCo.text = vo;


			GameObject scoretext = GameObject.FindGameObjectWithTag("Score");
			Text scoretextco = scoretext.GetComponent<Text>();

			GameObject Gameover = GameObject.FindGameObjectWithTag("GameOver");
			Text Gameoverco = Gameover.GetComponent<Text>();
			Gameoverco.text = "";
			
			GameObject restartText = GameObject.FindGameObjectWithTag("Restart");
			Text restartTextco = restartText.GetComponent<Text>();
			restartTextco.text = "";

			if (i==2 || i==5 || i==6 || i==7 || i==9 || i==11 || i==14 || i==16 || i==17 || i==19 || i==24 || i==25 || i==26 || i==28 || i==29 || i==33 || i==36) 
			{
				if(inputFieldCo.text == "v")
				{

					Vector3 pos = clone[i].transform.position;
					Instantiate(explosion_obj , pos ,transform.rotation);
					Destroy(clone[i].gameObject);
					Score = Score+100;
					scoretextco.text = "Score: " + Score; 
					inputFieldCo.text = "";
					vo = "";

				}
				else
				{
					Vector3 pos = clone[i].transform.position;
					Instantiate(explosion_obj , pos ,transform.rotation);
					Destroy(clone[i].gameObject);
					Score = Score-100;
					scoretextco.text = "Score: " + Score; 
					inputFieldCo.text = "";
					vo = "";
				}


			}

			else
			{
				if(inputFieldCo.text == "c")
				{
					Vector3 pos = clone[i].transform.position;
					Instantiate(explosion_obj , pos ,transform.rotation);
					Destroy(clone[i].gameObject);
					Score = Score+100;
					scoretextco.text = "Score: " + Score; 
					inputFieldCo.text = "";
				}
				else
				{
					Vector3 pos = clone[i].transform.position;
					Instantiate(explosion_obj , pos ,transform.rotation);
					Destroy(clone[i].gameObject);
					Score = Score-100;
					scoretextco.text = "Score: " + Score;
					inputFieldCo.text = "";
				}


			}
			i++;
			count++;
			Debug.Log(i);
			if(i==38 || Score<-500)
			{
				if(Score >= 2500)
				{
					Gameoverco.text = "Congrats! Level-3.1 Done :)";
					restartTextco.text = "Press 'F1' For Next Level";
				}
				else if(Score <= -500)
				{
					Gameoverco.text = "Game Over :(";
					restartTextco.text = "Press 'Space' To Restart";
				}
				else
				{
					Gameoverco.text = "Game Over :(";
					restartTextco.text = "Press 'Space' To Restart";
				}

			}

		}
	}






}
