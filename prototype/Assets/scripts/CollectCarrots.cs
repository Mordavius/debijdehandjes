using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCarrots : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Carrot")
        {
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            rb.gravityScale = 10f;
        }
    }
}
