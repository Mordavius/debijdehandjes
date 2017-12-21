using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GardenLevel : MonoBehaviour
{
    public bool canRake = false;
    public bool canWater = false;
    GameObject rakeCircle;
    GameObject waterCircle;

    // Update is called once per frame
    void Update()
    {
        int nbTouches = Input.touchCount;
        if (nbTouches > 0)
        {
            for (int i = 0; i < nbTouches; i++)
            {
                Touch touch = Input.GetTouch(i);
                if (touch.phase == TouchPhase.Moved)
                {
                    RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(touch.position), Vector2.zero);
                    if (hit)
                    {
                        Tile targetScript = hit.collider.gameObject.GetComponent<Tile>();
                        if (hit.collider.CompareTag("BlankGround") && targetScript.state == 0)
                        {
                            hit.transform.SendMessageUpwards("ChangeState", 1);
                        }
                    }
                }
            }
        }
        RaycastHit2D hitToggle = Physics2D.Raycast(Input.mousePosition, Vector2.zero);
        if (hitToggle.collider.tag == "toggleRake")
        {
            ToggleRake();
        }
        else if (hitToggle.collider.tag == "toggleWater")
        {
            ToggleWater();
        }
    }

    public bool ToggleRake()
    {
        canRake = !canRake;
        rakeCircle = GameObject.FindGameObjectWithTag("toggleRake");

        if (canRake)
        {
            rakeCircle.GetComponent<SpriteRenderer>().color = Color.gray;
        }
        else
        {
            rakeCircle.GetComponent<SpriteRenderer>().color = Color.white;
        }
        return canRake;
    }

    public bool ToggleWater()
    {
        canWater = !canWater;
        waterCircle = GameObject.FindGameObjectWithTag("toggleWater");

        if (canWater)
        {
            waterCircle.GetComponent<SpriteRenderer>().color = Color.gray;
        }
        else
        {
            waterCircle.GetComponent<SpriteRenderer>().color = Color.white;
        }
        return canWater;
    }
}
