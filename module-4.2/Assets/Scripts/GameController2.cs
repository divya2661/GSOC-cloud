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
		Alphabets.Add (GameObject.FindGameObjectWithTag ("buffalo"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("camel"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("cat"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("cow"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("crane"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("dog"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("crow"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("donkey"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("duck"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("elephant"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("goat"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("hen"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("horse"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("monkey"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("panda"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("peacock"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("parrot"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("penguin"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("rabbit"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("rat"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("sheep"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("snake"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("sparrow"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("tiger"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("turtle"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("yak"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("zebra"));
		
		//creating list of correct answee to corresponding alphabet list
		characters.Add("buffalo");
		characters.Add("camel");
		characters.Add("cat");
		characters.Add("cow");
		characters.Add("crane");
		characters.Add("dog");
		characters.Add("crow");
		characters.Add("donkey");
		characters.Add("duck");
		characters.Add("elephant");
		characters.Add("goat");
		characters.Add("hen");
		characters.Add("horse");
		characters.Add("monkey");
		characters.Add("panda");
		characters.Add("peacock");
		characters.Add("parrot");
		characters.Add("penguin");
		characters.Add("rabbit");
		characters.Add("rat");
		characters.Add("sheep");
		characters.Add("snake");
		characters.Add("sparrow");
		characters.Add("tiger");
		characters.Add("turtle");
		characters.Add("yak");
		characters.Add("zebra");


		Show.Add("b_f_a_o");
		Show.Add("ca__l");
		Show.Add("c_t");
		Show.Add("c_w");
		Show.Add("c__n_");
		Show.Add("d_g");
		Show.Add("c__w");
		Show.Add("d_n_e_");
		Show.Add("d__k");
		Show.Add("e_e_ha_t");
		Show.Add("g__t");
		Show.Add("h_n");
		Show.Add("ho__e");
		Show.Add("m_n_ey");
		Show.Add("p_n_a");
		Show.Add("p_a_o_k");
		Show.Add("pa_r_t");
		Show.Add("p_n_u_n");
		Show.Add("ra_b_t");
		Show.Add("r_t");
		Show.Add("sh__p");
		Show.Add("s_a_e");
		Show.Add("s_a_r_w");
		Show.Add("t_g_r");
		Show.Add("t_r_l_");
		Show.Add("y_k");
		Show.Add("z_b_a");
		
		
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
		while (gameOver == false && i<27) {
			

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
			if(Score < 2200 && i==26)
			{
				GameoverCo.text = "Game Over! Press Space to restart";
			}
			if(Score >= 2200 && i==26)
			{
				GameoverCo.text = "Congrats! Press F1 For Next Level";
			}
			
			i++;
			
			
		}
	}
	
	
	
	
	
	
}
