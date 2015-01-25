using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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

	public AudioClip Ahuuto1;
	public AudioClip Ahuuto2;
	public AudioClip Ahuuto3;
	public AudioClip Ahuuto4;
	public AudioClip Ahuuto5;
	public AudioClip Ahuuto6;
	public AudioClip Ahuuto7;
	public AudioClip Ahuuto8;
	public AudioClip Ahuuto9;
	public AudioClip Ahuuto10;
	public AudioClip Ahuuto11;
	public AudioClip AHäviö;
	public AudioClip AVoitto;

	public RuntimeAnimatorController jussi;
	public RuntimeAnimatorController samuli;
	public RuntimeAnimatorController miikka;
	public RuntimeAnimatorController toni;
	public RuntimeAnimatorController nanne;

	public Sprite defaultJussi;
	public Sprite defaultSamuli;
	public Sprite defaultMiikka;
	public Sprite defaultToni;
	public Sprite defaultNanne;

    public GameObject flash;

	public int hp;

	[HideInInspector]
	public List<int> Poses;
	[HideInInspector]
	public int combo;
	[HideInInspector]
	public bool disabled;

	void Start()
	{
		disabled = false;
        flash = GameObject.Find("PlayerOneFlash");
        
		Poses = new List<int> ();
		//SetPlayer ();
	}

	void Update()
	{
		if (!disabled) {
						if (Input.GetKeyDown (pose1)) {
								GetComponent<Animator> ().Play ("Bose1");
								flash.GetComponent<Animator> ().Play ("Shadow1");
								flash.GetComponent<FlashScript> ().Flash ();
								GetComponent<AudioSource> ().Stop ();
								GetComponent<AudioSource> ().PlayOneShot (GetRandomHuuto (Random.Range (0, 11)));
								Poses.Add (0);
						} else if (Input.GetKeyDown (pose2)) {
								GetComponent<Animator> ().Play ("Bose2");
								flash.GetComponent<Animator> ().Play ("Shadow2");
								flash.GetComponent<FlashScript> ().Flash ();
								GetComponent<AudioSource> ().Stop ();
								GetComponent<AudioSource> ().PlayOneShot (GetRandomHuuto (Random.Range (0, 11)));
								Poses.Add (1);
						} else if (Input.GetKeyDown (pose3)) {
								GetComponent<Animator> ().Play ("Bose3");
								flash.GetComponent<Animator> ().Play ("Shadow3");
								flash.GetComponent<FlashScript> ().Flash ();
								GetComponent<AudioSource> ().Stop ();
								GetComponent<AudioSource> ().PlayOneShot (GetRandomHuuto (Random.Range (0, 11)));
								Poses.Add (2);
						} else if (Input.GetKeyDown (pose4)) {
								GetComponent<Animator> ().Play ("Bose4");
								flash.GetComponent<Animator> ().Play ("Shadow4");
								flash.GetComponent<FlashScript> ().Flash ();
								GetComponent<AudioSource> ().Stop ();
								GetComponent<AudioSource> ().PlayOneShot (GetRandomHuuto (Random.Range (0, 11)));
								Poses.Add (3);
						} else if (Input.GetKeyDown (pose5)) {
								GetComponent<Animator> ().Play ("Bose5");
								flash.GetComponent<Animator> ().Play ("Shadow5");
								flash.GetComponent<FlashScript> ().Flash ();
								GetComponent<AudioSource> ().Stop ();
								GetComponent<AudioSource> ().PlayOneShot (GetRandomHuuto (Random.Range (0, 11)));
								Poses.Add (4);
						} else if (Input.GetKeyDown (pose6)) {
								GetComponent<Animator> ().Play ("Bose6");
								flash.GetComponent<Animator> ().Play ("Shadow6");
								flash.GetComponent<FlashScript> ().Flash ();
								GetComponent<AudioSource> ().Stop ();
								GetComponent<AudioSource> ().PlayOneShot (GetRandomHuuto (Random.Range (0, 11)));
								Poses.Add (5);
						}
				}

		UpdateHP ();
	}

	private AudioClip GetRandomHuuto(int number)
	{
		if (name == "PlayerOne")
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
		else
		{
			switch (number)
			{
			case 0: return Ahuuto1;
			case 1: return Ahuuto2;
			case 2: return Ahuuto3;
			case 3: return Ahuuto4;
			case 4: return Ahuuto5;
			case 5: return Ahuuto6;
			case 6: return Ahuuto7;
			case 7: return Ahuuto8;
			case 8: return Ahuuto9;
			case 9: return Ahuuto10;
			case 10: return Ahuuto11;
			default: return Ahuuto1;
			}
		}
	}
	private void SetPlayer()
	{
		if (name == "PlayerOne")
			GetComponent<Animator>().runtimeAnimatorController = GetAnimations(GameObject.Find("Tietoa").GetComponent<Singleton>().playerOneChar);
		else
		{
			//if (GameObject.Find("Tietoa").GetComponent<Singleton>().twoPlayers)
			//	GetComponent<Animator>().runtimeAnimatorController = GetAnimations(GameObject.Find("Tietoa").GetComponent<Singleton>().playerTwoChar);
			//else
			//{
				gameObject.AddComponent<SpugeAI>();
				Destroy(this);
			//}
		}
	}
	private RuntimeAnimatorController GetAnimations(string nimi)
	{
		if (nimi == "jussi") return jussi;
		else if (nimi == "samuli") return samuli;
		else if (nimi == "miikka") return miikka;
		else if (nimi == "toni") return toni;
		else return nanne;
	}
	private Sprite GetDefaultPose (string nimi)
	{
		if (nimi == "jussi") return defaultJussi;
		else if (nimi == "samuli") return defaultSamuli;
		else if (nimi == "miikka") return defaultMiikka;
		else if (nimi == "toni") return defaultToni;
		else return defaultNanne;
	}
	private void UpdateHP()
	{
		transform.FindChild ("bar").transform.localScale = new Vector3 (hp / 3f, 0.5f, 1f);
	}
}