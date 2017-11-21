using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScenes : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public static void loadMain()
    {
        SceneManager.LoadScene(0);
    }

    public static void loadGarden()
    {
        SceneManager.LoadScene(1);
    }

    public static void loadPump()
    {
        SceneManager.LoadScene(2);
    }

    public static void loadPuzzle()
    {
        SceneManager.LoadScene(3);
    }
}
