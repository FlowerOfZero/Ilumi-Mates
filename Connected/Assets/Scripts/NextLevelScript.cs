using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelScript : MonoBehaviour
{
    public string scene;
    public bool redPlayerInside, bluePlayerInside;
    public NextLevelScript otherScript;
    public float time;
    public bool hasStarted = false;

    void Update()
    {

        if (redPlayerInside && bluePlayerInside)
        {
            time -= Time.deltaTime;
            if (time <= 0)
            {
                // sound
                SceneManager.LoadScene(scene);
            }
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        
        if (col.gameObject.CompareTag("BluePlayer"))
        {
            bluePlayerInside = true;
        }

        if (col.gameObject.CompareTag("RedPlayer"))
        {
            redPlayerInside = true;
        }

    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("BluePlayer"))
        {
            bluePlayerInside = false;
        }

        if (col.gameObject.CompareTag("RedPlayer"))
        {
            redPlayerInside = false;
        }
    }
}
