using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_ : MonoBehaviour 
{
	//store enemy lists
	//if 0 then win the game
	public List<GameObject> enemyList;

	////* UI win, loose & pause panels live here
	//public GameObject deathPanel;
	//public GameObject winPanel;
	//public GameObject pausePanel;

	public bool paused = false;

	private Barrel barScript;
	public  GameObject barrel;
	public GameObject[] enemies;

	void Start () 
	{
		barScript = barrel.GetComponent<Barrel> ();
		enemyList = new List <GameObject> ();
		enemies = GameObject.FindGameObjectsWithTag ("Enemy");

		enemyList.AddRange (enemies);
	}
	
	void Update () 
	{
		if (barScript.playaIsDead) 
		{
			Time.timeScale = 0;
			print ("You dead boi");
			//deathPanel.SetActive (true);
		}

		if (Input.GetKeyDown (KeyCode.Escape)) 
		{
			//*game un-paused
			if (paused) 
			{
				//pausePanel.SetActive (false);
				Time.timeScale = 1;
				print ("UNPAUSED");
				paused = false;
			}

			//*game paused
			else 
			{
				//pausePanel.SetActive (true);
				Time.timeScale = 0;
				print ("PAUSED!");
				paused = true;
			}
		}
			
		if (enemyList.Count == 0)
		{
			//Time.timeScale = 0;
			//winPanel.SetActive (true);
		}

	}
}
