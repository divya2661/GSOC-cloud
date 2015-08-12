using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameController3 : MonoBehaviour {
	
	public int time,i=0,j,success=0,score=0,k=0,gameover=0,tm=0,val_tm;
	public GameObject explosion_obj;
	public string s1,s2;
	public List<string> characters = new List<string>();
	public List<string> chars = new List<string>();
	public List<int> nums= new List<int>();
	
	// Use this for initialization
	void Start () {

		characters.Add("apple");
		characters.Add("avocado");
		characters.Add ("buffalo");
		characters.Add("banana");
		characters.Add("brinjal");
		characters.Add("blackberry");
		characters.Add("blueberry");
		characters.Add("camel");
		characters.Add("cat");
		characters.Add("cow");
		characters.Add("carrot");
		characters.Add("corn");
		characters.Add("coconut");
		characters.Add("dog");
		characters.Add("donkey");
		characters.Add("duck");
		characters.Add("elephant");
		characters.Add("goat");
		characters.Add("grapes");
		characters.Add("guava");
		characters.Add("hen");
		characters.Add("horse");
		characters.Add("lemon");
		characters.Add("litchi");
		characters.Add("monkey");
		characters.Add("mango");
		characters.Add("mushroom");
		characters.Add("onion");
		characters.Add("orange");
		characters.Add("papaya");
		characters.Add("peach");
		characters.Add("pear");
		characters.Add("peas");
		characters.Add("panda");
		characters.Add("parrot");
		characters.Add("peacock");
		characters.Add("penguin");
		characters.Add("pineapple");
		characters.Add("potato");
		characters.Add("rabbit");
		characters.Add("rat");
		characters.Add("strawberry");
		characters.Add("sheep");
		characters.Add("snake");
		characters.Add("sparrow");
		characters.Add("tomato");
		characters.Add("tiger");
		characters.Add("turtle");
		characters.Add("yak");
		characters.Add("zebra");


		nums.Add (3);
		nums.Add (5);
		nums.Add (2);
		nums.Add (2);
		nums.Add (3);

		nums.Add (2);
		nums.Add (2);
		nums.Add (3);

		nums.Add (3);
		nums.Add (2);
		nums.Add (4);

		nums.Add (3);
		nums.Add (1);
		nums.Add (1);
		nums.Add (3);

		nums.Add (2);
		nums.Add (4);
		nums.Add (3);
		nums.Add (1);



		chars.Add("pa");
		chars.Add("pe");
		chars.Add("h");
		chars.Add("l");
		chars.Add("m");

		chars.Add("o");
		chars.Add("a");
		chars.Add("d");

		chars.Add("ca");
		chars.Add("p");
		chars.Add("b");

		chars.Add("co");
		chars.Add("z");
		chars.Add("e");
		chars.Add("g");

		chars.Add("r");
		chars.Add("s");
		chars.Add("t");
		chars.Add("y");


		StartCoroutine (Spawn ());
	}
	
	IEnumerator Spawn()
	{
		while (k<19 && gameover==0)
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
			val_tm =nums[k]*4;


			while(nums[k]!=0 && tm<val_tm)
			{
				yield return new WaitForSeconds (1.0f);
				tm++;
			}
			Debug.Log(k);
			if(k>=18 && score>=4500)
			{
				GameoverCo.text = "Congrats, Level-1 Complete";
				gameover = 1;
			}
			if(k>=18 && score<4500)
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
		for (i=0; i<50; i++) 
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
		Application.LoadLevel("end");
	}
	public void backclick()
	{
		Application.LoadLevel("level-2");
	}
	
}
