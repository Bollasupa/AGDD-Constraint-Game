using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour{

    public KeyCode buttonLeft, buttonMiddle, buttonRight;
    public GameObject crosshair;
    public Vector3 axis;
    public float moveSpeed = 1;

    private IProjectile weapon;

    private void Start()
    {
        weapon = this.gameObject.AddComponent(typeof(BasicLaser)) as IProjectile;
    }

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
        else if (Input.GetKeyDown(buttonMiddle))
        {
            Vector3 eye = Camera.main.transform.position;
            Vector3 direction = crosshair.transform.position - eye;
            Ray ray = new Ray(eye, direction);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit, 200) == true)
            {
                Debug.Log("shooting");
                GameObject target = hit.collider.gameObject;
                IShootable shootable = target.GetComponent(typeof(IShootable)) as IShootable;
                if(shootable != null)
                {
                    shootable.GetShot(weapon);
                }
            }
        }
        if (Input.GetKey(buttonRight))
        {
            crosshair.transform.position += axis * moveSpeed * Time.deltaTime;
        }
    }


}
