using UnityEngine;
using System.Collections;

public class CursorScript : MonoBehaviour {
    public KeyCode left;
    public KeyCode right;
    public KeyCode select;
    public KeyCode back;
    public float yPosition;
    int selected;
    bool isSelecting;
    int currentSelection;
	// Use this for initialization
	void Start () {
        currentSelection = 1;
        isSelecting = true;
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
                selected = currentSelection;
                isSelecting = false;
            }
        }
        else
        {
            if(Input.GetKeyDown(back))
            {
                isSelecting = true;
            }
        }
        if (currentSelection < 1)
            currentSelection = 5;
        else if (currentSelection > 5)
            currentSelection = 1;
        transform.position = new Vector3(-9 + 3*currentSelection, yPosition, 0);
	}
}
