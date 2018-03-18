using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour 
{

	void Start () 
	{
		
	}
	
	void Update () 
	{
		gameObject.transform.Rotate (0, -5, 0);
	}

	void OnTriggerEnter (Collider colliding)
	{
		if (colliding.tag == "Enemy") 
		{
			//death conditions
			print ("YOU IS DEAD BOI");
		}
	}
}
