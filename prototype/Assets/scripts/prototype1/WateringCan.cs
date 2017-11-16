using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WateringCan : MonoBehaviour {
    public GameObject sprout;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "WC")
        {
            Instantiate(sprout, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
    }
}
