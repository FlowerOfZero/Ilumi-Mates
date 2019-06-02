using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPlatform : MonoBehaviour
{
    public Vector3 position1;
    public Vector3 position2;
    public float speed;

    private int state = 0; // 0 = still, 1 = move to pos 1, 2 = move to pos 2;
    private bool xIsGreater;
    private bool yIsGreater;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (state == 1)
        {
            moveTowardPos(position1);
        }
        else if (state == 2)
        {
            moveTowardPos(position2);
        }
    }

    public void PlayOption1()
    {
        state = 1;
        if (position1.x > this.transform.position.x)
            xIsGreater = true;
        else
            xIsGreater = false;
        if (position1.y > this.transform.position.y)
            yIsGreater = true;
        else
            yIsGreater = false;
    }

    public void PlayOption2()
    {
        state = 2;
        if (position2.x > this.transform.position.x)
            xIsGreater = true;
        else
            xIsGreater = false;
        if (position2.y > this.transform.position.y)
            yIsGreater = true;
        else
            yIsGreater = false;
    }

    private void moveTowardPos(Vector3 target)
    {
        this.transform.position = Vector3.MoveTowards(this.transform.position, target, speed * Time.deltaTime);
        if (xIsGreater)
        {
            if (this.transform.position.x >= target.x)
                this.transform.position = new Vector3(target.x, this.transform.position.y, this.transform.position.z);
        }
        else
        {
            if (this.transform.position.x <= target.x)
                this.transform.position = new Vector3(target.x, this.transform.position.y, this.transform.position.z);
        }
        if (yIsGreater)
        {
            if (this.transform.position.y >= target.y)
                this.transform.position = new Vector3(this.transform.position.x, target.y, this.transform.position.z);
        }
        else
        {
            if (this.transform.position.y <= target.y)
                this.transform.position = new Vector3(this.transform.position.x, target.y, this.transform.position.z);
        }
        if (this.transform.position == target)
            state = 0;
    }
}
