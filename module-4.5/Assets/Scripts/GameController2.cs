using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class GameController2 : MonoBehaviour {
	
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
		objs.Add (GameObject.FindGameObjectWithTag ("angry"));
		objs.Add (GameObject.FindGameObjectWithTag ("confident"));
		objs.Add (GameObject.FindGameObjectWithTag ("confused"));
		objs.Add (GameObject.FindGameObjectWithTag ("disgusting"));
		objs.Add (GameObject.FindGameObjectWithTag ("ecstatic"));
		objs.Add (GameObject.FindGameObjectWithTag ("frustrated"));
		objs.Add (GameObject.FindGameObjectWithTag ("happy"));
		objs.Add (GameObject.FindGameObjectWithTag ("hopeful"));
		objs.Add (GameObject.FindGameObjectWithTag ("hysteric"));
		objs.Add (GameObject.FindGameObjectWithTag ("lonely"));
		objs.Add (GameObject.FindGameObjectWithTag ("sad"));
		objs.Add (GameObject.FindGameObjectWithTag ("surprised"));
		objs.Add (GameObject.FindGameObjectWithTag ("angry"));
		objs.Add (GameObject.FindGameObjectWithTag ("confident"));
		objs.Add (GameObject.FindGameObjectWithTag ("confused"));
		objs.Add (GameObject.FindGameObjectWithTag ("disgusting"));
		objs.Add (GameObject.FindGameObjectWithTag ("ecstatic"));
		objs.Add (GameObject.FindGameObjectWithTag ("frustrated"));
		objs.Add (GameObject.FindGameObjectWithTag ("happy"));
		objs.Add (GameObject.FindGameObjectWithTag ("hopeful"));
		objs.Add (GameObject.FindGameObjectWithTag ("hysteric"));
		objs.Add (GameObject.FindGameObjectWithTag ("lonely"));
		objs.Add (GameObject.FindGameObjectWithTag ("sad"));
		objs.Add (GameObject.FindGameObjectWithTag ("surprised"));
		objs.Add (GameObject.FindGameObjectWithTag ("disgusting"));
		objs.Add (GameObject.FindGameObjectWithTag ("ecstatic"));
		objs.Add (GameObject.FindGameObjectWithTag ("frustrated"));
		
		characters.Add("angry");
		characters.Add("confident");
		characters.Add("confused");
		characters.Add("disgust");
		characters.Add("ecstatic");
		characters.Add("frustrated");
		characters.Add("happy");
		characters.Add("hopeful");
		characters.Add("hysteric");
		characters.Add("lonely");
		characters.Add("sad");
		characters.Add("surprised");
		characters.Add("angry");
		characters.Add("confident");
		characters.Add("confused");
		characters.Add("disgust");
		characters.Add("ecstatic");
		characters.Add("frustrated");
		characters.Add("happy");
		characters.Add("hopeful");
		characters.Add("hysteric");
		characters.Add("lonely");
		characters.Add("sad");
		characters.Add("surprised");
		characters.Add("angry");
		characters.Add("confident");
		characters.Add("confused");
		characters.Add("disgust");
		
		
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
			Application.LoadLevel("end");
		}
		if (Input.GetKey (KeyCode.RightArrow)) 
		{
			user_input = 2;
		}
		if (Input.GetKey (KeyCode.LeftArrow)) 
		{
			user_input = 0;
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
			destroy_clone=1;
			user_input = 2;
			button_no = Random.Range(0,2);
			Vector3 spawnPosition1 = new Vector3 (-4.5f,.29f,0.0f);
			Vector3 spawnPosition2 = new Vector3 (.18f,.32f,0.0f);
			Vector3 spawnPosition3 = new Vector3 (4.66f,.41f,0.0f);
			
			//get the left text box
			GameObject leftGo = GameObject.FindGameObjectWithTag("left");
			Text leftCo = leftGo.GetComponent<Text>();
			
			//get the middle text box
			GameObject middleGo = GameObject.FindGameObjectWithTag("middle");
			Text middleCo = middleGo.GetComponent<Text>();
			
			//get the right text box
			GameObject rightGo = GameObject.FindGameObjectWithTag("right");
			Text rightCo = rightGo.GetComponent<Text>();
			
			GameObject scoreGo = GameObject.FindGameObjectWithTag("score");
			Text scoreCo = scoreGo.GetComponent<Text>();
			
			GameObject GameoverGo = GameObject.FindGameObjectWithTag("Gameover");
			Text GameoverCo = GameoverGo.GetComponent<Text>();
			
			
			clone.Add((GameObject)Instantiate (objs[i], spawnPosition1, transform.rotation));
			clone.Add((GameObject)Instantiate (objs[i], spawnPosition2, transform.rotation));
			clone.Add((GameObject)Instantiate (objs[i], spawnPosition3, transform.rotation));
			
			
			if(button_no==0)
			{
				
				//set the left(answer) middle and right objects
				leftCo.text = characters[i];
				middleCo.text = characters[i+1];
				rightCo.text = characters[i+2];
			}
			if(button_no==1)
			{
				
				//set the left middle(answer) and right objects
				leftCo.text = characters[i+1];
				middleCo.text = characters[i];
				rightCo.text = characters[i+2];
			}
			if(button_no==2)
			{
				
				//set the left middle and right(answer) objects
				leftCo.text = characters[i+2];
				middleCo.text = characters[i+1];
				rightCo.text = characters[i];
			}
			
			yield return new WaitForSeconds (2.3f);
			
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
				Destroy(clone[i]);
				Destroy(clone[i+1]);
				Destroy(clone[i+2]);
				destroy_clone=0;
				leftCo.text = " ";
				rightCo.text = " ";
				GameoverCo.text = "Game Over, Plese press Space to restart";
			}
			if(Score >= 2000 && i>=20)
			{
				gameOver = true;
				Destroy(clone[i]);
				Destroy(clone[i+1]);
				Destroy(clone[i+2]);
				destroy_clone=0;
				leftCo.text = " ";
				rightCo.text = " ";
				GameoverCo.text = "Congrats, Please press F1 for next level";
			}
			if(Score <= 1500 && i>=20)
			{
				gameOver = true;
				Destroy(clone[i]);
				Destroy(clone[i+1]);
				Destroy(clone[i+2]);
				destroy_clone=0;
				leftCo.text = " ";
				rightCo.text = " ";
				GameoverCo.text = "Game Over, Plese press Space to restart";
			}
			if(destroy_clone==1)
			{
				Destroy(clone[i].gameObject);
				Destroy(clone[i+1].gameObject);
				Destroy(clone[i+2].gameObject);
				leftCo.text = "";
				rightCo.text = "";
			}

			
			
			
			i++;
			
		}
	}
	
	
	
	
	
	
}
