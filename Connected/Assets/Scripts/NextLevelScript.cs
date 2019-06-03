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
    public float waitTime;
    public bool hasStarted = false;

    void OnTriggerStay2D(Collider2D col)
    {
        bluePlayerInside = redPlayerInside = false;
        if (col.gameObject.CompareTag("BluePlayer"))
        {
            Debug.Log("BluePlayer is at the end");
            bluePlayerInside = true;
        }

        if (col.gameObject.CompareTag("RedPlayer"))
        {
            Debug.Log("RedPlayer is at the end");
            redPlayerInside = true;
        }

        if (redPlayerInside && bluePlayerInside)
        {
            time -= Time.deltaTime;
            if(time <=0 && !hasStarted)
                SceneManager.LoadScene(scene);
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("BluePlayer"))
        {
            Debug.Log("BluePlayer Left the end");
            bluePlayerInside = false;
        }

        if (col.gameObject.CompareTag("RedPlayer"))
        {
            Debug.Log("RedPlayer Left the end");
            redPlayerInside = false;
        }
    }

    IEnumerator waitLoad()
    {
        hasStarted = true;
        // play sound!
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(scene);
    }
}
