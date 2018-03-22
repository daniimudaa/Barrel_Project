using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRange : MonoBehaviour 
{
	public GameObject enemy;
	private EnemyManager enemyScript;

	void Start () 
	{
		enemyScript = enemy.GetComponent<EnemyManager> ();
	}

	void OnTriggerEnter (Collider colli)
	{
		if (colli.tag == "Player" && !enemyScript.dead) 
		{
			enemyScript.attack = true;
			enemyScript.agent.speed = enemyScript.agent.speed + 5;
		}
	}

	void OnTriggerStay (Collider col)
	{
		if (col.tag == "Player") 
		{

			enemyScript.attack = true;
			enemyScript.agent.destination = enemyScript.playerPos.transform.position;
		}
	}

	void OnTriggerExit (Collider coll)
	{
		if (coll.tag == "Player" && !enemyScript.dead) 
		{
			enemyScript.attack = false;
			enemyScript.agent.speed = enemyScript.agent.speed + -5;
		}
	}
}
