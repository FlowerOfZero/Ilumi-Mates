using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseCamSpeed : MonoBehaviour
{
    public MoveCamera camScript;
    public float newSpeed;

    private bool blueCross = false;
    private bool redCross = false;
    private bool hasActivated = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (blueCross && redCross && !hasActivated)
        {
            // rumble camera?!?, broadcast message?
            hasActivated = true;
            camScript.setSpeed(newSpeed);
        }
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "BluePlayer")
            blueCross = true;
        else if (col.gameObject.tag == "RedPlayer")
            redCross = true;
    }
}
