using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public enum GameState {MENU, INGAME};

public class GameManager_ : MonoBehaviour 
{
	//store enemy lists
	//if 0 then win the game
	public List<GameObject> enemyList = new List<GameObject>();

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

	public AudioClip dead;
	public AudioClip win;
	public AudioSource audioSource;

	void Start () 
	{
		gameState = GameState.INGAME;

		Time.timeScale = 1;

		mouseActivate = false;

		barScript = barrel.GetComponent<Barrel> ();


		foreach (GameObject enemy in enemyList) 
		{
			enemyList.Add (enemy);
		}
	}
	
	void Update () 
	{
		//if in game then lock cursor & hide
		if (gameState == GameState.INGAME) 
		{
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		}

		//if in menu screen unlock cursor & show
		if (gameState == GameState.MENU)
		{
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
		}

		//if the player dies then call death variables
		if (barScript.playaIsDead) 
		{
			//pause time based movement
			Time.timeScale = 0;

			//turn mouse lock off, mouse visibility on
			gameState = GameState.MENU;

			//set active death panel & play death sound
			print ("You dead boi");
			deathPanel.SetActive (true);
			audioSource.PlayOneShot (dead);
		}

		//if press "ESC" button then pause game
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

		//if enemy count in list is less than 0 (all enemies died) then do win conditions
		if (enemyList.Count == 0)
		{
			gameState = GameState.MENU;
			Time.timeScale = 0;
			winPanel.SetActive (true);
			//couldnt figure out how to play win audio only once (since this is in update)
		}
	}
}
