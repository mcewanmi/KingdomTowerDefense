using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TurretHpUpgrade : MonoBehaviour {
	public int turretHP;
    public int turretHpMax;
	Quald qualdScript;

	// Use this for initialization
	void Start () {
		if (PlayerPrefs.HasKey ("THpM"))
			turretHpMax = PlayerPrefs.GetInt ("THpM");
		else
        	turretHpMax=10;
		
		qualdScript = GameObject.Find ("Quald").GetComponent<Quald> ();//.quald;
    }
	
	// Update is called once per frame
	void Update () {

	}

	void OnMouseDown(){
		if (qualdScript.quald >= 100 && !GameObject.FindGameObjectWithTag("Play").GetComponent<LevelControl>().levelStart) {
			turretHpMax += 2;
			//Debug.Log ("max: " + turretHpMax);
			qualdScript.quald-=100;
		}
	}
}
