using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class Level : MonoBehaviour {
    /*GameObject bg;
    AudioSource GMAudio;
    AudioSource audioHandler;
    AudioClip bgm;
    AudioClip audioFeedback;
    */
    public int score;


    /*public bool IsFirstTimePlayed()
    {

    }*/

    /*private int GetSavedScore()
    {

    }*/

    /*public void StartTimer()
    {

    }*/

   /* public float TimeDuration()
    {

    }
    */
   
    //use when neeeded
     public virtual void Start()
    {
        /*audioFeedback = Resources.Load<AudioClip>("Audio/prototype3/" + SceneManager.GetActiveScene().name + "Feedback");
        bgm = Resources.Load<AudioClip>("Audio/prototype3/" + SceneManager.GetActiveScene().name + "BGM");

        bg = GameObject.Find("Background");

        audioHandler = GameObject.Find("Main Camera").GetComponent<AudioSource>();
        GMAudio = GameObject.Find("GM").GetComponent<AudioSource>();
        Instantiate(Resources.Load("Sprites/prototype3/" + SceneManager.GetActiveScene().name + "Background"),bg.transform.position, bg.transform.rotation);
        audioHandler.clip = bgm;
        GMAudio.clip = audioFeedback;*/
        
    }
    /*
    public virtual void PlayFeedback()
    {
        GMAudio.Play();
    }
    public virtual void PlayBackground(bool looping)
    {
        audioHandler.Play();
        audioHandler.loop = looping;
    }
    */
}
