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
			//show ult range visuals & trigger zone
			UltRange.SetActive(true);

			//activate ult UI
			UltUI.SetActive(true);

			//ult is active sound

			//ult is active particles (to show attention to it)
			UltUIParticles.SetActive(true);
		}

		if (!ult) 
		{
			//hide ult range visuals & trigger zone
			UltRange.SetActive(false);

			//de-activate ult UI
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
			//get first person script
			//activate shift movement for 3 seconds
			//turn off
			//6 second cooldown
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
		//move player forward by range distance
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
