using UnityEngine;
using System.Collections;

public class FlashScript : MonoBehaviour {
    Color color;
    float alpha;
    float scale;
    float alphaAcc;
    float alphaS;
    float scaleAcc;
    float scaleS;
    float dt;
	// Use this for initialization
	void Start () {
        color = new Color(1, 1, 1,1);
        alpha = 1;
        alphaAcc = 0;
        alphaS = 0.08f;
        scale = 1;
        scaleAcc = 0;
        scaleS = 0.08f;
    }
	
	// Update is called once per frame
	void Update () {
        dt = Time.deltaTime;

        scaleS -= scaleAcc;
        scale += scaleS;
        alphaS -= alphaAcc;
        alpha -= alphaS;

        if(alpha > 0)
        {
            alphaAcc += 0.01f*dt;
        }
        else
        {
            alpha = 0;
            alphaAcc = 0;
            alphaS = 0;
        }
        if(scaleS > 0)
        {
            scaleAcc += 0.01f*dt;
        }
        else
        {
            scaleAcc = 0;
            scaleS = 0;
        }
        color.a = alpha;
        transform.localScale = new Vector3(scale,scale,0);
        GetComponent<SpriteRenderer>().color = color;
	}
    public void Flash()
    {
        color.r = Random.Range(0.3f, 1.0f);
        color.g = Random.Range(0.3f, 1.0f);
        color.b = Random.Range(0.3f, 1.0f);
        alpha = 1;
        alphaS = 1;
        scale = 1;
        scaleS = 1f;
    }
}
