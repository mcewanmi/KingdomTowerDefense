using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TowerHP : MonoBehaviour {
    public int towerHP;
  //  bool takingDmg;
    bool skeleLive;
    public GameObject hpText;

	// Use this for initialization
	void Start () {
        towerHP = 10;
       // takingDmg = false;
        hpText = GameObject.Find("TurretHP");

	}
	
	// Update is called once per frame
	void Update () {
        if (!GameObject.FindGameObjectWithTag("Play").GetComponent<LevelControl>().levelStart)
            towerHP = GameObject.FindGameObjectWithTag("TurretHPUp").GetComponent<TurretHpUpgrade>().turretHpMax;

		hpText.GetComponent<Text> ().text = "Turret HP" + "\n"+ towerHP + "/" + GameObject.FindGameObjectWithTag ("TurretHPUp").GetComponent<TurretHpUpgrade> ().turretHpMax;


	
	
	}
    void OnTriggerEnter2D(Collider2D coll)
    {

        if (coll.gameObject.tag == "Skeleton")
        {
            StartCoroutine(Damage(coll));
        }
    }

    IEnumerator Damage(Collider2D coll)
    {
        while (true)
        {
            yield return new WaitForSeconds(1.5f);
            try
            {
                skeleLive = coll.gameObject.GetComponent<SkeletonMovement>().alive;
            }
            catch (System.Exception e)
            {
                System.Exception ex = new System.Exception("Skeleton is Dead", e);
                skeleLive = false;
            }
            if (skeleLive)
            {
                if (towerHP > 0)
                {
                    towerHP--;
                }
                else
                {
                  //  GameObject.FindGameObjectWithTag("Play").GetComponent<LevelControl>().paused = true;
                   // GameObject.FindGameObjectWithTag("Play").GetComponent<LevelControl>().levelStart = false;
					PlayerPrefs.SetInt("Quald", GameObject.Find("Quald").GetComponent<Quald>().quald);
					PlayerPrefs.SetInt("Level", GameObject.Find("Play").GetComponent<LevelControl>().level-1);
					PlayerPrefs.SetInt ("THpM", GameObject.FindGameObjectWithTag ("TurretHPUp").GetComponent<TurretHpUpgrade> ().turretHpMax);
					PlayerPrefs.SetInt ("TDmg", GameObject.FindGameObjectWithTag ("TurretDmgUp").GetComponent<TurretDmgUpgrade> ().increment);


					SceneManager.LoadScene ("StartMenu");

					//GameObject.Find("Defend").GetComponent<MyText>().myText.text = "You Lose!";
                }     
            }
        }
    }
}
