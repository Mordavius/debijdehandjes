using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchDrag : MonoBehaviour {

    Vector2 offset;
    float startX;
    float startY;

    void Update () {
        int touches = Input.touchCount;
        for (int i = 0; i < touches; i++)
        {
            Touch touch = Input.GetTouch(i);
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(touch.position), Vector2.zero);
            if (touch.phase == TouchPhase.Began && !hit.collider.CompareTag("carrot"))
            {
                offset = hit.transform.position - Camera.main.ScreenToWorldPoint(touch.position);
            }
            if (touch.phase == TouchPhase.Moved && !hit.collider.CompareTag("carrot"))
            {
                Vector2 curScreenPoint = Camera.main.ScreenToWorldPoint(touch.position);
                Vector2 curPosition = curScreenPoint + offset;
                hit.transform.position = curPosition;
            }
        }
    }
}
