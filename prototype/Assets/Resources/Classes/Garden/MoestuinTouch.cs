using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoestuinTouch : MonoBehaviour
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
                        TileBehaviour targetScript = hit.collider.gameObject.GetComponent<TileBehaviour>();
                        if (hit.collider.CompareTag("Tile") && targetScript.state == 0)
                        {
                            hit.transform.SendMessageUpwards("ChangeState", 1);
                        }
                    }
                }
            }
        }
    }
}
