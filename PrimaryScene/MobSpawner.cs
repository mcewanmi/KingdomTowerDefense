using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobSpawner : MonoBehaviour {
	public GameObject skele;
	public GameObject skelHP;
	public int numSkels;
	public int skeleDead;
	public int skeleMax;
    bool paused;
	bool levelStarted;
    int level;

	/*
	// Use this for initialization
	void Start () {
		
		skeleDead = 0;
		numSkels = 0;

        paused = GameObject.Find("Play").GetComponent<LevelControl>().paused;
        //level = GameObject.Find("Play").GetComponent<LevelControl>().level;
		level = 1;

		Debug.Log ("Resumed");

	/*if (!GameObject.Find ("Play").GetComponent<LevelControl> ().levelStart) {
			numSkels = 0;
			Debug.Log ("numSkels reduced");
		}
	* /

		//Debug.Log ("level 2?");
		StartCoroutine(Spawn());
        //SpawnEnemy ();
        //numSkels++;
    }
	*/


	void OnEnable(){

		/*
		if (numSkels == null) {
			Debug.Log ("numSKels nulled");
			numSkels = 0;
			skeleDead = 0;
		}
		*/

		level = GameObject.Find("Play").GetComponent<LevelControl>().level;

		/*
		if (numSkels == skeleMax && skeleDead == numSkels) {
			skeleDead = 0;
			numSkels = 0;
		}*/

		paused = GameObject.Find("Play").GetComponent<LevelControl>().paused;
		levelStarted = GameObject.Find("Play").GetComponent<LevelControl>().levelStart;

//		Debug.Log ("SM: "+skeleMax);

		StartCoroutine(Spawn());

	}
	// Update is called once per frame
	void Update () {
		//skeleMax = GameObject.FindGameObjectWithTag ("Play").GetComponent<LevelControl> ().skelesMax;
	}

	void SpawnEnemy(){

		skele = Instantiate (Resources.Load ("EnemySkeleton")) as GameObject;
		//skelHP = Instantiate (Resources.Load ("SkeleHP")) as GameObject;
		skele.transform.parent = GameObject.FindGameObjectWithTag("MobSpawn").transform;
		//Vector2 textPos;
		//textPos.x = skele.transform.position.x;
		//textPos.y = skele.transform.position.y+5f;

		//skelHP.transform.position = textPos;
		Vector2 pos = new Vector2 ();

		pos.x = skele.transform.parent.transform.position.x -1.53241f;
		pos.y = skele.transform.parent.transform.position.y-0.45f;

		skele.transform.position = pos;


	}

	IEnumerator Spawn(){
//		Debug.Log ("skeleMax: " + skeleMax);
//		Debug.Log ("Coroutine Spawn Activated");
        while (true) {
			yield return new WaitForSeconds (4.0f);
			paused = GameObject.Find("Play").GetComponent<LevelControl>().paused;
			if (numSkels < skeleMax && !paused) {
				numSkels++;
				SpawnEnemy ();
			}
        }
	}


}
