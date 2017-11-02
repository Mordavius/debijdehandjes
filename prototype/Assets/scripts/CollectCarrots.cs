using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectCarrots : MonoBehaviour {
    float startX;
    float startY;
    float startZ;
    private Vector3 screenPoint;
    private Vector3 offset;
    private Text carrotText;
    private GameObject carrot;
    public GameObject DT;
    public GameObject DB;
    public GameObject CT;
    int carrotCount = 0;
	// Use this for initialization
	void Start () {
        carrotText = CT.GetComponent<Text>();
        startX = transform.position.x;
        startY = transform.position.y;
        startZ = transform.position.z;
        
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    void OnMouseDown()
    {

        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    void OnMouseDrag()
    {
        carrot = GameObject.FindGameObjectWithTag("Carrot"); ;
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        transform.position = curPosition;
        if (carrot == null)
        {
            DB.SetActive(true);
            DT.SetActive(true);
        }
    }

    void OnMouseUp()
    {
        transform.position = new Vector3(startX, startY, startZ);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Carrot")
        {
            carrotCount++;
            carrotText.text = "Score " + carrotCount.ToString();
            Destroy(other.gameObject);
        }
    }
}
