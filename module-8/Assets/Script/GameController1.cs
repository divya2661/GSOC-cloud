using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
public class GameController1 : MonoBehaviour {

	//char[] char_array = new char[30];
	//char_array = new char[30];

	public int i=0,j,score=0,num=6,time=60;
	public string s;
	public GameObject explosion_obj;
	public GameObject explosion_bal;
	public List<string> answers = new List<string>();
	public Vector3 spawnPosition = new Vector3(10.0f,10.0f,0.0f);
	public Quaternion spawnRotation = Quaternion.identity;
	// Use this for initialization
	void Start ()
	{
		answers.Add("APPLE");
		answers.Add ("BALL");
		answers.Add("CAT");
		answers.Add ("RAT");
		answers.Add("CARROT");
		answers.Add("PARROT");


		StartCoroutine (Spawn ());
	}
	
	// Update is called once per frame
	void Update () {
		GameObject UItextGo = GameObject.FindGameObjectWithTag("Input");
		Text UItextco = UItextGo.GetComponent<Text>();

		GameObject scoreGo = GameObject.FindGameObjectWithTag("score");
		Text scoreco = scoreGo.GetComponent<Text>();

		GameObject numberGo = GameObject.FindGameObjectWithTag("number");
		Text numberco = numberGo.GetComponent<Text>();
		numberco.text = "Number: "+num;

		UItextco.text = s;
		for (j=0; j<6; j++)
		{
			if(answers[j]==s)
			{
				score=score+200;
				Instantiate(explosion_bal ,spawnPosition ,spawnRotation);
				scoreco.text = "Score: " + score;
				i=0;
				s="";
				num--;
				answers[j]="null";

			}
		}
		if (score == 1200 && time>=0) 
		{
			UItextco.text = "Congrats, Level-1 complete";
		}
		if(time<=0 && score<1200)
		{
			UItextco.text = "Game Over";
			score=0;
			s="";

		}
	}

	IEnumerator Spawn()
	{
		GameObject timeGo = GameObject.FindGameObjectWithTag("time");
		Text timeco = timeGo.GetComponent<Text>();
		while (time>=0) {
			timeco.text = "Time: "+time;
			yield return new WaitForSeconds (1.0f);
			time--;

		}


	}
	public void Aclick()
	{
		//Debug.Log ("clicked");

		Instantiate(explosion_obj ,spawnPosition ,spawnRotation);
		s = s.Insert (i,"A");

		i++;
	}

	public void Pclick()
	{
		Instantiate(explosion_obj ,spawnPosition ,spawnRotation);
		s = s.Insert (i,"P");
		
		i++;
	}

	public void Lclick()
	{
		//Debug.Log ("clicked");
		Instantiate(explosion_obj ,spawnPosition ,spawnRotation);
		s = s.Insert (i,"L");
		
		i++;
	}

	public void Bclick()
	{
		//Debug.Log ("clicked");
		Instantiate(explosion_obj ,spawnPosition ,spawnRotation);
		s = s.Insert (i,"B");
		
		i++;
	}

	public void Cclick()
	{
		//Debug.Log ("clicked");
		Instantiate(explosion_obj ,spawnPosition ,spawnRotation);
		s = s.Insert (i,"C");
		
		i++;
	}

	public void Oclick()
	{
		//Debug.Log ("clicked");
		Instantiate(explosion_obj ,spawnPosition ,spawnRotation);
		s = s.Insert (i,"O");
		i++;
	}

	public void Eclick()
	{
		//Debug.Log ("clicked");
		Instantiate(explosion_obj ,spawnPosition ,spawnRotation);
		s = s.Insert (i,"E");
		
		i++;
	}
	public void Tclick()
	{
		//Debug.Log ("clicked");
		Instantiate(explosion_obj ,spawnPosition ,spawnRotation);
		s = s.Insert (i,"T");
		
		i++;
	}
	public void Rclick()
	{
		//Debug.Log ("clicked");
		Instantiate(explosion_obj ,spawnPosition ,spawnRotation);
		s = s.Insert (i,"R");
		
		i++;
	}

	public void Clearclick()
	{
		GameObject UItextGo = GameObject.FindGameObjectWithTag("Input");
		Text UItextco = UItextGo.GetComponent<Text>();
		s = "";
		i = 0;
	}

	public void restartclick()
	{
		
		Application.LoadLevel(Application.loadedLevel);
	}
	
	public void nextclick()
	{
		Application.LoadLevel("level-2");
	}
	public void backclick()
	{
		Application.LoadLevel("main");
	}
}
