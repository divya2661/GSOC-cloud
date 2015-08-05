using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class score_plus1 : MonoBehaviour {

	public GameObject explosion_obj;


	void OnMouseDown()
	{
		Destroy(this.gameObject);
		Instantiate(explosion_obj , transform.position ,transform.rotation);
		GameController1.instace.Score += 100;

	}



}
