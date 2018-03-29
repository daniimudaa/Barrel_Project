using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public enum GameState {MENU, INGAME};

public class GameManager_ : MonoBehaviour 
{
	//store enemy lists
	//if 0 then win the game
	public List<GameObject> enemyList;

	////* UI win, loose & pause panels live here
	public GameObject deathPanel;
	public GameObject winPanel;
	public GameObject pausePanel;

	public bool paused = false;

	private Barrel barScript;
	public  GameObject barrel;
	//public GameObject[] enemies;

	public MouseLook mouseScript;
	public bool mouseActivate;

	public GameState gameState;

	void Start () 
	{
		gameState = GameState.INGAME;

		Time.timeScale = 1;

		mouseActivate = false;

		barScript = barrel.GetComponent<Barrel> ();
		enemyList = new List <GameObject> ();

//		enemies = GameObject.FindObjectsOfType<EnemyManager>(). ("Enemy");

		enemyList.AddRange (enemyList);
	}
	
	void Update () 
	{
		Debug.Log (gameState);

		if (gameState == GameState.INGAME) 
		{
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		}

		if (gameState == GameState.MENU)
		{
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
		}

		if (barScript.playaIsDead) 
		{
			Time.timeScale = 0;

			//turn mouse lock off, mouse visibility on
			gameState = GameState.MENU;

			print ("You dead boi");
			deathPanel.SetActive (true);
		}

		if (Input.GetKeyDown (KeyCode.Escape)) 
		{
			//*game un-paused
			if (paused) 
			{
				pausePanel.SetActive (false);
				Time.timeScale = 1;
				print ("UNPAUSED");
				paused = false;
				gameState = GameState.INGAME;
			}

			//*game paused
			else 
			{
				pausePanel.SetActive (true);
				Time.timeScale = 0;
				print ("PAUSED!");
				paused = true;
				gameState = GameState.MENU;
			}
		}
			
		if (enemyList.Count < 0)
		{
			gameState = GameState.MENU;
			Time.timeScale = 0;
			winPanel.SetActive (true);
		}

	}
}
