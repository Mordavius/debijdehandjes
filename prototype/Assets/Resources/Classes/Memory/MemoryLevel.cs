using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryLevel : MonoBehaviour {

    public bool buttonPressed = false;
    GameObject canvas;

    // Use this for initialization
    void Start () {
        canvas = GameObject.Find("StartCanvas");
    }

    public void SelectYes()
    {
        canvas.SetActive(false);
        buttonPressed = true;
    }

}
