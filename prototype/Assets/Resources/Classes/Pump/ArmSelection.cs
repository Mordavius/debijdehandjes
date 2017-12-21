using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmSelection : MonoBehaviour {
    public bool left = false;
    public bool right = false;
    GameObject canvas;
    GameObject flip;

    public void Start()
    {
        canvas = GameObject.Find("StartCanvas");
        flip = GameObject.Find("Flip");
    }

    public void SelectLeft()
    {

        canvas.SetActive(false);
        left = true;
    }

    public void SelectRight()
    {
        canvas.SetActive(false);
        right = true;
        flip.transform.localScale = new Vector3(-1, 1, 1);
    }
}
