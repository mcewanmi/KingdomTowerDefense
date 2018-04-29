using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkeletonHP : MonoBehaviour {
	public Text hpSkeleText;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		hpSkeleText.text = "HP: " + gameObject.GetComponentInParent<SkeletonMovement> ().health;
	}
}
