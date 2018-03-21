using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour 
{
	public bool playaIsDead;

	void Start ()
	{
		playaIsDead = false;
	}
	
	void Update () 
	{
		gameObject.transform.Rotate (0, -5, 0);
	}

	void OnCollisionEnter (Collision colliding)
	{
		if (colliding.gameObject.tag == "Enemy") 
		{
			playaIsDead = true;
			//death conditions
			print ("YOU IS DEAD BOI");
		}
	}
}
