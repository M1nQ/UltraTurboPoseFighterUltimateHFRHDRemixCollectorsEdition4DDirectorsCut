using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpugeAI : MonoBehaviour 
{
	public int hp;
    Game game;
    float quessInterval;
    public float minQuess;
    public float maxQuess;
    int quess;
    public float correctPercent;
    float currentTime;

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

	[HideInInspector]
	public List<int> poses;
	[HideInInspector]
	public int combo;

	// Use this for initialization
	void Start () {
        game = GameObject.Find("Peli").GetComponent<Game>();
        quessInterval = Random.Range(minQuess, maxQuess);
        quess = 0;
	}
	
	// Update is called once per frame
	void Update () {
        currentTime += Time.deltaTime;
        if(currentTime >= quessInterval)
        {
            if(correctPercent > Random.Range(0.0f,100.0f))
            {
                if (game.poses[poses.Count] == 0)
                {
                    quess = 0;
                }
                else if (game.poses[poses.Count] == 1)
                {
                    quess = 1;
                }
                else if (game.poses[poses.Count] == 2)
                {
                    quess = 2;
                }
                else if (game.poses[poses.Count] == 3)
                {
                    quess = 3;
                }
                else if (game.poses[poses.Count] == 4)
                {
                    quess = 4;
                }
                else if (game.poses[poses.Count] == 5)
                {
                    quess = 5;
                }
            }
            else
            {
                quess = Random.Range(0,6);
                while(quess == game.poses[poses.Count])
                {
                    quess = Random.Range(0, 6);
                }
            }

            if (quess == 0)
            {
                GetComponent<Animator>().Play("Bose1");
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().PlayOneShot(GetRandomHuuto(Random.Range(0, 10)));
                poses.Add(0);
            }
            else if (quess == 1)
            {
                GetComponent<Animator>().Play("Bose2");
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().PlayOneShot(GetRandomHuuto(Random.Range(0, 10)));
                poses.Add(1);
            }
            else if (quess == 2)
            {
                GetComponent<Animator>().Play("Bose3");
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().PlayOneShot(GetRandomHuuto(Random.Range(0, 10)));
                poses.Add(2);
            }
            else if (quess == 3)
            {
                GetComponent<Animator>().Play("Bose4");
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().PlayOneShot(GetRandomHuuto(Random.Range(0, 10)));
                poses.Add(3);
            }
            else if (quess == 4)
            {
                GetComponent<Animator>().Play("Bose5");
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().PlayOneShot(GetRandomHuuto(Random.Range(0, 10)));
                poses.Add(4);
            }
            else if (quess == 5)
            {
                GetComponent<Animator>().Play("Bose6");
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().PlayOneShot(GetRandomHuuto(Random.Range(0, 10)));
                poses.Add(5);
            }

            quessInterval = Random.Range(minQuess, maxQuess);
            currentTime = 0;
        }
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

    private RuntimeAnimatorController GetAnimations(string nimi)
    {
        if (nimi == "jussi") return jussi;
        else if (nimi == "samuli") return samuli;
        else if (nimi == "miikka") return miikka;
        else if (nimi == "toni") return toni;
        else return nanne;
    }
    private Sprite GetDefaultPose(string nimi)
    {
        if (nimi == "jussi") return defaultJussi;
        else if (nimi == "samuli") return defaultSamuli;
        else if (nimi == "miikka") return defaultMiikka;
        else if (nimi == "toni") return defaultToni;
        else return defaultNanne;
    }
}
