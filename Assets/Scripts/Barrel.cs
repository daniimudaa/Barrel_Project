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

	//rotate barrel
	void Update () 
	{
		gameObject.transform.Rotate (0, -5, 0);
	}

	//if barrel touches enemy barrel then player dies
	void OnCollisionEnter (Collision colliding)
	{
		if (colliding.gameObject.tag == "Enemy") 
		{
			playaIsDead = true;
		}
	}
}
