using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuzzleController : MonoBehaviour {

    private GameObject connectCount;
    public GameObject finishScreen;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        connectCount = GameObject.FindGameObjectWithTag("ContactPoint");
        if (connectCount == null)
        {
            finishScreen.SetActive(true);
        }
    }

    public void Buttonclick(int newScene)
    {
        SceneManager.LoadScene(newScene);
    }
}
