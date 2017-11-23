using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedTouch : MonoBehaviour {

    public int seedType;

    void OnTriggerStay2D(Collider2D other)
    {
        TileBehaviour targetScript = other.gameObject.GetComponent<TileBehaviour>();
        Debug.Log("collide");
        if (targetScript.state == 1 && Input.GetMouseButtonUp(0))
        {
            other.transform.SendMessageUpwards("ChangeSeed", seedType);
            other.transform.SendMessageUpwards("ChangeState", 2);
            Destroy(this.gameObject);
        }
        if (Input.GetMouseButtonUp(0) && other.gameObject.tag != "RakedGround")
        {
            Destroy(this.gameObject);
        }
    }
}
