using UnityEngine;
using System.Collections;

public class Singleton : MonoBehaviour 
{
	[HideInInspector]
	public bool twoPlayers;
	[HideInInspector]
	public string playerOneChar;
	[HideInInspector]
	public string playerTwoChar;

	void Awake ()
	{
		GameObject.DontDestroyOnLoad (gameObject);

		//if (GameObject.Find("Singleton") != null)
		//	GameObject.Destroy(gameObject);

		//name = "Singleton";
	}
}
