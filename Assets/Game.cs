using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Game : MonoBehaviour 
{
	List<int> poses;

	private PlayerOne playerOne;
	private PlayerOne playerTwo;
	private SpugeAI ai;

	void Start()
	{
		playerOne = GameObject.Find ("PlayerOne").GetComponent<PlayerOne> ();

		if (GameObject.Find("PlayerTwo").GetComponent<PlayerOne>() != null)
			playerTwo = GameObject.Find("PlayerTwo").GetComponent<PlayerOne>();
		else
			ai = GameObject.Find("PlayerTwo").GetComponent<SpugeAI>();
	}

	void Update()
	{
	}
	private void UpdateList()
	{
		if (poses.Count <= 0)
		{
			for (int i = 0; i < GameObject.Find("Tietoa").GetComponent<Singleton>().difficulty; ++i)
				poses.Add(Random.Range(0,5));
		}
	}
	private void PlayerOne()
	{
	}
	private void PlayerTwo()
	{
	}
	private void AI()
	{
	}
}
