using UnityEngine;
using System.Collections;

public class CharacterSelectionScript : MonoBehaviour {
    public bool twoPlayer;
    CursorScript p1Selection = GameObject.Find("Cursor p1").GetComponent<CursorScript>();
    CursorScript p2Selection = GameObject.Find("Cursor p2").GetComponent<CursorScript>();
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {


	    if(p1Selection.isSelecting == false && p2Selection.isSelecting == false && p1Selection.againstComputer == false)
        {
            if (Input.GetKeyDown(p1Selection.select) || Input.GetKeyDown(p2Selection.select))
            {
                //go to posing
            }
        }
        else if(p1Selection.isSelecting == false && p1Selection.againstComputer == true)
        {
            if(Input.GetKeyDown(p1Selection.select))
            {
                //Go to posing
            }
        }
	}
}
