using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyText : MonoBehaviour {
	//Vector2 camPos;
	public Text myText;
	//GameObject cam;
	// Use this for initialization


	void Start () {
		myText.text = "Defend the Turret!" + "\n" + "Your HP: " + GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().healthPlayer;	
	//	cam = GameObject.FindGameObjectWithTag ("MainCamera");

	
	}
	
	// Update is called once per frame
	void Update () {

		//	camPos.x = cam.transform.position.x - 6.8f;
		///	camPos.y = gameObject.transform.position.y;
		//	gameObject.transform.position = camPos;


	}
}
