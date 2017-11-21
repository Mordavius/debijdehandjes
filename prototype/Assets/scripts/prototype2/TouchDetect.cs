using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchDetect : MonoBehaviour {
    private bool up;
    private bool down;
    public GameObject waterSpawn;
    public GameObject waterDrop;
    float timer
	// Use this for initialization
	void Start () {
        up = false;
        down = false;	
	}
	
	// Update is called once per frame
	void Update () {
		int nbTouches = Input.touchCount;

        if(nbTouches > 0)
        {

            for (int i = 0; i < nbTouches; i++)
            {
                Touch touch = Input.GetTouch(i);

                if (touch.phase == TouchPhase.Moved)
                {
                     RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(touch.position), Vector2.zero);
                   
                      if (hit.collider.CompareTag("Up"))
                      {
                         up = true;
                      }
                      if (hit.collider.CompareTag("Down"))
                      {
                         down = true;
                      }
                    if (up && down)
                    {
                        Instantiate(waterDrop, waterSpawn.transform.position, waterSpawn.transform.rotation);
                        up = false;
                        down = false;
                    }
                 }
            }
        }
	}
}
