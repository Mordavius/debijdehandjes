using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonClick : MonoBehaviour {

    public void Buttonclick (int newScene)
    {
        SceneManager.LoadScene(newScene);
    }

}
