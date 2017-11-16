using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RakeSpotBuilder : MonoBehaviour {
    public GameObject gezaait;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Rake")
        {
            if (this.enabled)
            {
                Destroy(this.gameObject);
                Instantiate(gezaait, transform.position, transform.rotation);
                this.enabled = false;
            }
        }
    }
}
