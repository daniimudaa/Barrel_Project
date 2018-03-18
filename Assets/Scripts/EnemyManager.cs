using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyManager : MonoBehaviour 
{

	public Transform[] points;
	private int destPoint = 0;
	private NavMeshAgent agent;

	public bool attack; //* my addition 
	public GameObject playerPos;

	void Start () 
	{
		attack = false; //* my addition 

		agent = GetComponent<NavMeshAgent>();

		// Disabling auto-braking allows for continuous movement
		// between points (ie, the agent doesn't slow down as it
		// approaches a destination point).
		agent.autoBraking = false;

		GotoNextPoint();
	}


	void GotoNextPoint() 
	{
		// Returns if no points have been set up
		if (points.Length == 0)
			return;

		// Set the agent to go to the currently selected destination.
		//agent.destination = points[destPoint].position; //original script

		// Choose the next point in the array as the destination,
		// cycling to the start if necessary.
		//destPoint = (destPoint + 1) % points.Length; //original script

		//* my addition 
		if (!attack)
		{
			agent.destination = points[destPoint].position;
			destPoint = (Random.Range (0, 14)) % points.Length;
		}

	}

	void Update () 
	{
		// Choose the next destination point when the agent gets
		// close to the current one.
		if (!agent.pathPending && agent.remainingDistance < 0.5f)
			GotoNextPoint();
	}

	//* my addition
	void OnTriggerStay (Collider col)
	{
		if (col.tag == "Player") 
		{
			attack = true;
			agent.destination = playerPos.transform.position;
		}
	}

	void OnTriggerExit (Collider coll)
	{
		if (coll.tag == "Player") 
		{
			attack = false;
		}
	}

}

//* NOT MINE - script found and used from the Unity documentation
//* https://docs.unity3d.com/Manual/nav-AgentPatrol.html 
