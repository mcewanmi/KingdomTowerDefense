using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretDmgText : MonoBehaviour {
	public GameObject turretDmgText;


	// Use this for initialization
	void Start () {
		turretDmgText = GameObject.Find ("TurretDmg");
	}
	
	// Update is called once per frame
	void Update () {
		turretDmgText.GetComponent<Text>().text = "Turret Damage" + "\n" + GameObject.FindGameObjectWithTag("TurretDmgUp").GetComponent<TurretDmgUpgrade> ().turretDmg;
	}
}
