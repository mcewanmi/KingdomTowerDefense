using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Exit : MonoBehaviour {
	public Button quit;
	// Use this for initialization
	void Start () {
		quit.onClick.AddListener (ExitGame);
	}
	
	// Update is called once per frame
	void ExitGame(){
		Application.Quit ();

	}
}
