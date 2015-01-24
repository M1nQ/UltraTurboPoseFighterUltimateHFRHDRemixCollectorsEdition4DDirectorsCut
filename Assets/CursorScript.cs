using UnityEngine;
using System.Collections;

public class CursorScript : MonoBehaviour {
    public KeyCode left;
    public KeyCode right;
    public KeyCode select;
    public KeyCode back;
    float yPosition;
    public float xPosition;
    public int selected;
    public bool isSelecting;
    public bool againstComputer;
    public int currentSelection;
    CursorScript otherPlayerScript;
    public GameObject otherPlayer;
	// Use this for initialization
	void Start () {
        currentSelection = 1;
        selected = -1;
        isSelecting = true;
        if(!againstComputer)
            otherPlayerScript = otherPlayer.GetComponent<CursorScript>();
	}
	
	// Update is called once per frame
	void Update () {
        if (isSelecting == true)
        {
            if (Input.GetKeyDown(left))
            {
                currentSelection -= 1;
            }
            if (Input.GetKeyDown(right))
            {
                currentSelection += 1;
            }
            if (Input.GetKeyDown(select))
            {
                if(againstComputer)
                {
                    selected = currentSelection;
                    isSelecting = false;
                }
                if (otherPlayerScript.isSelecting == false && otherPlayerScript.selected == currentSelection)
                {

                }
                else
                {
                    selected = currentSelection;
                    isSelecting = false;
                }
            }
        }
        else
        {
            if(Input.GetKeyDown(back))
            {
                isSelecting = true;
                selected = -1;
            }
        }
        if (currentSelection < 1)
            currentSelection = 5;
        else if (currentSelection > 5)
            currentSelection = 1;
        if (isSelecting)
        {
            yPosition = 1.3f;
        }
        else
            yPosition = 1;

        transform.position = new Vector3(-9 + 3*currentSelection+xPosition, yPosition, 0);
	}
}
