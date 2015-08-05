using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class GameController2 : MonoBehaviour {

	public static GameController2 instace;
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
	public int Score;
	private bool gameOver=false;
	private bool Restart = false;
	public int veg=0,animal=0,num;


	
	
	void Start () {
		if (cam == null) {
			cam = Camera.main;
		}
		instace = this;
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
		Alphabets.Add (GameObject.FindGameObjectWithTag ("buffalo"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("camel"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("cat"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("cow"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("crane"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("crow"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("dog"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("donkey"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("duck"));
		Alphabets.Add (GameObject.FindGameObjectWithTag ("elephant"));

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
			Application.LoadLevel("end");
		}

		GameObject scoreGo = GameObject.FindGameObjectWithTag("Score");
		Text scoreCo = scoreGo.GetComponent<Text>();
		scoreCo.text = "Score: " + Score;
		
	}
	
	IEnumerator Spawn()
	{

		
		yield return new WaitForSeconds (2.0f);
		while (gameOver == false && i<60) {
			

			//get the position and initiate object at the center
			
			Vector3 spawnPosition1 = new Vector3(Random.Range(-1.5f,2.0f),-7.0f,0.0f);
			Quaternion spawnRotation1 = Quaternion.identity;

			Vector3 spawnPosition2 = new Vector3(Random.Range(-1.5f,1.8f),-7.0f,0.0f);
			Quaternion spawnRotation2 = Quaternion.identity;

			Vector3 spawnPosition3 = new Vector3(Random.Range(-1.5f,1.8f),-7.0f,0.0f);
			Quaternion spawnRotation3 = Quaternion.identity;

			Vector3 spawnPosition4 = new Vector3(Random.Range(-1.5f,2.0f),-7.0f,0.0f);
			Quaternion spawnRotation4 = Quaternion.identity;
			
			Vector3 spawnPosition5 = new Vector3(Random.Range(-1.5f,1.8f),-7.0f,0.0f);
			Quaternion spawnRotation5 = Quaternion.identity;
			
			Vector3 spawnPosition6 = new Vector3(Random.Range(-1.5f,1.8f),-7.0f,0.0f);
			Quaternion spawnRotation6 = Quaternion.identity;

			//gameover text object
			GameObject GameoverGo = GameObject.FindGameObjectWithTag("GameOver");
			Text GameoverCo = GameoverGo.GetComponent<Text>();

			GameObject midGo = GameObject.FindGameObjectWithTag("midtext");
			Text midCo = midGo.GetComponent<Text>();

			//generate a random number
			num = Random.Range(0,100);
			if(num%2==0)
			{
				veg=1;
				animal=0;
				midCo.text = "Fruits";
			}
			else
			{
				veg=0;
				animal=1;
				midCo.text = "Animal";


			}

			clone.Add((GameObject)Instantiate (Alphabets[Random.Range(1,22)], spawnPosition1, spawnRotation1));
			clone.Add((GameObject)Instantiate (Alphabets[Random.Range(1,22)], spawnPosition2, spawnRotation2));
			clone.Add((GameObject)Instantiate (Alphabets[Random.Range(1,22)], spawnPosition3, spawnRotation3));
			clone.Add((GameObject)Instantiate (Alphabets[Random.Range(1,22)], spawnPosition4, spawnRotation4));
			clone.Add((GameObject)Instantiate (Alphabets[Random.Range(1,22)], spawnPosition5, spawnRotation5));
			clone.Add((GameObject)Instantiate (Alphabets[Random.Range(1,22)], spawnPosition6, spawnRotation6));		


			if(Score>=20000)
			{
				midCo.text=" ";
				GameoverCo.text = "Congrats, Level-3 complete";
			}
			if(Score<10000 && i>=52)
			{
				midCo.text=" ";
				GameoverCo.text = "Game Over, Press restart";
			}
			yield return new WaitForSeconds (2.0f);
			i++;

		}
	}
	public void Spaceclick()
	{
		
		Application.LoadLevel(Application.loadedLevel);
	}
	
	public void f1click()
	{
		Application.LoadLevel("end");
	}
	public void backclick()
	{
		Application.LoadLevel("level-2");
	}
}
