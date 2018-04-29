using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
	//LevelControl control;
	public Button mainMenu;
	// Use this for initialization
	void Start () {
		mainMenu.onClick.AddListener (Main);
		//control = GameObject.Find ("Play").GetComponent<LevelControl> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Main(){
		if (GameObject.Find ("Play").GetComponent<LevelControl> ().paused) {
			PlayerPrefs.SetInt("Quald", GameObject.Find("Quald").GetComponent<Quald>().quald);
			PlayerPrefs.SetInt("Level", GameObject.Find("Play").GetComponent<LevelControl>().level);
			PlayerPrefs.SetInt ("THpM", GameObject.FindGameObjectWithTag ("TurretHPUp").GetComponent<TurretHpUpgrade> ().turretHpMax);
			PlayerPrefs.SetInt ("TDmg", GameObject.FindGameObjectWithTag ("TurretDmgUp").GetComponent<TurretDmgUpgrade> ().increment);

			SceneManager.LoadScene ("StartMenu");
		}
	}
}
