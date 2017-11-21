using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScenes : MonoBehaviour {

    public void loadMain()
    {
        SceneManager.LoadScene(0);
    }

    public void loadGarden()
    {
        SceneManager.LoadScene(1);
    }

    public void loadPump()
    {
        SceneManager.LoadScene(2);
    }

    public void loadPuzzle()
    {
        SceneManager.LoadScene(3);
    }
}
