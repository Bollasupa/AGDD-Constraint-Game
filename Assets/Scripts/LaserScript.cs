using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour {

    public float moveSpeed;
    public Vector3 target { get; set; }

	void Update () {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

        if(Vector3.Distance(target, Camera.main.transform.position) > 200f)
        {
            Destroy(this.gameObject); 
        }
        else if (Vector3.Distance(target, transform.position) < 5f)
        {
            Destroy(this.gameObject);
        }
	}
}
