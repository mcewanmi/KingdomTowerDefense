using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelControl : MonoBehaviour {
	public int level;
	int skelesDead;
	int numSkeles;
	//public int skelesMax;

	//public bool playBool;
	public bool paused;

	//public bool begun;
	public bool levelStart;

	public Button playButton;
	//bool levelUp;
	GameObject spawnerObj;
	GameObject tFireObj;

	MobSpawner spawner;
	PlayerMovement mvmt;
	TurretFire tFire;

	Text play;

	// Use this for initialization
	void Start () {
		level = 1;

		levelStart = false;
		paused = true;

		spawner = GameObject.FindGameObjectWithTag ("MobSpawn").GetComponent<MobSpawner>();
		mvmt = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerMovement> ();
		tFire = GameObject.FindGameObjectWithTag ("Bow").GetComponent<TurretFire> ();
	
		spawner.enabled = false;
		mvmt.enabled = false;
		tFire.enabled = false;

		spawnerObj = GameObject.FindGameObjectWithTag ("MobSpawn");
		tFireObj = GameObject.FindGameObjectWithTag ("Bow");
	

		play = gameObject.GetComponentInChildren<Text> ();

		//skelesMax = 2;

		playButton.onClick.AddListener (Play);

	}
	
	// Update is called once per frame
	void Update () {


		skelesDead = spawner.skeleDead;
		numSkeles = spawner.numSkels;


		if (skelesDead == spawner.skeleMax) {
			//playBool = false;	//Pause Feature
			//paused = true;
			levelStart=false;
			paused = true;
			//begun = false;	//level Up
			//level++;
			//levelUp = true;
			spawner.numSkels = 0;
			spawner.skeleDead = 0;
		}

		//if (levelStart) {
			//playBool - if play button is on Pause, disable all. If level completed, disable all.
			if (paused) {//(!playBool){

				play.text = "Resume";
				spawner.enabled = false;
				//spawner.StopCoroutine ("Spawn");
				mvmt.enabled = false;
				GameObject.FindGameObjectWithTag ("Player").transform.GetComponent<Animator> ().enabled = false;

				tFire.enabled = false;

				if (spawnerObj.transform.childCount > 0)
					for (int x = 0; x < spawnerObj.transform.childCount; x++) {
						spawnerObj.transform.GetChild (x).GetComponent<SkeletonMovement> ().enabled = false;
						spawnerObj.transform.GetChild (x).transform.GetComponent<Animator> ().enabled = false;
					}

				if (tFireObj.transform.childCount > 0)
					for (int x = 0; x < tFireObj.transform.childCount; x++)
						tFireObj.transform.GetChild (x).GetComponent<ArrowMovement> ().enabled = false;
			} else {
				play.text = "Pause";
				spawner.enabled = true;
				mvmt.enabled = true;
				tFire.enabled = true;
            
				GameObject.FindGameObjectWithTag ("Player").transform.GetComponent<Animator> ().enabled = true;

			if (spawnerObj.transform.childCount > 0) {
				//Debug.Log ("multiple skeles detected");
				for (int x = 0; x < spawnerObj.transform.childCount; x++) {
					spawnerObj.transform.GetChild (x).GetComponent<SkeletonMovement> ().enabled = true;
					//Debug.Log ("skele "+x+" is active: "+spawnerObj.transform.GetChild (x).GetComponent<SkeletonMovement> ().isActiveAndEnabled);
					spawnerObj.transform.GetChild (x).transform.GetComponent<Animator> ().enabled = true;
				}
			}
			if (tFireObj.transform.childCount > 0){
					for (int x = 0; x < tFireObj.transform.childCount; x++)
						tFireObj.transform.GetChild (x).GetComponent<ArrowMovement> ().enabled = true;
				}

			}
		//}
		//else 
		if (!levelStart) //ed
			play.text = "Start Level: "+level;
      // else
        //    play.text = "Start Level: "+level;

	}


	void Play(){
        //if (!begun)
		if (levelStart)
			paused = !paused;
		else {
			levelStart = true;
			paused = false;


			if (level > 1){
				spawner.skeleMax = Random.Range (0, 2) + 2 * level;
			}
			else
				spawner.skeleMax = 2;

			level++;
		}
		//begun = true;
		//playBool = !playBool;

	}

}