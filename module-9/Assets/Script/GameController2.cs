using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameController2 : MonoBehaviour {

	public int i=0,rand_num,j=0,rand_num1,rand_num2,score=0,time=10,check_click=0;
	public string answer;
	public List<Text>text_objs = new List<Text>();
	public List<string> characters = new List<string>();
	public List<string> chars = new List<string>();	
	public GameObject explosion_obj;
	// Use this for initialization
	void Start () {



		characters.Add("A juicy tropical fruit that has firm yellow and red skin and a hard seed at its center");
		characters.Add("A fungus that is shaped like an umbrella; especially : one that can be eaten");
		characters.Add("A yellowish-green fruit with black seeds and orange flesh that grows on a tropical tree");
		characters.Add("A citrus fruit that is round and that has an reddish yellow skin with pulpy slices inside, a color between red and yellow that is like the color carrots");
		characters.Add("A round, sweet fruit that has white or yellow flesh, soft yellow or pink skin, and a large, hard seed at the center");
		characters.Add("A small, round, green seed that is eaten as a vegetable and that is formed in a seed case");
		characters.Add("A sweet fruit that is narrow near the stem and rounded at the other end and that grows on a tree");
		characters.Add("A large fruit that grows on a tropical tree and that has thick and very rough skin and very sweet, juicy, yellow flesh");
		characters.Add("A starchy plant root brown colored with yellowish white flesh inside which is one of the most important food crops, cooked and eaten as a vegetable");
		characters.Add("A round, soft, red fruit that is eaten raw or cooked and that is often used in salads, sandwiches, sauces etc.");
		characters.Add("A round fruit with red, yellow, or green skin and firm white flesh");
		characters.Add("A long curved fruit with a thick greenish yellow peel that is yellowish white when it is ripe");
		characters.Add("Dark Purple/green a very low calorie vegetable and has healthy nutrition profile");
		characters.Add("The long orange/Red root of a plant that is eaten as a vegetable");
		characters.Add("A large fruit that has a thick hard brown/green shell with white flesh and liquid inside it and that grows on a palm tree");
		characters.Add("A green, dark red, or purplish-black berry that is used to make wine or is eaten as a fruit");
		characters.Add("The sweet yellow fruit of a tropical American tree");
		characters.Add("A yellow citrus fruit that has a sour taste a bright yellow color");
		characters.Add("The fruit of an Asian tree that has a hard outer covering and a seed surrounded by sweet white flesh");


		characters.Add("A big cat that roars");
		characters.Add("A long thin reptile which hisses and bites. It can be poisonous");
		characters.Add("A very large plant-eating mammal with a trunk");
		characters.Add("A waterbird with a broad blunt bill, short legs, webbed feet, and a waddling gait");
		characters.Add("A solid-hoofed plant-eating mammal with a flowing mane and tail, used for riding, racing, and to carry and pull loads");
		characters.Add("A type of animal that is closely related to apes and humans and that has a long tail and usually lives in treest");
		characters.Add("A bright-colored tropical bird that has a curved bill and the ability to imitate speech");
		characters.Add("A large male bird that has a very long bright blue and green tail that it can lift up and spread apart like a fan");
		characters.Add("A plant-eating mammal, with long ears, long hind legs, and a short tail");
		characters.Add("A marine reptiles that have a toothless horny beak and a hard shell to protect it");
		characters.Add ("A large long necked mammal ,It can survive for long periods without food or drink, chiefly by using up the fat reserves in their humps");
		characters.Add("A small mammal with soft fur. It is widely kept as a pet or for catching mice");
		characters.Add("A fully grown female animal, breed of ox, kept to produce milk or beef");
		characters.Add ("A mammal that typically has a long snout, an acute sense of smell, and a barking, howling, or whining voice");
		characters.Add("A domesticated hoofed mammal of the horse family with long ears and a braying call, used as a beast of burden");
		characters.Add("A big cat with orange and black stripes");
		characters.Add("A black and white bird which can not fly and lives in snow");
		characters.Add("A black and white bear which eat bamboo");





		chars.Add("mango");
		chars.Add("mushroom");
		chars.Add("papaya");
		chars.Add("orange");
		chars.Add("peach");
		chars.Add("peas");
		chars.Add("pear");
		chars.Add("pineapple");
		chars.Add("potato");
		chars.Add("tomato");
		chars.Add("apple"); 
		chars.Add("banana"); 
		chars.Add("brinjal"); 
		chars.Add("carrot"); 
		chars.Add("coconut");
		chars.Add("grape");
		chars.Add("guava");
		chars.Add("lemon");
		chars.Add("litchi");


		chars.Add("lion");
		chars.Add("snake");
		chars.Add("elephant");
		chars.Add("duck");
		chars.Add("horse");
		chars.Add("monkey");
		chars.Add("parrot");
		chars.Add("peacock");
		chars.Add("rabbit");
		chars.Add("turtle");
		chars.Add("camel");
		chars.Add("cat");
		chars.Add("cow");
		chars.Add("dog");
		chars.Add("donkey");
		chars.Add("tiger");
		chars.Add("penguin");
		chars.Add("panda");
			
		StartCoroutine (Spawn ());

	}

	IEnumerator Spawn()
	{
		//text object
		GameObject DeftextGo = GameObject.FindGameObjectWithTag ("definition");
		Text DeftextCo = DeftextGo.GetComponent<Text> ();

		while (i<38) {
			time=10;
			DeftextCo.text = characters [i];
			answer = chars [i];
			Debug.Log(answer[0]);
			while(time>=0)
			{
				yield return new WaitForSeconds (1.0f);
				time--;

			}

			if (score >= 3000 && i>=35) {
				DeftextCo.text = "Congratulations, Level-1 complete";
				Application.LoadLevel("end");
				i=39;
			}
			if (score < 3000 && i>=36) {
				DeftextCo.text = "Game Over";
				i=39;
			}
			i++;
		}




	}	
	
	// Update is called once per frame
	void Update () {
	

		GameObject scoretext = GameObject.FindGameObjectWithTag("score");
		Text scoretextco = scoretext.GetComponent<Text>();
		scoretextco.text = "Score: " + score;

		GameObject timetext = GameObject.FindGameObjectWithTag("time");
		Text timetextco = timetext.GetComponent<Text>();
		timetextco.text = "Time: " + time;

		//get the input field 
		GameObject inputFieldGo = GameObject.FindGameObjectWithTag("UserInput");
		InputField inputFieldCo = inputFieldGo.GetComponent<InputField>();
		answer = chars [i];
	


		if (inputFieldCo.text == chars [i])
		{
			Vector3 spawnPosition1 = new Vector3(-20.1f,-7.0f,0.0f);
			Quaternion spawnRotation1 = Quaternion.identity;
			Instantiate(explosion_obj , spawnPosition1 ,spawnRotation1);
			scoretextco.text = "Score:"+score;
			score = score+100;
			answer = "";
			inputFieldCo.text = "";
			time=0;
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
		Application.LoadLevel("level-1");
	}
}
