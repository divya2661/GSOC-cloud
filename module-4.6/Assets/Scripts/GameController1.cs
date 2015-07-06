using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class GameController1 : MonoBehaviour {
	
	public Camera cam;

	private int i=0,j=0;

	public List<string> characters = new List<string>();
	public List<GameObject>objs = new List<GameObject>();
	public List<GameObject>clone = new List<GameObject> ();
	public List<string> numbers = new List<string> ();
	public List<Text>text_objects = new List<Text> ();
	public GameObject explosion_obj;
	public GameObject explosion_bal;
	public GUIText ScoreText;
	public int Score=0,destroy_clone;
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

		while (gameOver == false && i<24) {
			destroy_clone=1;
			user_input = 2;
			button_no = Random.Range(0,2);
			Vector3 spawnPosition1 = new Vector3 (-3.6f,2.18f,0.0f);
			Vector3 spawnPosition2 = new Vector3 (3.31f,-.87f,0.0f);
			GameObject leftGo = GameObject.FindGameObjectWithTag("left");
			Text leftCo = leftGo.GetComponent<Text>();

			GameObject rightGo = GameObject.FindGameObjectWithTag("right");
			Text rightCo = rightGo.GetComponent<Text>();

			GameObject scoreGo = GameObject.FindGameObjectWithTag("score");
			Text scoreCo = scoreGo.GetComponent<Text>();
			
			GameObject GameoverGo = GameObject.FindGameObjectWithTag("Gameover");
			Text GameoverCo = GameoverGo.GetComponent<Text>();






			if(button_no==0)
			{

				//set the left and right objects
				clone.Add((GameObject)Instantiate (objs[i], spawnPosition1, transform.rotation));
				clone.Add((GameObject)Instantiate (objs[i+1], spawnPosition2, transform.rotation));
				leftCo.text = characters[i];
				
				rightCo.text = characters[i+2];



			}
			else
			{
				//set the left and right objects
				clone.Add((GameObject)Instantiate (objs[i+1], spawnPosition1, transform.rotation));
				clone.Add((GameObject)Instantiate (objs[i], spawnPosition2, transform.rotation));
				leftCo.text = characters[i+2];
				
				rightCo.text = characters[i];

			}

			yield return new WaitForSeconds (2.0f);

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
				Destroy(clone[j]);
				Destroy(clone[j+1]);
				destroy_clone=0;
				leftCo.text = " ";
				rightCo.text = " ";
				GameoverCo.text = "Game Over, Plese press Space to restart";
			}
			if(Score >= 2000 && i>=20)
			{
				gameOver = true;
				Destroy(clone[j]);
				Destroy(clone[j+1]);
				destroy_clone=0;
				leftCo.text = " ";
				rightCo.text = " ";
				GameoverCo.text = "Congrats, Please press F1 for next level";
			}
			if(Score <= 2000 && i>=24)
			{
				gameOver = true;
				Destroy(clone[j]);
				Destroy(clone[j+1]);
				destroy_clone=0;
				leftCo.text = " ";
				rightCo.text = " ";
				GameoverCo.text = "Game Over, Plese press Space to restart";
			}

			if(destroy_clone == 1)
			{
				Destroy(clone[j]);
				Destroy(clone[j+1]);
				leftCo.text = "";
				rightCo.text = "";
			}
			i++;
			j = j+2;
			
		}
	}
	
	
	
	
	
	
}
