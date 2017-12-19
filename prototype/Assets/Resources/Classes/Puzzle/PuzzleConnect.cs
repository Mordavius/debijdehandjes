using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleConnect : MonoBehaviour {

    public GameObject connectPoint;
    public GameObject ReekStalk;

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "ContactPoint")
        {
            if (this.transform.position == connectPoint.transform.position)
            {
                if (this.tag != "ReekStalk")
                {
                    this.transform.parent = ReekStalk.transform;
                }
                Destroy(connectPoint);
                Destroy(GetComponent<Drag>());
            }
            this.transform.position = new Vector2(other.transform.position.x, other.transform.position.y);
        }
        
    }
}
