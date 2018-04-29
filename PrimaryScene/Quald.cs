using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Quald : MonoBehaviour {
    public int quald;
    public Text qText;
	// Use this for initialization
	void Start () {

		if (PlayerPrefs.HasKey ("Quald"))
			quald = PlayerPrefs.GetInt ("Quald");
		else
        	quald = 0;

		if (quald < 0)
			quald = 0;
		
        qText.text = "Your Quald: " + quald;
	}
	
	// Update is called once per frame
	void Update () {
        //quald = GameObject.FindGameObjectWithTag("MobSpawn").GetComponent<MobSpawner>().skeleDead*75;
        qText.text = "Your Quald: " + quald;
    }
}
