using System;
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
                if (touch.phase == TouchPhase.Moved && canRake && GameObject.FindGameObjectWithTag("Seed") == null)
                {
                    RaycastHit2D hitRake = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(touch.position), Vector2.zero);
                    if (hitRake)
                    {
                        Tile targetScript = hitRake.collider.gameObject.GetComponent<Tile>();
                        if (hitRake.collider.CompareTag("BlankGround") && targetScript.state == 0)
                        {
                            hitRake.transform.SendMessageUpwards("ChangeState", 1);
                        }
                    }
                }
                if ((touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Moved) && canWater && GameObject.FindGameObjectWithTag("Seed") == null)
                {
                    RaycastHit2D hitWater = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(touch.position), Vector2.zero);
                    if (hitWater)
                    {
                        Tile targetScript = hitWater.collider.gameObject.GetComponent<Tile>();
                        if (hitWater.collider.CompareTag("SeededGround") && !targetScript.plant.ready)
                        {
                            targetScript.plant.GetWatered();
                            targetScript.GetComponent<SpriteRenderer>().color = Color.gray;
                        }
                    }
                }
            }
        }
        RaycastHit2D hitToggle = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (hitToggle.collider.tag == "toggleRake" && Input.GetMouseButtonDown(0))
        {
            ToggleRake();
            if (canRake && canWater)
            {
                ToggleWater();
            }
        }
        else if (hitToggle.collider.tag == "toggleWater" && Input.GetMouseButtonDown(0))
        {
            ToggleWater();
            if (canRake && canWater)
            {
                ToggleRake();
            }
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
