using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class GameController2 : MonoBehaviour {
	
	public Camera cam;
	public float maxWidth;
	private int i=0,j=0;
	public List<GameObject> Alphabets = new List<GameObject>();
	public List<string> characters = new List<string>();
	public List<string> Show = new List<string>();
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
		Alphabets.Add (GameObject.FindGameObjectWithTag ("apple"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("banana"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("brinjal"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("carrot"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("coconut"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("grapes"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("guava"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("lemon"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("litchi"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("mango"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("mushroom"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("onion"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("orange"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("papaya"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("peach"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("pear"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("peas"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("pineapple"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("potato"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("strawberry"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("tomato"));
		
		//creating list of correct answee to corresponding alphabet list
		characters.Add("apple");
		characters.Add("banana");
		characters.Add("brinjal");
		characters.Add("carrot");
		characters.Add("coconut");
		characters.Add("grapes");
		characters.Add("guava");
		characters.Add("lemon");
		characters.Add("litchi");
		characters.Add("mango");
		characters.Add("mushroom");
		characters.Add("onion");
		characters.Add("orange");
		characters.Add("papaya");
		characters.Add("peach");
		characters.Add("pear");
		characters.Add("peas");
		characters.Add("pineapple");
		characters.Add("potato");
		characters.Add("strawberry");
		characters.Add("tomato");
		
		Show.Add("a_p_e");
		Show.Add("b_na__");
		Show.Add("br_n__l");
		Show.Add("c_r_o_");
		Show.Add("c_c_n_t");
		Show.Add("g_a_e_");
		Show.Add("g_a_a");
		Show.Add("l_m_n");
		Show.Add("l_t_h_");
		Show.Add("ma__o");
		Show.Add("mu_hr__m");
		Show.Add("_n_o_");
		Show.Add("_r_ng_");
		Show.Add("_a_a_a");
		Show.Add("p_a_h");
		Show.Add("p__r");
		Show.Add("p_a_");
		Show.Add("pi__ap__e");
		Show.Add("_o_a_o");
		Show.Add("s_r__be__y");
		Show.Add("t_m_to");
		
		
		Vector3 upperCorner = new Vector3 (Screen.width, Screen.height, 0.0f);
		Vector3 targetWidth = cam.ScreenToWorldPoint (upperCorner);
		maxWidth = targetWidth.x;
		
		StartCoroutine(Spawn());
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
		
	}
	
	IEnumerator Spawn()
	{
		
		yield return new WaitForSeconds (2.0f);
		while (gameOver == false && i<21) {
			

			//get the position and initiate object at the center
			
			Vector3 spawnPosition = new Vector3(Random.Range(-11.0f,8.8f),-8.8f,0.0f);
			Quaternion spawnRotation = Quaternion.identity;
			clone.Add((GameObject)Instantiate (Alphabets[i], spawnPosition, spawnRotation));
			
			
			GameObject showGo = GameObject.FindGameObjectWithTag("show");
			Text showCo = showGo.GetComponent<Text>();
			showCo.text = Show[i];
			yield return new WaitForSeconds (4.0f);
			
			GameObject inputFieldGo = GameObject.FindGameObjectWithTag("UserInput");
			InputField inputFieldCo = inputFieldGo.GetComponent<InputField>();
			
			GameObject scoreGo = GameObject.FindGameObjectWithTag("score");
			Text scoreCo = scoreGo.GetComponent<Text>();
			
			GameObject GameoverGo = GameObject.FindGameObjectWithTag("Gameover");
			Text GameoverCo = GameoverGo.GetComponent<Text>();
			
			if(inputFieldCo.text == characters[i])
			{
				Vector3 pos = clone[i].transform.position;
				Instantiate(explosion_obj , pos ,transform.rotation);
				Destroy(clone[i].gameObject);
				Score = Score+100;
				scoreCo.text = "Score: " + Score;
				inputFieldCo.text = "";
				
			}
			else
			{
				Vector3 bal_pos = new Vector3(-11.0f,-8.8f,0.0f);
				Instantiate(explosion_bal,bal_pos,transform.rotation);
				Destroy(clone[i].gameObject);
				Score = Score - 100;
				scoreCo.text = "Score: " + Score;
				inputFieldCo.text = "";
			}
			if(Score == -300)
			{
				GameoverCo.text = "Game Over! Press Space to restart";
				i=21;
			}
			if(Score < 1700 && i==20)
			{
				GameoverCo.text = "Game Over! Press Space to restart";
			}
			if(Score >= 1700 && i==20)
			{
				GameoverCo.text = "Congrats! Press F1 For Next Level";
			}
			
			i++;
			
			
		}
	}
	
	
	
	
	
	
}
