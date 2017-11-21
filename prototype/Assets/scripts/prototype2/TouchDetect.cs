using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchDetect : MonoBehaviour {
    private bool up;
    private bool down;
    public GameObject bucketpos;
    public GameObject waterSpawn;
    public GameObject waterDrop;
    public GameObject canvas;
    int bucketindex;
    public Sprite[] bucket = new Sprite[4];

    float timer;
    public int waterCount;
	// Use this for initialization
	void Start () {
        up = false;
        down = false;
        timer = 0f;
        bucketindex = 0;
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
		int nbTouches = Input.touchCount;
        if (waterCount == 10)
        {
            canvas.SetActive(true);
        }
        bucketpos.GetComponent<SpriteRenderer>().sprite = bucket[bucketindex];
        bucketpos.transform.localScale = new Vector3(0.1215707f, 0.1215707f, 0.1215707f);
        if (nbTouches > 0)
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
                        waterCount++;
                        up = false;
                        down = false;
                        switch (waterCount)
                        {
                            case 3:
                                bucketindex++;
                                break;
                            case 6:
                                bucketindex++;
                                break;
                            case 9:
                                bucketindex++;
                                break;
                        }
                    }
                 }
            }
        }
	}
}
