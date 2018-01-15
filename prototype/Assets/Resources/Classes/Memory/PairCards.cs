using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PairCards : MonoBehaviour {

    RaycastHit2D hit;
    RaycastHit2D hit2;
    Touch touch;
    Touch touch2;
    Vector3 targetAngles;

    public GameObject scoreScreen;

    GameObject[] cards;
    bool touching = false;
    public bool turnable;
    bool turnable2;
    bool paired;
    GameObject[] toPair = new GameObject[2];

    void Update () {
        int touches = Input.touchCount;
        if (touches == 1 || touches == 2)
        {
            touch = Input.GetTouch(0);
            hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(touch.position), Vector2.zero);
            turnable = hit.collider.gameObject.GetComponent<FlipCards>().turnable;
            if (touch.phase == TouchPhase.Began && turnable)
            {
                hit.transform.eulerAngles = new Vector3(0, 0, 0);
                touching = true;
            }
            if (touch.phase == TouchPhase.Ended && turnable)
            {
                hit.transform.eulerAngles = new Vector3(0, 180, 0);
                touching = false;
            }
            if (touching && touches == 2)
            {
                touch2 = Input.GetTouch(1);
                hit2 = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(touch2.position), Vector2.zero);
                turnable2 = hit2.collider.gameObject.GetComponent<FlipCards>().turnable;

                if (touch2.phase == TouchPhase.Began && turnable2)
                {
                    hit2.transform.eulerAngles = new Vector3(0, 0, 0);
                }
                if (touch2.phase == TouchPhase.Ended && turnable2)
                {
                    hit2.transform.eulerAngles = new Vector3(0, 180, 0);
                    touching = false;
                }
                if (hit.collider.CompareTag(hit2.collider.tag) && hit.collider != hit2.collider)
                {
                    paired = true;
                    toPair[0] = hit.collider.gameObject;
                    toPair[1] = hit2.collider.gameObject;
                }
            }
        }
        cards = GameObject.FindGameObjectsWithTag("card");
        
        if (touches == 0)
        {
            foreach (GameObject card in cards)
            {
                if (turnable)
                {
                    card.transform.parent.eulerAngles = new Vector3(0, 180, 0);
                }
            }
        }
        if (cards.Length <= 0 && turnable)
        {
            scoreScreen.SetActive(true);
            GetComponent<AudioSource>().mute = true;
        }
        if (paired)
        {
            toPair[0].transform.localScale -= new Vector3(0.01f, 0.01f, 0.01f);
            toPair[1].transform.localScale -= new Vector3(0.01f, 0.01f, 0.01f);
            if (toPair[0].transform.localScale.x <= 0 && toPair[1].transform.localScale.x <= 0)
            {
                Destroy(toPair[0]);
                Destroy(toPair[1]);
                toPair[0] = null;
                toPair[1] = null;
                paired = false;
            }
        }
    }
}