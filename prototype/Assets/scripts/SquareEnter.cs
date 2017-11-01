using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareEnter : MonoBehaviour {

	void Start () {
		
	}
	

	void Update () {
		
	}

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Square")
        {
            Destroy(other.gameObject);
        }
    }
}
