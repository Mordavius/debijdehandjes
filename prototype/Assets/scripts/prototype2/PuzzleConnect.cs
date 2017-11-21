using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleConnect : MonoBehaviour {

    public GameObject connectPoint;

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "ContactPoint")
        {
            
            if (this.transform.position == connectPoint.transform.position)
            {
                Destroy(connectPoint);
                Destroy(GetComponent<Drag>());
            }
            this.transform.position = new Vector2(other.transform.position.x, other.transform.position.y);
        }
    }
}
