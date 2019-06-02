using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformActivator : MonoBehaviour
{
    public GameObject activateableObject;

    void Awake()
    {
        Debug.Log("Red Activator script is working");
    }

    void OnTriggerStay2D(Collider2D col)
    {
        Debug.Log("Something collided!");
        if (col.gameObject.CompareTag("RedPlayer"))
        {
            Debug.Log("Setting active");
            activateableObject.SetActive(true);
        }

    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("RedPlayer"))
        {
            Debug.Log("Setting inactive");
            activateableObject.SetActive(false);
        }
            
    }
}
