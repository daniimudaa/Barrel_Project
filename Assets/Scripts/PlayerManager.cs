using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerManager : MonoBehaviour 
{
//	public GameObject UltUI;
//	public GameObject UltUIParticles;
//	public GameObject UltRange;
//	public GameObject sprintUI;
//	public GameObject sprintUIParticles;

	public GameObject ultAttakTrig;

	public FirstPersonController fpcScript;

	public bool ult;
	public bool ultCooldown;
	public bool enemy;
	public bool sprint;
	public bool sprintCooldown;

	private Animator anim;



	void Start () 
	{
		fpcScript = GetComponent<FirstPersonController>();
		anim = GetComponent<Animator> ();

		ult = false;
		ultCooldown = false;
		enemy = false;
		Invoke("ULTisTrue", 20);
		Invoke("sprintisTrue", 8);
	}

	void Update () 
	{
		//print (ult); //testing ult true/false variables
		//print (sprint); //testing sprint true/false variables

		if (ult) 
		{
			//show ult range visuals & trigger zone
			//UltRange.SetActive(true);

			//activate ult UI
			//UltUI.SetActive(true);

			//ult is active sound

			//ult is active particles (to show attention to it)
			//UltUIParticles.SetActive(true);
		}

		if (!ult) 
		{
			//hide ult range visuals & trigger zone
			//UltRange.SetActive(false);

			//de-activate ult UI
			//UltUI.SetActive(false);
		}

		//player ult attack
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

			if (!ult) 
			{
				//play no ult sound
				//print ("ULT NOT READY");
			}

			ULTisCool();
		}





		if (sprint) 
		{
			//activate ult UI
			//sprintUI.SetActive(true);

			//sprint is active sound

			//sprint is active particles (to show attention to it)
			//sprintUIParticles.SetActive(true);
		}

		if (!sprint) 
		{
			//de-activate ult UI
			//sprintUI.SetActive(false);
		}

		//player ult attack
		if (Input.GetKeyDown (KeyCode.LeftShift)) 
		{
			sprintCooldown = false;

			//ult attack
			if (sprint) 
			{
				//play ult sound
				sprintActivate ();
				sprint = false;
				sprintCooldown = true;
			}

			if (!sprint) 
			{
				//play no ult sound
				//print ("Sprint NOT READY");
			}

			sprintisCool();
		}
	}

	void ULTisTrue()
	{
		ult = true;
		UltActivate ();
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
		//activate UI range
		//activate ULT sound
		//print ("ULT is activated");
	}

	void UltAttack()
	{
		if (enemy) 
		{
			//activate animation
			anim.SetTrigger("UltAttack");
			ultAttakTrig.SetActive(true);
			//print ("ULT ATTACKING");
		}
	}




	void sprintisTrue()
	{
		sprint = true;
		return;
	}

	void slowDown()
	{
		fpcScript.m_RunSpeed = (5);
	}

	void sprintisCool()
	{
		if (sprintCooldown) 
		{
			Invoke ("slowDown", 0.5f);
			Invoke("sprintisTrue", 8);
		}
	}

	void sprintActivate()
	{
		fpcScript.m_RunSpeed = (15);
	}



	void OnTriggerEnter (Collider collider)
	{
		if (collider.tag == "Enemy") 
		{
			enemy = true;
			//get ULT range and change colour to green
		}
	}

	void OnTriggerExit (Collider collider2)
	{
		if (collider2.tag == "Enemy") 
		{
			enemy = false;
			//get ULT range and change colour to red
		}
	}
}
