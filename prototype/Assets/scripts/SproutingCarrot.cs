using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SproutingCarrot : MonoBehaviour {
    public GameObject carrot;
    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    void OnMouseDown() {
        Instantiate(carrot, transform.position, transform.rotation);
        Destroy(this.gameObject);
    }

    void OnMouseUp()
    {
        Destroy(this.gameObject);
    }
}
