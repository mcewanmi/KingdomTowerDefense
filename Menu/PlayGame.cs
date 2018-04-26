using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayGame : MonoBehaviour {
    public Button play;
	// Use this for initialization
	void Start () {
        play.onClick.AddListener(Play);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Play()
    {
        // SceneManager.LoadScene("Castle");
        SceneManager.LoadScene("TurretDefense");
    }


}
