using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class pac1Move1_1 : MonoBehaviour {

	Vector2 firstPressPos;
	Vector2 secondPressPos;
	Vector2 currentSwipe;

	public float speed;
	public int i=0,score=0;
	public int time;
	public bool gameover = false;
	public List<GameObject> gameobjects = new List<GameObject>();
	public GameObject explosion_obj;
	Vector2 dest = Vector2.zero;
	GameObject dog,donkey,duck,apple;
	Vector2 dogpos,donkeypos,duckpos,applepos;
	void Start() {
		dest = transform.position;

		gameobjects.Add(GameObject.FindGameObjectWithTag ("banana"));
		gameobjects.Add(GameObject.FindGameObjectWithTag ("apple"));
		gameobjects.Add(GameObject.FindGameObjectWithTag ("carrot"));
		gameobjects.Add(GameObject.FindGameObjectWithTag ("panda"));
		gameobjects.Add(GameObject.FindGameObjectWithTag ("rabbit"));
		gameobjects.Add(GameObject.FindGameObjectWithTag ("dog"));
		gameobjects.Add(GameObject.FindGameObjectWithTag ("donkey"));
		gameobjects.Add(GameObject.FindGameObjectWithTag ("duck"));

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
			Application.LoadLevel("level-1.2");
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
		for (i=0; i<8; i++) {
			if (col.gameObject == gameobjects[i]) 
			{
				Instantiate(explosion_obj,col.transform.position,col.transform.rotation);
				Destroy(col.gameObject);
				if(i>2){score = score+100;}
				else{
					GameObject gameovertext = GameObject.FindGameObjectWithTag ("gameover");
					Text gameovertextco = gameovertext.GetComponent<Text> ();
					gameover = true;
					gameovertextco.text = "Game Over, Press Space To Restart";
				}
			}

		
		}
	}

	IEnumerator Spawn()
	{	
		time = 25;
		while (time>=0 && gameover == false) 
		{
			GameObject scoretext = GameObject.FindGameObjectWithTag ("score");
			Text scoretextco = scoretext.GetComponent<Text> ();

			GameObject nametext = GameObject.FindGameObjectWithTag ("name");
			Text nametextco = nametext.GetComponent<Text> ();
			nametextco.text = "Animals";

			GameObject gameovertext = GameObject.FindGameObjectWithTag ("gameover");
			Text gameovertextco = gameovertext.GetComponent<Text> ();


			GameObject timetext = GameObject.FindGameObjectWithTag ("time");
			Text timetextco = timetext.GetComponent<Text> ();
			Debug.Log ("Time: " + time);
			timetextco.text = "Time: " + time;
			scoretextco.text = "Score: " + score;

			if(score == 500)
			{
				gameover = true;
				gameovertextco.text = "Congrats, Level-1.2 Complete, Press F1 For Next Level";

			}
			if(score<500 && time<=0)
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
		Application.LoadLevel("level-1.2");
	}

}

















