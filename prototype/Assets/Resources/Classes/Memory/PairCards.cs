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

    GameObject cards;
    bool touching = false;

	void Update () {
        int touches = Input.touchCount;
        if (touches == 1 || touches == 2)
        {
            touch = Input.GetTouch(0);
            hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(touch.position), Vector2.zero);

            if (touch.phase == TouchPhase.Began)
            {
                hit.transform.Rotate(new Vector3(0 ,180 ,0));
                touching = true;
            }
            if (touch.phase == TouchPhase.Ended)
            {
                hit.transform.Rotate(new Vector3(0, 180, 0));
                touching = false;
            }
            if (touching && touches == 2)
            {
                touch2 = Input.GetTouch(1);
                hit2 = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(touch2.position), Vector2.zero);
                if (touch2.phase == TouchPhase.Began)
                {
                    hit2.transform.Rotate(new Vector3(0, 180, 0));
                }
                if (touch2.phase == TouchPhase.Ended)
                {
                    hit2.transform.Rotate(new Vector3(0, 180, 0));
                    touching = false;
                }
                if (hit.collider.CompareTag(hit2.collider.tag))
                {
                    Destroy(hit.collider.gameObject);
                    Destroy(hit2.collider.gameObject);
                }
            }
        }
        cards = GameObject.FindWithTag("card");
        if(cards == null)
        {
            scoreScreen.SetActive(true);
        }
    }
}

/*
if (tik[1].ingedrukt){
    draai180graden(); // dun
    tik[2].kanJeIndrukken = true;
    if(tik[1].hit == tik[2].hit){
        blijfOmgedraaid();
        score++;
    }
}
else{
    draaiTerug();
}
*/