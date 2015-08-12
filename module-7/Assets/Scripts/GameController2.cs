using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameController2 : MonoBehaviour {
	
	public int time,i=0,j,success=0,score=0,k=0,gameover=0,tm=0,val_tm;
	public GameObject explosion_obj;
	public string s1,s2;
	public List<string> characters = new List<string>();
	public List<string> chars = new List<string>();
	public List<int> nums= new List<int>();
	
	// Use this for initialization
	void Start () {
		characters.Add("buffalo");
		characters.Add("camel");
		characters.Add("cat");
		characters.Add("cow");
		characters.Add("crane");
		characters.Add("dog");
		characters.Add("donkey");
		characters.Add("duck");
		characters.Add("elephant");
		characters.Add("goat");
		characters.Add("hen");
		characters.Add("horse");
		characters.Add("monkey");
		characters.Add("panda");
		characters.Add("parrot");
		characters.Add("peacock");
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
		
		nums.Add (4);
		nums.Add (1);
		nums.Add (3);
		nums.Add (1);
		nums.Add (3);
		nums.Add (1);
		nums.Add (2);
		nums.Add (3);
		nums.Add (2);
		nums.Add (1);
		nums.Add (1);
		nums.Add (2);
		nums.Add (1);


		chars.Add("p");
		chars.Add("y");
		chars.Add("c");
		chars.Add("z");
		chars.Add("d");
		chars.Add("e");
		chars.Add("r");
		chars.Add("s");
		chars.Add("t");
		chars.Add("g");
		chars.Add("b");
		chars.Add("h");
		chars.Add("m");

		StartCoroutine (Spawn ());
	}
	
	IEnumerator Spawn()
	{
		while (k<14 && gameover==0)
		{
			
			success=0;
			//get the input field 
			GameObject inputFieldGo = GameObject.FindGameObjectWithTag ("input");
			InputField inputFieldCo = inputFieldGo.GetComponent<InputField> ();
			
			//get the game over field 
			GameObject GameoverGo  = GameObject.FindGameObjectWithTag("GameOver");
			Text GameoverCo = GameoverGo.GetComponent<Text>();
			
			//get the number field 
			GameObject NumberGo  = GameObject.FindGameObjectWithTag("number");
			Text NumberCo = NumberGo.GetComponent<Text>();
			
			inputFieldCo.text = chars [k];	
			NumberCo.text = "Number: " + nums[k];
			val_tm = nums[k]*3;
			
			while(nums[k]!=0 && tm<val_tm)
			{
				yield return new WaitForSeconds (1.0f);
				tm++;
			}
			
			if(k>=12 && score>=2000)
			{
				GameoverCo.text = "Congrats, Level-1 Complete";
				gameover = 1;
			}
			if(k>=12 && score<2000)
			{
				GameoverCo.text = "Game Over";
				gameover = 	1;
			}
			tm=0;
			
			
			k++;
			
		}
	}
	// Update is called once per frame
	void Update () {
		//get the input field 
		GameObject inputFieldGo = GameObject.FindGameObjectWithTag("input");
		InputField inputFieldCo = inputFieldGo.GetComponent<InputField>();
		
		//get the user input field 
		GameObject userinputFieldGo = GameObject.FindGameObjectWithTag("UserInput");
		InputField userinputFieldCo = userinputFieldGo.GetComponent<InputField>();
		for (i=0; i<26; i++) 
		{
			
			if(characters[i]== userinputFieldCo.text && characters[i]!="null")
			{
				characters[i] ="null";
				s1 = inputFieldCo.text;
				s2 = userinputFieldCo.text;
				for(j=0;j<s1.Length;j++)
				{
					
					if(s1[j]==s2[j])
					{
						success=1;
					}
					else
					{
						success=0;
					}
				}
				if(success==1)
				{
					GameObject scoretext = GameObject.FindGameObjectWithTag("score");
					Text scoretextco = scoretext.GetComponent<Text>();
					score = score+100;
					//get the number field 
					GameObject NumberGo  = GameObject.FindGameObjectWithTag("number");
					Text NumberCo = NumberGo.GetComponent<Text>();
					nums[k]=nums[k]-1;
					NumberCo.text = "Number: " + nums[k];
					Vector3 spawnPosition1 = new Vector3(-20.1f,-7.0f,0.0f);
					Quaternion spawnRotation1 = Quaternion.identity;
					
					Instantiate(explosion_obj , spawnPosition1 ,spawnRotation1);
					scoretextco.text = "Score:"+score;
					success=0;
					userinputFieldCo.text="";
				}
				
			}
		}
	}
	
	public void restartclick()
	{
		
		Application.LoadLevel(Application.loadedLevel);
	}
	
	public void nextclick()
	{
		Application.LoadLevel("level-3");
	}
	public void backclick()
	{
		Application.LoadLevel("level-1");
	}
	
}
