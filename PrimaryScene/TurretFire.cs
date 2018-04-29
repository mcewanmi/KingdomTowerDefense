using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TurretFire : MonoBehaviour {
	public GameObject arrow;
	//bool pause;
	Vector2 range;
	public int damage;
	public GameObject chosenSkele;
	//int id;


	// Use this for initialization
	void Start () {
		//Vector2 pt;
		range.x = 5f;//12.54f;
		range.y = -2.55f;//-3.4f;



	//	id = 0;

		StartCoroutine (Ready ());

	}
	
	// Update is called once per frame
	void Update () {
		damage = GameObject.FindGameObjectWithTag("TurretDmgUp").GetComponent<TurretDmgUpgrade>().turretDmg;
		//Debug.Log ("turretfire: " + damage);
	}

	IEnumerator Ready(){
		while (true) {
			yield return new WaitForSeconds (2);
			StartCoroutine(Aim ());
		}
	
	}


	void Fire(){
		arrow = Instantiate (Resources.Load ("TurretArrow")) as GameObject;
		arrow.transform.parent = GameObject.FindGameObjectWithTag("Bow").transform;
		//id++;
		//chosenSkele.GetComponent<SkeletonMovement> ().id = id;
		arrow.GetComponent<ArrowMovement> ().closestSkele = chosenSkele;

		Vector2 pos;// = new Vector2();
		pos.x = -12.54f;
		pos.y = -2.55f;//-3.4f;
		arrow.transform.position = pos;
		//Debug.Log (arrow.transform.position.x);
	}

	IEnumerator Aim(){
		//int i = 0;

		yield return new WaitForSeconds (0.1f);
		GameObject[] skeles = GameObject.FindGameObjectsWithTag ("Skeleton");
		if (skeles.Length > 0){
		GameObject skele = GameObject.FindGameObjectsWithTag("Skeleton").OrderBy(go => Vector3.Distance(go.transform.position, transform.position)).FirstOrDefault();
		//foreach (GameObject obj in skeles){
		
		//	if (obj.transform.position.x < range.x && GameObject.FindGameObjectWithTag("Play").GetComponent<LevelControl>().playBool) {
		if (skele.transform.position.x < range.x && !GameObject.FindGameObjectWithTag("Play").GetComponent<LevelControl>().paused) {
			chosenSkele = skele;
			Debug.Log ("FIRE");
			Fire ();
			//break;
			}
		}
		StopCoroutine ("Aim");
	}
}