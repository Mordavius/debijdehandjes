using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedPlacement : MonoBehaviour {
    public GameObject gevuld;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Seed")
        {
            Instantiate(gevuld, transform.position, transform.rotation);
            Destroy(other.gameObject);
        }
    }
}
