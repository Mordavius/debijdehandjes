using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GardenLevel : MonoBehaviour
{

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
    }
}
