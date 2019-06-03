using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetScript : MonoBehaviour
{
    public float restartWait = 3;
    public bool fadeStarted = false;
    void Update()
    {
        Debug.Log("Waiting for: " + restartWait);//

        if (Input.GetKeyDown("r"))
        {
            if (!fadeStarted)
                restart();
        }
    }

    private void restart()
    {
        fadeStarted = true;
        Messenger.Broadcast(GameEvent.FADE_TO_BLACK);
        StartCoroutine(waitLoad());
    }

    IEnumerator waitLoad()
    {
        Debug.Log("Waiting for: " + restartWait);//
        yield return new WaitForSeconds(restartWait);
        Debug.Log("!!");//
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "BluePlayer" || col.gameObject.tag == "RedPlayer")
        {
            if (!fadeStarted)
                restart();
        }
    }
}
