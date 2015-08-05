using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class score_subtract1 : MonoBehaviour {


	public GameObject explosion_bal;
	
	void OnMouseDown()
	{

		Destroy(this.gameObject);
		Instantiate(explosion_bal,transform.position,transform.rotation);
		GameController1.instace.Score -= 100;

	}

}
