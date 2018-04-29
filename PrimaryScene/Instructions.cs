using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Instructions : MonoBehaviour {
	GameObject howToPlay;
	public Button instruct;
	// Use this for initialization
	void Start () {
		howToPlay = GameObject.Find ("HowToPlay");
		instruct.onClick.AddListener (Instruct);
		howToPlay.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Instruct(){
		if (GameObject.Find("Play").GetComponent<LevelControl>().paused)
			howToPlay.SetActive (!howToPlay.activeInHierarchy);
	}

}
