using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Game : MonoBehaviour 
{
	public Texture pose1;
	public Texture pose2;
	public Texture pose3;
	public Texture pose4;
	public Texture pose5;
	public Texture pose6;

	public List<int> poses;
	private PlayerOne playerOne;
	private PlayerOne playerTwo;
	private SpugeAI ai;

	void Start()
	{
		poses = new List<int> ();
		playerOne = GameObject.Find ("PlayerOne").GetComponent<PlayerOne> ();

		if (GameObject.Find("PlayerTwo").GetComponent<PlayerOne>() != null)
			playerTwo = GameObject.Find("PlayerTwo").GetComponent<PlayerOne>();
		else
			ai = GameObject.Find("PlayerTwo").GetComponent<SpugeAI>();
	}

	void Update()
	{
		UpdateList ();
		PlayerOne ();

		if (playerTwo != null)
			PlayerTwo ();
		else
			AI();
	}

	void OnGUI()
	{
		for (int i = 0; i < poses.Count; ++i)
		{
			GUI.DrawTexture(new Rect(10 + (pose1.width * i + 10),0, pose1.width, pose1.height), GetPose(poses[i]));
		}
	}

	private Texture GetPose(int numero)
	{
		switch (numero)
		{
		case 0: return pose1;
		case 1: return pose2;
		case 2: return pose3;
		case 3: return pose4;
		case 4: return pose5;
		case 5: return pose6;
		default: return pose1;
		}
	}
	private void UpdateList()
	{
		if (poses.Count <= 0)
		{
			//for (int i = 0; i < GameObject.Find("Tietoa").GetComponent<Singleton>().difficulty; ++i)
			//	poses.Add(Random.Range(0,5));
			for (int i = 0; i < 3; ++i)
				poses.Add(Random.Range(0,5));
		}
	}
	private void PlayerOne()
	{
		for (int i = 0; i < playerOne.Poses.Count; ++i)
		{
			if (playerOne.Poses[i] != poses[i])
			{
				playerOne.Poses.Clear();
				break;
			}
			else
				playerOne.combo++;
		}

		if (playerOne.Poses.Count >= poses.Count)
		{
			poses.Clear();
			UpdateList();

			if (playerTwo != null)
				playerTwo.hp--;
			else
				ai.hp--;
		}

		if (playerOne.hp <= 0)
			StartCoroutine("End");
	}
	private void PlayerTwo()
	{
		for (int i = 0; i < playerTwo.Poses.Count; ++i)
		{
			if (playerTwo.Poses[i] != poses[i])
			{
				playerTwo.Poses.Clear();
				break;
			}
			else
				playerTwo.combo++;
		}
		
		if (playerTwo.Poses.Count >= poses.Count)
		{
			poses.Clear();
			UpdateList();
			playerOne.hp--;
		}

		if (playerTwo.hp <= 0)
			StartCoroutine("End");
	}
	private void AI()
	{
		for (int i = 0; i < ai.poses.Count; ++i)
		{
			if (ai.poses[i] != poses[i])
			{
				ai.poses.Clear();
				break;
			}
			else
				ai.combo++;
		}
		
		if (ai.poses.Count >= poses.Count)
		{
			poses.Clear();
			UpdateList();
			playerOne.hp--;
		}

		if (ai.hp <= 0)
			StartCoroutine("End");
	}

 	IEnumerator End()
	{
		yield return new WaitForSeconds (5);
		Application.LoadLevel (1);
	}
}
