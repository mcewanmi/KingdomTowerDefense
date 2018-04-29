using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ArrowMovement : MonoBehaviour {
	public GameObject closestSkele;
	GameObject prep;
	Vector2  pos;
	public int damage;
	//bool pause;
	public Vector2 lastPos;
	public bool skeleLives;

	// Use this for initialization
	void Start () {
		skeleLives = true;
		lastPos.x = (closestSkele.transform.position.x - GameObject.FindGameObjectWithTag ("Bow").transform.position.x);
		lastPos.y = (closestSkele.transform.position.y - GameObject.FindGameObjectWithTag ("Bow").transform.position.y);

		damage = GameObject.FindGameObjectWithTag ("Bow").GetComponent<TurretFire> ().damage;
		Debug.Log ("arrow damage: " + damage);
	}
	
	// Update is called once per frame
	void Update () {
		closestSkele = null;
		pos = gameObject.transform.position;


		pos.x += lastPos.x / 75f;
		pos.y += lastPos.y / 75f;

		gameObject.transform.position = pos;

		if (gameObject.transform.position.y == -3.03f)//-58f)
			Destroy (gameObject);

	}


	void OnTriggerEnter2D(Collider2D coll){

		/*
		if (coll.gameObject.tag == "Skeleton") {
			coll.gameObject.GetComponent<SkeletonMovement> ().health--;
			Destroy (gameObject);
		} 
		if (coll.gameObject.tag == "ground") {

			Destroy (gameObject);
		}
		*/
		if (coll.gameObject.tag != "Player")
			Destroy (gameObject);


	}
}
