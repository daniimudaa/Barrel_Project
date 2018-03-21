using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTrig : MonoBehaviour 
{
	//ult attack death for enemies in the path

	void OnTriggerEnter (Collider other)
	{
		other.GetComponent<EnemyManager> ().Die();
	}
}
