using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformActivator : MonoBehaviour
{
    public GameObject activateableObject;
    public MoveWithPlatform moveWithScript = null;
    public Color inactiveColor;
    public Color activeColor;
    public SpriteRenderer platformSpriteRend;

    void Awake()
    {
        Debug.Log("Red Activator script is working");
    }

    void Update()
    {
        if (moveWithScript != null)
        {
            if (activateableObject.activeSelf)
                moveWithScript.isActive = true;
            else
                moveWithScript.isActive = false;
        }

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Something collided!");
        if (col.gameObject.CompareTag("RedActivator"))
        {
            Debug.Log("Setting active");
            activateableObject.SetActive(true);
            platformSpriteRend.color = activeColor;
        }

    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("RedActivator"))
        {
            Debug.Log("Setting inactive");
            activateableObject.SetActive(false);
            platformSpriteRend.color = inactiveColor;
        }

    }
}
