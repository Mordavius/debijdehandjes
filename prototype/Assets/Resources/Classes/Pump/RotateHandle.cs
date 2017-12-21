using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateHandle : MonoBehaviour {


    private float sensitivity;
    private Vector3 mouseReference;
    private Vector3 mouseOffset;
    private Vector3 rotation;
    private bool isRotating;
    ArmSelection selectedArm;
    GameObject canvas;

    void Start()
    {
        sensitivity = 0.11f;
        rotation = Vector3.zero;
        canvas = GameObject.Find("StartCanvas");
        selectedArm = (ArmSelection)canvas.GetComponent(typeof(ArmSelection));
 
    }

    void Update()
    {
        if (isRotating)
        {
            // offset
            mouseOffset = (Input.mousePosition - mouseReference);
            // apply rotation
            if (selectedArm.left)
            {
                rotation.z = -(mouseOffset.y) * sensitivity;
            }
            else if (selectedArm.right)
            {
                rotation.z = +(mouseOffset.y) * sensitivity;
            }
            // rotate
            //transform.Rotate(rotation);
            if (selectedArm.left)
            {
                if (gameObject.transform.rotation.eulerAngles.z <= 5)
                {
                    transform.eulerAngles = new Vector3(0, 0, 5.1f);
                    Debug.Log(gameObject.transform.rotation.eulerAngles.z);
                }
                else if (gameObject.transform.rotation.eulerAngles.z >= 81)
                {
                    transform.eulerAngles = new Vector3(0, 0, 80.9f);
                }
            }
            if (selectedArm.right)
            {
                if (gameObject.transform.localRotation.eulerAngles.z <= 4.6f)
                {
                    transform.eulerAngles = new Vector3(0, 0, -4.5f);
                    Debug.Log(gameObject.transform.localRotation.eulerAngles.z);
                    //rotation.z = 5f;
                }
                else if (gameObject.transform.localRotation.eulerAngles.z >= 82)
                {
                    transform.eulerAngles = new Vector3(0, 0, -82.2f);
                    //rotation.z = 81f;
                }

            }
            transform.eulerAngles += rotation;
            // store mouse
            mouseReference = Input.mousePosition;
        }
    }

    void OnMouseDown()
    {
        // rotating flag
        isRotating = true;

        // store mouse
        mouseReference = Input.mousePosition;
    }

    void OnMouseUp()
    {
        // rotating flag
        isRotating = false;
    }

}
