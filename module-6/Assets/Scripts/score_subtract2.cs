using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class score_subtract2 : MonoBehaviour {


	public GameObject explosion_bal;
	
	void OnMouseDown()
	{

		Destroy(this.gameObject);
		Instantiate(explosion_bal,transform.position,transform.rotation);
		if(GameController2.instace.veg==0 && GameController2.instace.animal==1)
		{
			GameController2.instace.Score += 100;
		}
		else
		{
			GameController2.instace.Score -= 100;
		}

	}

}
