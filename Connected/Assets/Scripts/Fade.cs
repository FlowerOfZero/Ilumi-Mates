using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour {
    public float rate;
    public bool isFadeOut = true;
    SpriteRenderer Rend;

    void Awake()
    {
        Messenger.AddListener(GameEvent.FADE_TO_BLACK, fadeIn);
        Messenger.AddListener(GameEvent.FADE_FROM_BLACK, fadeOut);
    }

    void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.FADE_TO_BLACK, fadeIn);
        Messenger.RemoveListener(GameEvent.FADE_FROM_BLACK, fadeOut);
    }

	// Use this for initialization
	void Start () {
        Rend = GetComponent<SpriteRenderer>();

        if (isFadeOut)
            fadeOut();
        else
            fadeIn();
    }
	
	// Update is called once per frame
	void Update () {
        if (isFadeOut)
        {
            if (Rend.color.a > 0f)
                Rend.color = new Color(Rend.color.r, Rend.color.g, Rend.color.b, Rend.color.a - (Time.deltaTime * rate));
        }
        else
        {
            if (Rend.color.a < 1)
                Rend.color = new Color(Rend.color.r, Rend.color.g, Rend.color.b, Rend.color.a + (Time.deltaTime * rate));
        }
	}

    void fadeIn()
    {
        Rend.color = new Color(Rend.color.r, Rend.color.g, Rend.color.b, 0);
        isFadeOut = false;
    }

    void fadeOut()
    {
        Rend.color = new Color(Rend.color.r, Rend.color.g, Rend.color.b, 1);
        isFadeOut = true;
    }
}
