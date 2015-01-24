using UnityEngine;
using System.Collections;

public class CursorScript : MonoBehaviour {
    public KeyCode left;
    public KeyCode right;
    public KeyCode select;
    public KeyCode back;
    int selected;
    int currentSelection;
	// Use this for initialization
	void Start () {
        currentSelection = 1;
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown(left))
        {
            currentSelection -= 1;
        }
        if (Input.GetKeyDown(right))
        {
            currentSelection += 1;
        }
        if (currentSelection < 1)
            currentSelection = 5;
        else if (currentSelection > 5)
            currentSelection = 1;
        transform.position = new Vector3(-9 + 3*currentSelection, 2, 0);
	}
}
