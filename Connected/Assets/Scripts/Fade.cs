using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour {
    public float rate;
    public bool fadeOut = true;
    SpriteRenderer Rend;
	// Use this for initialization
	void Start () {
        Rend = GetComponent<SpriteRenderer>();

        if (fadeOut)
            Rend.color = new Color(Rend.color.r, Rend.color.g, Rend.color.b, 1);

    }
	
	// Update is called once per frame
	void Update () {
        if (fadeOut)
        {
            if (Rend.color.a > 0f)
                Rend.color = new Color(Rend.color.r, Rend.color.g, Rend.color.b, Rend.color.a - (Time.deltaTime * rate));
            else
                Destroy(this.gameObject);
        }
        else
        {
            if (Rend.color.a < 1)
                Rend.color = new Color(Rend.color.r, Rend.color.g, Rend.color.b, Rend.color.a + (Time.deltaTime * rate));
        }
	}
}
