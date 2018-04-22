using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerManager : MonoBehaviour 
{
	//UI vaariables
	public GameObject UltUI;
	public GameObject UltRange;
	public GameObject sprintUI;

	//trigger zone for ult attack
	public GameObject ultAttakTrig;
	public FirstPersonController fpcScript;

	//ult variables
	public bool ult;
	public bool ultCooldown;
	public bool enemy;
	public bool sprint;
	public bool sprintCooldown;

	//player animation component
	private Animator anim;



	void Start () 
	{
		//setting start variables & defining references
		fpcScript = GetComponent<FirstPersonController>();
		anim = GetComponent<Animator> ();

		ult = false;
		ultCooldown = false;
		enemy = false;

		//start Ult & Sprint functions after set time
		Invoke("ULTisTrue", 20);
		Invoke("sprintisTrue", 8);
	}

	void Update () 
	{
		//print (ult); //testing ult true/false variables
		//print (sprint); //testing sprint true/false variables

		//ult is active
		if (ult) 
		{
			UltRange.SetActive(true);
			UltUI.SetActive(true);
		}

		//ult is not active
		if (!ult) 
		{
			//hide ult range visuals & trigger zone
			UltRange.SetActive(false);

			//de-activate ult UI
			UltUI.SetActive(false);
		}

		//this is player ult attack ("Press Q")
		if (Input.GetKeyDown (KeyCode.Q)) 
		{
			ultCooldown = false;

			//ult attack
			if (ult && enemy) 
			{
				//play ult sound
				UltAttack();
				ult = false;
				ultCooldown = true;
			}

			//run ULT cool down function
			ULTisCool();
		}




		//if sprint is active
		if (sprint) 
		{
			sprintUI.SetActive(true);
		}

		//if sprint is not active
		if (!sprint) 
		{
			sprintUI.SetActive(false);
		}

		//this is player speed up (sprint)
		if (Input.GetKeyDown (KeyCode.LeftShift)) 
		{
			sprintCooldown = false;

			//sprint attack
			if (sprint) 
			{
				//play sprint sound
				sprintActivate ();
				sprint = false;
				sprintCooldown = true;
			}

			//run sprint cooldown function
			sprintisCool();
		}
	}

	//Ult true bool function
	void ULTisTrue()
	{
		ult = true;
		UltActivate ();
		return;
	}

	//Ult cool down
	void ULTisCool()
	{
		if (ultCooldown) 
		{
			//start ult is ready functions after x amount of time
			Invoke ("attackTrig", 0.2f);
			Invoke("ULTisTrue", 20);
			//print ("COOLDOWN");
		}
	}

	//meant to have sounds for ULT
	void UltActivate()
	{
		//activate ULT sound
		//print ("ULT is activated");
	}

	void UltAttack()
	{
		if (enemy) 
		{
			//play ult attack aimation (barrel roll)
			anim.SetTrigger("UltAttack");
			ultAttakTrig.SetActive(true);
			//print ("ULT ATTACKING");
		}
	}

	//turn off the atack trigger
	void attackTrig()
	{
		ultAttakTrig.SetActive(false);
	}


	//sprint bool function (true)
	void sprintisTrue()
	{
		sprint = true;
		return;
	}

	//returning back to previous speed after sprint burst
	void slowDown()
	{
		fpcScript.m_RunSpeed = (5);
	}

	//sprint cooldown period
	void sprintisCool()
	{
		if (sprintCooldown) 
		{
			Invoke ("slowDown", 0.5f);
			Invoke("sprintisTrue", 8);
		}
	}

	//increase speed for sprint
	void sprintActivate()
	{
		fpcScript.m_RunSpeed = (15);
	}


	//if and enemy enters the Ult trigger zone then change the trigger zone to be green allowing the ULT to be activated
	void OnTriggerEnter (Collider collider)
	{
		if (collider.tag == "Enemy") 
		{
			enemy = true;
			UltRange.GetComponent<MeshRenderer> ().material.color = Color.green;
		}
	}

	//if and enemy exits the Ult trigger zone then change the trigger zone to be red again allowing the ULT to be inactive untill enemy is inside the trigger zone
	void OnTriggerExit (Collider collider2)
	{
		if (collider2.tag == "Enemy") 
		{
			enemy = false;
			UltRange.GetComponent<MeshRenderer> ().material.color = Color.red;	
		}
	}
}
