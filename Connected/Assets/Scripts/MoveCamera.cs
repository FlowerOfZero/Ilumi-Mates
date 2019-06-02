using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public float startSpeed;
    public float stopXPos;
    public float currentSpeed;
    // Start is called before the first frame update
    void Start()
    {
        currentSpeed = startSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.x < stopXPos)
            moveRight();
    }

    public void setSpeed(float f)
    {
        currentSpeed = f;
    }

    private void moveRight()
    {
        this.transform.position += new Vector3(currentSpeed * Time.deltaTime, 0, 0);
    }
}
