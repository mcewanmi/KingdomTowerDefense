using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {
    Vector3 startRot;
    Animator walk, attack, idle;
	public bool attacking;
	bool wallLeft, wallRight, walking;
	bool atk, atkGo;
	public int healthPlayer;

	Transform startScale;


	// Use this for initialization
	void Start () {
		//startRot = transform.rotation;
        walk = GetComponent<Animator>();
		walk.SetBool ("Walk", false);
		attack = GetComponent<Animator> ();
		attack.SetBool ("Attack", false);
		idle = GetComponent<Animator> ();
		idle.SetBool ("Idle", true);
		attacking = false;
		walking = false;
		wallLeft=false;
		wallRight = false;
	//	lose = false;
		healthPlayer = 5;

		startScale = gameObject.transform;

	}
	
	// Update is called once per frame
	void Update () {
		Vector2 pos= transform.position;
		Vector3 mousePos =Camera.main.ScreenToWorldPoint (Input.mousePosition);
			
		if (Input.GetMouseButton (0)) {
			
			attacking = false;
			walking = true;


			if (mousePos.x < transform.position.x && !wallLeft) {
				
				pos.x -= 0.07f;
				transform.position = pos; 

				/*
				//Turning
				if (transform.rotation == startRot) {
					Vector2 rota = transform.rotation;
					rota.x = startRot.x * -1;
					transform.rotation = rota;
				}*/

				//Turning Left
				if (transform.localScale.x > 0) {
					transform.localScale = new Vector3 (-transform.localScale.x, transform.localScale.y, transform.localScale.z);

				}


			} else if (mousePos.x > transform.position.x && !wallRight) {
				//walk.SetBool ("Walk", true);

				pos.x += 0.07f;
				transform.position = pos;


				//Turning Right
				if (transform.localScale.x < 0) {
					transform.localScale = new Vector3 (-transform.localScale.x, transform.localScale.y, transform.localScale.z);
				}
			}
		} else {
			//walk.SetBool ("Walk", false);
			walking = false;
			if (transform.localScale.x < 0) {
				transform.localScale = new Vector3 (-transform.localScale.x, transform.localScale.y, transform.localScale.z);

			}

		}

		if (!attacking && !walking) {
			idle.SetBool ("Idle", true);
			attack.SetBool ("Attack", false);
			walk.SetBool ("Walk", false);
			//Debug.Log ("testing1");
		}
            
		else if (attacking) {
			attack.SetBool ("Attack", true);
			walk.SetBool ("Walk", false);
			//walking = false;
			idle.SetBool ("Idle", false);
			//Debug.Log ("testing2");
		}

		else if (walking) {
			walk.SetBool ("Walk", true);
			idle.SetBool ("Idle", false);
			attack.SetBool ("Attack", false);
			//Debug.Log ("testing1");

		}

		//Text edi;
		if (healthPlayer <= 0) {
			//GameObject.Find ("Play").GetComponent<LevelControl> ().levelStart = false;
			//GameObject.Find ("Play").GetComponent<LevelControl> ().paused = true;
			//GameObject.Find ("Play").GetComponent<LevelControl> ().level--;
			//transform.position = startScale.position;

			//if (GameObject.FindGameObjectWithTag ("MobSpawn").transform.childCount > 0)
			//	for (int x=0; x<GameObject.FindGameObjectWithTag("MobSpawn").transform.childCount; x++)
			//		Destroy (GameObject.FindGameObjectWithTag ("MobSpawn").transform.GetChild (x).gameObject);					
				//foreach (GameObject child in GameObject.FindGameObjectWithTag("MobSpawn"))
			PlayerPrefs.SetInt("Quald", GameObject.Find("Quald").GetComponent<Quald>().quald);
			PlayerPrefs.SetInt("Level", GameObject.Find("Play").GetComponent<LevelControl>().level);
			PlayerPrefs.SetInt ("THpM", GameObject.FindGameObjectWithTag ("TurretHPUp").GetComponent<TurretHpUpgrade> ().turretHpMax);
			PlayerPrefs.SetInt ("TDmg", GameObject.FindGameObjectWithTag ("TurretDmgUp").GetComponent<TurretDmgUpgrade> ().increment);


			SceneManager.LoadScene ("StartMenu");

		}	

    }

	void OnTriggerEnter2D (Collider2D coll){
		
		if (coll.gameObject.tag == "Skeleton") {
			//if (!walking) {
				attacking = true;
				StartCoroutine (Damage (coll));

				
		}
		if (coll.gameObject.tag == "Turret")
			wallLeft = true;

		if (coll.gameObject.tag == "MobSpawn") {
			wallRight = true;
		}
			
	}

	void OnTriggerExit2D (Collider2D coll){
		if (coll.gameObject.tag == "Skeleton") {
			attacking = false;
			StopCoroutine ("Damage");
			Debug.Log ("skele died");
		}
		if (coll.gameObject.tag == "Turret")
			wallLeft = false;
		if (coll.gameObject.tag == "MobSpawn")
			wallRight = false;

	}

	IEnumerator Damage(Collider2D coll){
		//bool chk = true;
		bool atking = coll.gameObject.GetComponent<SkeletonMovement> ().attacking;
        bool foeLive = coll.gameObject.GetComponent<SkeletonMovement>().alive;
		/*
		int collHp = coll.gameObject.GetComponent<SkeletonMovement> ().health;
		while (attacking & collHp >0){
			yield return new WaitForSeconds(0.5f);
			if (attacking) {
//				Debug.Log (coll.gameObject.GetComponent<SkeletonMovement> ().health);
		
				try {
					if (collHp > 0) {
						coll.gameObject.GetComponent<SkeletonMovement> ().health--;
						collHp--;
						//chk = false;

					}
				} catch (MissingReferenceException e) {
					StopCoroutine ("Damage");
				}
			}
		}
		if (collHp == 0)
			StopCoroutine ("Damage");
		*/
		while (true){


			yield return new WaitForSeconds (1.5f);
            try
            {
                foeLive = coll.gameObject.GetComponent<SkeletonMovement>().alive;
            }
            catch(System.Exception e)
            {
                System.Exception ex = new System.Exception("Skeleton is Dead", e);
                foeLive = false;
            }
			if (foeLive)//coll.gameObject.transform != null)
				atking = coll.gameObject.GetComponent<SkeletonMovement> ().attacking;
			else
				atking = false;
			if (atking) {
				healthPlayer--;

			}
		 else
			break;
		}

	}
}
