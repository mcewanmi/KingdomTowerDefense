using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretDmgUpgrade : MonoBehaviour {
    public int turretDmg;
    float turretDmgBoost;
	public int increment;
	Quald qualdScript;
    //public Button UpTurretDmg;

    // Use this for initialization
    void Start () {
		qualdScript = GameObject.Find ("Quald").GetComponent<Quald>();//.quald;
        turretDmgBoost = 0.8f;

		if (PlayerPrefs.HasKey ("TDmg"))
			increment = PlayerPrefs.GetInt ("TDmg");
		else
			increment = 0;

		if (increment <=0)
			turretDmg = 1;
    }
	
	// Update is called once per frame
	void Update () {
		turretDmgBoost = 0.4f*increment;
		if (increment > 0)
		turretDmg = (int)(Mathf.Ceil (turretDmgBoost));
		//Debug.Log ("DMGDMG: " + turretDmg);
    }

	void OnMouseDown(){
		if (!GameObject.FindGameObjectWithTag ("Play").GetComponent<LevelControl> ().levelStart && qualdScript.quald >=100) {
			increment++;
			qualdScript.quald-=100;
		}

	}


}
