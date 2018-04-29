using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AddBow : MonoBehaviour {
	public Button bow;
	public Vector3 mousePos;
	bool move;
	bool addOnce;
	public GameObject newBow;
	LevelControl betweenLevels;

	Quald qualdScript;
	//int val;

	// Use this for initialization
	void Start () {
		//val = 0;
		move = false;
		addOnce = false;

		qualdScript = GameObject.Find ("Quald").GetComponent<Quald> ();

		bow.onClick.AddListener (addBow);

		betweenLevels = GameObject.FindGameObjectWithTag ("Play").GetComponent<LevelControl> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (move) {
			mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			mousePos.z = 0;
			if (addOnce) {
				//Debug.Log ("x: "+mousePos.x + "y: " + mousePos.y);
				newBow = Instantiate (Resources.Load ("TurretArrowSpawn")) as GameObject;
				newBow.layer = 1;
				addOnce = false;
			}
			newBow.transform.position = mousePos;

			if (Input.GetMouseButtonDown (0) && (mousePos.x >= -14.75f && mousePos.x <= -12.28f) && (mousePos.y >= -5.65f && mousePos.y <= -1.54f)) {
				newBow.transform.position = mousePos;
				move = false;
				Debug.Log ("added bow dmg: " + newBow.GetComponent<TurretFire>().damage);
			}
		
		
		}
	}

	void addBow(){
		//mousePos.x = Input.mousePosition.x;
		//mousePos.y = Input.mousePosition.y;
		if (qualdScript.quald >= 1000 && !betweenLevels.levelStart) {
			move = true;
			addOnce = true;
			qualdScript.quald -= 1000;
		}
	}

}
