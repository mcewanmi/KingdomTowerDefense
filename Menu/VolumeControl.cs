using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour {
    public bool mute;
    public Button vol;
	// Use this for initialization
	void Start () {
        mute = false;
        vol.onClick.AddListener(Mute);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Mute()
    {
		AudioListener.pause = !AudioListener.pause;

    }



}
