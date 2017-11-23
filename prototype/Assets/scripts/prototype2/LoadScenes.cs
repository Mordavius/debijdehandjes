using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScenes : MonoBehaviour {

    public void loadMain()
    {
        SceneManager.LoadScene("mainmenu");
    }

    public void loadGarden()
    {
        SceneManager.LoadScene("moestuin");
    }

    public void loadPump()
    {
        SceneManager.LoadScene("pompen");
    }

    public void loadPuzzle()
    {
        SceneManager.LoadScene("puzzel");
    }
}
