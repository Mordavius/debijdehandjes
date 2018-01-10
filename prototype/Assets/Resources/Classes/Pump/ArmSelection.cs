using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmSelection : MonoBehaviour {
    public bool left = false;
    public bool right = false;
    GameObject canvas;
    GameObject flip;
    public GameObject text1;
    public GameObject text2;

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
        text1.transform.localScale = new Vector3(-0.3f, 0.3f, 1);
        text2.transform.localScale = new Vector3(-0.3f, 0.3f, 1);
    }
}
