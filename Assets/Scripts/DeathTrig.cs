using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTrig : MonoBehaviour 
{
	//ult attack condition - death for enemies inside the ult trigger zone
	void OnTriggerEnter (Collider other)
	{
		other.transform.root.gameObject.GetComponent<EnemyManager> ().Die();
	}
}
