using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithPlatform : MonoBehaviour
{
    public List<GameObject> movingChildren;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // When certain things hit this, make them children so they move with this.
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Feet")
        {
            col.gameObject.transform.parent.gameObject.transform.parent = this.transform;
            movingChildren.Add(col.gameObject.transform.parent.gameObject);
        }
        else if (col.gameObject.tag == "Box")
        {
            col.gameObject.transform.parent = this.transform;
            movingChildren.Add(col.gameObject);
        }
    }

    // When they exit, make them no longer children so they no longe move with this.
    public void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Feet")
        {
            col.gameObject.transform.parent.gameObject.transform.parent = null;
            movingChildren.Remove(col.gameObject.transform.parent.gameObject);
        }
        else if (col.gameObject.tag == "Box")
        {
            col.gameObject.transform.parent = this.transform;
            movingChildren.Remove(col.gameObject.transform.parent.gameObject);
        }
    }

    // Removes all children from moving with this.
    // Should be called before the platform is inactived.
    public void unchildAllMovers()
    {
        foreach (GameObject X in movingChildren)
        {
            X.transform.parent = null;
            movingChildren.Remove(X);
        }
    }
}
