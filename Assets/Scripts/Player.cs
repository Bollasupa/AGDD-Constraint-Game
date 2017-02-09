using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour{

    public KeyCode buttonLeft, buttonMiddle, buttonRight;
    public GameObject crosshair;
    public Vector3 axis;
    public float moveSpeed = 1;

	public void SetKeys(KeyCode left, KeyCode middle, KeyCode right){
        buttonLeft = left;
        buttonMiddle = middle;
        buttonRight = right;
	}

    public void Update()
    {
        if (Input.GetKey(buttonLeft))
        {
            crosshair.transform.position -= axis * moveSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(buttonMiddle))
        {
            //shoot
        }
        if (Input.GetKey(buttonRight))
        {
            crosshair.transform.position += axis * moveSpeed * Time.deltaTime;
        }
    }


}
