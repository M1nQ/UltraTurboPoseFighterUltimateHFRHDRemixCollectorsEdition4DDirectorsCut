using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Game : MonoBehaviour 
{
	public GameObject pose1;
	public GameObject pose2;
	public GameObject pose3;
	public GameObject pose4;
	public GameObject pose5;
	public GameObject pose6;

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
		UpdatePoses ();
		PlayerOne ();

		if (playerTwo != null)
			PlayerTwo ();
		else
			AI();
	}

	private GameObject GetPose(int numero)
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

			int temp = 0;
			poses.Add(Random.Range(0,6));

			for (int i = 1; i < 15; ++i)
			{
				do {
				temp = Random.Range(0,6);
				} while (temp == poses[i-1]);

				poses.Add(temp);
			}
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

			while (GameObject.FindWithTag("Pose") != null)
			{
				Destroy(GameObject.FindWithTag("Pose"));
			}
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

			while (GameObject.FindWithTag("Pose") != null)
			{
				Destroy(GameObject.FindWithTag("Pose"));
			}
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

			while (GameObject.FindWithTag("Pose") != null)
			{
				Destroy(GameObject.FindWithTag("Pose"));
			}
		}

		if (ai.hp <= 0)
			StartCoroutine("End");
	}
	private void UpdatePoses()
	{
		if (GameObject.FindWithTag("Pose") == null)
		{
			for (int i = 0; i < poses.Count; ++i)
			{
				GameObject.Instantiate(GetPose(poses[i]), new Vector3(-(poses.Count-1)/2 + i,3.3f,0), Quaternion.identity);
			}
		}
	}

 	IEnumerator End()
	{
		yield return new WaitForSeconds (5);
		Application.LoadLevel (0);
	}
}
