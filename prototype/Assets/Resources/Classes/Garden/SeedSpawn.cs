using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedSpawn : MonoBehaviour {

    private GameObject currentObject;
    public GameObject seed;
    public string plantName;

    void OnMouseDown()
    {
        currentObject = Instantiate(seed, Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 2)), new Quaternion(0,0,0,0));
        SeedTouch targetScript = currentObject.GetComponent<SeedTouch>();
        targetScript.plantName = plantName;
    }

    void OnMouseDrag()
    {
        Vector3 cursorScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 2);
        Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorScreenPoint);
        currentObject.transform.position = cursorPosition;
    }
}
