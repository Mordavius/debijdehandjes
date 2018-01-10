using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipCards : MonoBehaviour {
    float speed;
    public bool turnable = false;

    private void Start()
    {
        StartCoroutine(wait());
    }

    void Update () {
        if (this.transform.eulerAngles.y >= 180)
        {
            speed = 0;
            turnable = true;
        }
        this.transform.Rotate(Vector3.up * speed);
    }

    IEnumerator wait()
    {
        yield return new WaitForSecondsRealtime(5);
        speed = 200 * Time.deltaTime;
    }
}
