using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class ClosestEnemyHP : MonoBehaviour {
     public Text closest;
    // Use this for initialization
    GameObject skele;
    GameObject spawnerObj;
    int myHP;
	void Start () {

        spawnerObj = GameObject.FindGameObjectWithTag("MobSpawn");
    }
	
	// Update is called once per frame
	void Update () {
        myHP = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().healthPlayer;


		/*
		if (spawnerObj.transform.childCount > 0) {
			skele = GameObject.FindGameObjectsWithTag ("Skeleton").OrderBy (go => Vector3.Distance (go.transform.position, transform.position)).FirstOrDefault ();
			closest.text = "Closest Enemy HP: " + skele.GetComponent<SkeletonMovement> ().health + "\n" + "Your HP: " + myHP;
		} else {
			closest.text = "Your HP: " + myHP;
		}
		*/
		skele = GameObject.FindGameObjectsWithTag ("Skeleton").OrderBy (go => Vector3.Distance (go.transform.position, transform.position)).FirstOrDefault ();
		closest.text = "Closest Enemy HP: " + 
			((spawnerObj.transform.childCount > 0) ? skele.GetComponent<SkeletonMovement> ().health : '\0') +
			"\n" + "Your HP: " + myHP;



    }
}
