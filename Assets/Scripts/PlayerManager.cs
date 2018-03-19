using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour 
{
	public GameObject UltUI;
	public GameObject UltUIParticles;
	public GameObject UltRange;

	public bool ult;
	public bool ultCooldown;
	public bool enemy;

	void Start () 
	{
		ult = false;
		ultCooldown = false;
		enemy = false;
		Invoke("ULTisTrue", 20);
	}


	void Update () 
	{
		//print (ult); //testing ult true/false variables

		if (ult) 
		{
			//show ult range visuals
			UltRange.SetActive(true);

			//activate ult UI
			UltUI.SetActive(true);

			//ult is active sound

			//ult is active particles (to show attention to it)
			UltUIParticles.SetActive(true);
		}

		if (!ult) 
		{
			//show ult range visuals
			UltRange.SetActive(false);

			//activate ult UI
			UltUI.SetActive(false);
		}

		//player ult attack
		if (Input.GetKeyDown (KeyCode.Q)) 
		{
			ultCooldown = false;

			//ult attack
			if (ult && enemy) 
			{
				//play ult sound
				UltActivate ();
				ult = false;
				ultCooldown = true;
			}

			if (!ult) 
			{
				//play no ult sound
				//print ("ULT NOT READY");
			}

			ULTisCool();
		}

		//player dodge move
		if (Input.GetKeyDown (KeyCode.LeftShift)) 
		{
			//dodge defence
		}
	}

	void ULTisTrue()
	{
		ult = true;
		return;
	}

	void ULTisCool()
	{
		if (ultCooldown) 
		{
			Invoke("ULTisTrue", 20);
			//print ("COOLDOWN");
		}
	}

	void UltActivate()
	{
		//activate ult sound
		//activate animation
		//print ("ULT WORKS");
	}

	void OnTriggerEnter (Collider col)
	{
		if (col.tag == "Enemy") 
		{
			enemy = true;
		}
	}

	void OnTriggerExit (Collider coll)
	{
		if (coll.tag == "Enemy") 
		{
			enemy = false;
		}
	}
}
