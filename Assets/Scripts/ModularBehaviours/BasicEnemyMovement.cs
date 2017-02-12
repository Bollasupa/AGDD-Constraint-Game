using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyMovement : MonoBehaviour {

    public float moveSpeed;


    private float rotateSpeed = 100f;

    private Vector3 angleToCam;
    private Vector3 rotation;

	// Use this for initialization
	void Start () {
        angleToCam = Camera.main.transform.position - transform.position;
        angleToCam.Normalize();
        rotation = Random.insideUnitSphere;
	}
	
	// Update is called once per frame
	//void Update () {
 //       gameObject.transform.position += angleToCam * Time.deltaTime * moveSpeed;
 //       gameObject.transform.Rotate(rotation * rotateSpeed * Time.deltaTime);
	//}

    private void FixedUpdate()
    {
        gameObject.transform.position += angleToCam * Time.deltaTime * moveSpeed;
        gameObject.transform.Rotate(rotation * rotateSpeed * Time.deltaTime);
    }
}
