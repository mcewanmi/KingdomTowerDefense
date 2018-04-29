using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonMovement : MonoBehaviour {
	bool walking;
	public bool attacking;
	bool idling;
	Animator walk;
	Animator attack;
	Animator idle;
	public int health;
	public bool alive;
	Vector2 leaveScreen;
	public int id;
	int hp;
	//BoxCollider2D fight;
	//bool pause;
	// Use this for initialization
	void Start () {
		Debug.Log ("Skeleton Active");
		walking = true;
		attacking = false;
		alive = true;
		walk = GetComponent<Animator> ();
		attack = GetComponent<Animator> ();
		idle = GetComponent<Animator> ();
		health = 2;
		//pause = GameObject.FindGameObjectWithTag ("Play").GetComponent<LevelControl> ().playBool;
	}
	void OnEnable(){
		//walking = true;
		//attacking = false;
		//alive = true;
		walk = GetComponent<Animator> ();
		attack = GetComponent<Animator> ();
		idle = GetComponent<Animator> ();
		health = hp;
	}
	// Update is called once per frame
	void Update () {
		//if (!pause)
		//	GetComponent<SkeletonMovement> ().enabled = false;
		hp = health;

		if (attacking) {
			attack.SetBool ("Attack", true);
		} else {
			attack.SetBool ("Attack", false);
		}

		if (walking) {
			walk.SetBool ("Walk", true);
			Vector2 pos = gameObject.transform.position;
			pos.x -= .05f;
			gameObject.transform.position = pos;
		} else {
			walk.SetBool ("Walk", false);

		}
		if (idling)
			idle.SetBool ("Idle", true);
		else
			idle.SetBool ("Idle", false);
    
	

		if (health == 0) {
			alive = false;
			attacking = false;
			//gameObject.GetComponent<Collider2D> ().enabled = false;
			GameObject.Find("Quald").GetComponent<Quald>().quald+=75;
			GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().attacking = false;
			GameObject.FindGameObjectWithTag ("MobSpawn").GetComponent<MobSpawner> ().skeleDead++;
			StopCoroutine ("Damage");
		
			Destroy (gameObject);
	//		}
			
		}
	
	}

	void OnTriggerEnter2D(Collider2D coll){
		//Vector2 pos;
		if (coll.gameObject.tag == "Player" || coll.gameObject.tag=="Turret") {
			walking = false;
			attacking = true;
			StartCoroutine (Damage (coll));
		}
		/*else if (coll.gameObject.tag == "Skeleton") {
			walking = false;
			idling = true;
		}*/
		if (coll.gameObject.tag == "arrow"){
			health-=coll.gameObject.GetComponent<ArrowMovement>().damage;
			Debug.Log ("hit " + health);
		}
	}

	void OnTriggerExit2D(Collider2D coll){
		if (coll.gameObject.tag == "Player" || coll.gameObject.tag=="Turret") {
			walking = true;
			attacking = false;
			StopCoroutine ("Damage");
		}
		/*
		 else if (coll.gameObject.tag == "Skeleton") {
			walking = true;
			idling = false;
		}*/
	}

	IEnumerator Damage(Collider2D coll){
		/*
		yield return new WaitForSeconds(1.0f);
		if (attacking)
			coll.gameObject.GetComponent<PlayerMovement> ().health -= 1;

		*/
		bool atking;
		try{
		atking = coll.gameObject.GetComponent<PlayerMovement> ().attacking;
		}
		catch (System.Exception e){
			atking = false;
		}
		
		while (atking && health > 0) {
			yield return new WaitForSeconds(1f);
			try{
				atking = coll.gameObject.GetComponent<PlayerMovement> ().attacking;
			}
			catch (System.Exception e){
				atking = false;
			}
			if (atking) {
				if (health > 0)
					health--;
			}
		}
	














		//The Skeletons are hurting the turret, but they die so fast














	}
}
