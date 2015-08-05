using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class score_subtract1_1 : MonoBehaviour {


	public GameObject explosion_bal;
	
	void OnMouseDown()
	{

		Destroy(this.gameObject);
		Instantiate(explosion_bal,transform.position,transform.rotation);
		GameController1_1.instace.Score -= 100;
		Debug.Log ("Score: " + GameController1_1.instace.Score);
	}


}
