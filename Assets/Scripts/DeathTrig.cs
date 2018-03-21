using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTrig : MonoBehaviour 
{
	

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == "Enemy") 
		{
			gameObject.GetComponent<Animator> ().SetTrigger ("DeathTrig");
			Destroy (gameObject, 2);
		}
	}
}
