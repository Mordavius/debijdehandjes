using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrotSeedSpawn : MonoBehaviour {

    private GameObject currentObject;
    public GameObject seed;

    void OnMouseDown()
    {
        currentObject = Instantiate(seed, Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 2)), new Quaternion(0,0,0,0));
        SeedTouch targetScript = currentObject.GetComponent<SeedTouch>();
        targetScript.seedType = 1;
    }

    void OnMouseDrag()
    {
        Vector3 cursorScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 2);
        Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorScreenPoint);
        currentObject.transform.position = cursorPosition;
    }
}
