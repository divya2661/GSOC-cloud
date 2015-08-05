using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class score_plus2 : MonoBehaviour {

	public GameObject explosion_obj;


	void OnMouseDown()
	{
		Destroy(this.gameObject);
		Instantiate(explosion_obj , transform.position ,transform.rotation);
		if (GameController2.instace.veg == 1 && GameController2.instace.animal == 0)
		{
			GameController2.instace.Score += 100;
		} 
		else 
		{
			GameController2.instace.Score -= 100;
		}


	}



}
