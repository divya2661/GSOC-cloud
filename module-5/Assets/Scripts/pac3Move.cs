using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class pac3Move : MonoBehaviour {

	Vector2 firstPressPos;
	Vector2 secondPressPos;
	Vector2 currentSwipe;

	public float speed;
	public int i=0,score=0,j=0;
	public int time;
	public bool gameover = false;
	public List<GameObject> gameobjects = new List<GameObject>();
	public List<string> obj_list = new List<string>();
	public GameObject explosion_obj;
	Vector2 dest = Vector2.zero;
	GameObject dog,donkey,duck,apple;
	Vector2 dogpos,donkeypos,duckpos,applepos;
	void Start() {
		dest = transform.position;

		gameobjects.Add(GameObject.FindGameObjectWithTag ("banana"));
		gameobjects.Add(GameObject.FindGameObjectWithTag ("brinjal"));
		gameobjects.Add(GameObject.FindGameObjectWithTag ("peach"));
		gameobjects.Add(GameObject.FindGameObjectWithTag ("litchi"));
		gameobjects.Add(GameObject.FindGameObjectWithTag ("mushroom"));
		gameobjects.Add(GameObject.FindGameObjectWithTag ("guava"));
		gameobjects.Add(GameObject.FindGameObjectWithTag ("coconut"));
		gameobjects.Add(GameObject.FindGameObjectWithTag ("papaya"));
		gameobjects.Add(GameObject.FindGameObjectWithTag ("grapes"));
		gameobjects.Add(GameObject.FindGameObjectWithTag ("potato"));
		gameobjects.Add(GameObject.FindGameObjectWithTag ("apple"));
		gameobjects.Add(GameObject.FindGameObjectWithTag ("mango"));
		gameobjects.Add(GameObject.FindGameObjectWithTag ("carrot"));	
		gameobjects.Add(GameObject.FindGameObjectWithTag ("lemon"));
		gameobjects.Add(GameObject.FindGameObjectWithTag ("pear"));

		obj_list.Add ("banana");
		obj_list.Add ("brinjal");
		obj_list.Add ("peach");
		obj_list.Add ("litchi");
		obj_list.Add ("mushroom");
		obj_list.Add ("guava");

		obj_list.Add ("coconut");
		obj_list.Add ("papaya");
		obj_list.Add ("grapes");
		obj_list.Add ("potato");
		obj_list.Add ("apple");


		obj_list.Add ("mango");
		obj_list.Add ("carrot");
		obj_list.Add ("lemon");
		obj_list.Add ("pear");

		StartCoroutine (Spawn ());
	}

	public void Swipe()
	{
		
		if(Input.touches.Length > 0)
		{
			
			Touch t = Input.GetTouch(0);
			if(t.phase == TouchPhase.Began)
			{
				//save began touch 2d point
				firstPressPos = new Vector2(t.position.x,t.position.y);
			}
			if(t.phase == TouchPhase.Ended)
			{
				//save ended touch 2d point
				secondPressPos = new Vector2(t.position.x,t.position.y);
				
				//create vector from the two points
				currentSwipe = new Vector2(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);
				
				//normalize the 2d vector
				currentSwipe.Normalize();
				
				//swipe upwards
				if(currentSwipe.y > 0 && currentSwipe.x > -0.5f &&  currentSwipe.x < 0.5f)
				{
					Debug.Log("up swipe");
					dest = (Vector2)transform.position + Vector2.up;
				}
				//swipe down
				if(currentSwipe.y < 0 && currentSwipe.x > -0.5f &&  currentSwipe.x < 0.5f)
				{
					Debug.Log("down swipe");
					dest = (Vector2)transform.position - Vector2.up;
				}
				//swipe left
				if(currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
				{
					Debug.Log("left swipe");
					dest = (Vector2)transform.position - Vector2.right;
				}
				//swipe right
				if(currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
				{
					Debug.Log("right swipe");
					dest = (Vector2)transform.position + Vector2.right;
				}
			}
		}
		
		
	}
	
	void FixedUpdate() 
	{
		Swipe ();
		if (Input.GetKeyDown ("space")) 
		{
			Application.LoadLevel(Application.loadedLevel);
		}

		if (Input.GetKeyDown (KeyCode.F1)) 
		{
			Application.LoadLevel("level-2.1");
		}

		//Debug.Log (dest);
		// Move closer to Destination
		Vector2 p = Vector2.MoveTowards(transform.position, dest, speed*Time.deltaTime);
		GetComponent<Rigidbody2D>().MovePosition(p);
		
		// Check for Input if not moving
		
		if (Input.GetKey (KeyCode.UpArrow))
		{
			dest = (Vector2)transform.position + Vector2.up;
		}
		
		if (Input.GetKey (KeyCode.RightArrow)) 
		{
			dest = (Vector2)transform.position + Vector2.right;
		}
		if (Input.GetKey (KeyCode.DownArrow))
		{
			dest = (Vector2)transform.position - Vector2.up;
		}
		if (Input.GetKey (KeyCode.LeftArrow))
		{
			dest = (Vector2)transform.position - Vector2.right;
		}


		// Animation Parameters
		Vector2 dir = dest - (Vector2)transform.position;
		GetComponent<Animator>().SetFloat("DirX1", dir.x);
		GetComponent<Animator>().SetFloat("DirY1", dir.y);
		
	}
	void OnCollisionEnter2D(Collision2D col)
	{
		GameObject nametext = GameObject.FindGameObjectWithTag ("name");
		Text nametextco = nametext.GetComponent<Text> ();

		GameObject gameovertext = GameObject.FindGameObjectWithTag ("gameover");
		Text gameovertextco = gameovertext.GetComponent<Text> ();

		for (i=0; i<15; i++) {

			nametextco.text = obj_list[j];
			if (col.gameObject == gameobjects[i]) 
			{
				Instantiate(explosion_obj,col.transform.position,col.transform.rotation);
				Destroy(col.gameObject);

				if(col.gameObject.tag == obj_list[j])
				{
					score = score+100;
				}
				else
				{
					gameover = true;
					gameovertextco.text = "Game Over, Press Space To Restart";
				}

				j++;

			}
		}
	}

	IEnumerator Spawn()
	{	
		time = 100;
		while (time>=0 && gameover == false) 
		{
			GameObject scoretext = GameObject.FindGameObjectWithTag ("score");
			Text scoretextco = scoretext.GetComponent<Text> ();



			GameObject gameovertext = GameObject.FindGameObjectWithTag ("gameover");
			Text gameovertextco = gameovertext.GetComponent<Text> ();


			GameObject timetext = GameObject.FindGameObjectWithTag ("time");
			Text timetextco = timetext.GetComponent<Text> ();
			Debug.Log ("Time: " + time);
			timetextco.text = "Time: " + time;
			scoretextco.text = "Score: " + score;

			if(score == 1500)
			{
				gameover = true;
				gameovertextco.text = "Congrats, Level-2 Complete, Press F1 For Next Level";

			}
			if(score<1500 && time<=0)
			{
				gameover = true;
				gameovertextco.text = "Game Over, Press Space To Restart";
			}

			yield return new WaitForSeconds (3.0f);
			time = time - 1;
		}


	}


	public void Spaceclick()
	{

		Application.LoadLevel(Application.loadedLevel);
	}
	
	public void f1()
	{
		Application.LoadLevel("level-3.1");
	}

}

















