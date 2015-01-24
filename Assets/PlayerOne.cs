using UnityEngine;
using System.Collections;

public class PlayerOne : MonoBehaviour 
{
	public KeyCode pose1;
	public KeyCode pose2;
	public KeyCode pose3;
	public KeyCode pose4;
	public KeyCode pose5;
	public KeyCode pose6;

	public AudioClip huuto1;
	public AudioClip huuto2;
	public AudioClip huuto3;
	public AudioClip huuto4;
	public AudioClip huuto5;
	public AudioClip huuto6;
	public AudioClip huuto7;
	public AudioClip huuto8;
	public AudioClip huuto9;
	public AudioClip huuto10;
	public AudioClip huuto11;
	public AudioClip Häviö;
	public AudioClip Voitto;

	[HideInInspector]
	public Sprite defaultPose;
	[HideInInspector]
	public RuntimeAnimatorController animations;

	void Update()
	{
		if (Input.GetKeyDown(pose1))
		    GetComponent<Animator>().Play("Bose1");
		else if (Input.GetKeyDown(pose2))
			GetComponent<Animator>().Play("Bose2");
		else if (Input.GetKeyDown(pose3))
			GetComponent<Animator>().Play("Bose3");
		else if (Input.GetKeyDown(pose4))
			GetComponent<Animator>().Play("Bose4");
		else if (Input.GetKeyDown(pose5))
			GetComponent<Animator>().Play("Bose5");
		else if (Input.GetKeyDown(pose6))
			GetComponent<Animator>().Play("Bose6");
	}

	private AudioClip GetRandomHuuto(int number)
	{
		switch (number)
		{
		case 0: return huuto1;
		case 1: return huuto2;
		case 2: return huuto3;
		case 3: return huuto4;
		case 4: return huuto5;
		case 5: return huuto6;
		case 6: return huuto7;
		case 7: return huuto8;
		case 8: return huuto9;
		case 9: return huuto10;
		case 10: return huuto11;
		default: return huuto1;
		}
	}
}