using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBehaviour : MonoBehaviour {

    public int state;
    public int seedType;
    public Sprite[] sprite;

    /* state
     * 0 = lege tile
     * 1 = geharkt
     * 2 = seeded
     * 
     * seedType
     * 0 = niks
     * 1 = wortel
     * etc.
     */

	// Use this for initialization
	void Start () {
        state = 0;
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<SpriteRenderer>().sprite = sprite[state];
        if (state != 0)
        {
            transform.localScale = new Vector3(0.72f, 0.48f, 0);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 0);
        }
    }

    void ChangeState(int newState)
    {
        state = newState;
    }

    void ChangeSeed(int newSeed)
    {
        seedType = newSeed;
    }
}
