using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public KeyCode buttonLeft, buttonMiddle, buttonRight;
    public GameObject crosshair;
    public GameObject laser;
    public Vector3 axis;
    //true = left, false = right
    public bool playerSide;
    public float moveSpeed = 1;
    public float crosshairMaxVertical = 0.58f;
    public float crosshairMaxHorizontal = 0.7f;

    private IProjectile weapon;
    private Vector3 crosshairPosDelta = Vector3.zero;


    private void Start()
    {
        weapon = this.gameObject.AddComponent<BasicLaser>() as IProjectile;
    }

    public void SetKeys(KeyCode left, KeyCode middle, KeyCode right) {
        buttonLeft = left;
        buttonMiddle = middle;
        buttonRight = right;
    }

    public void Update()
    {
        if (Input.GetKey(buttonLeft))
        {
            crosshairPosDelta = -1 * axis * moveSpeed * Time.deltaTime;
        }
        else if (Input.GetKeyDown(buttonMiddle))
        {
            Vector3 eye = Camera.main.transform.position;
            Vector3 direction = crosshair.transform.position - eye;
            Ray ray = new Ray(eye, direction);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 200) == true)
            {
                GameObject target = hit.collider.gameObject;
                IShootable shootable = target.GetComponent(typeof(IShootable)) as IShootable;
                if (shootable != null)
                {
                    shootable.GetShot(weapon);
                }

                
                ShootLaser(hit.point);
            }
        }

        if (Input.GetKey(buttonRight))
        {
            crosshairPosDelta = axis * moveSpeed * Time.deltaTime;
        }
    }

    public void LateUpdate()
    {
        float deltaX = crosshairPosDelta.x;
        float deltaXTotal = crosshair.transform.position.x + deltaX;
        if ((deltaXTotal < -crosshairMaxHorizontal) || (deltaXTotal > crosshairMaxHorizontal))
        {
            crosshairPosDelta.x = 0;
        }

        float deltaZ = crosshairPosDelta.z;
        float deltaZTotal = crosshair.transform.position.z + deltaZ;
        if ((deltaZTotal < -crosshairMaxVertical) || (deltaZTotal > crosshairMaxVertical))
        {
            crosshairPosDelta.z = 0;
        }

        crosshair.transform.position += crosshairPosDelta;

        crosshairPosDelta = Vector3.zero;
    }

    public void ShootLaser(Vector3 target)
    {
        Debug.Log("Shooting laser");

        Vector3 from = Camera.main.transform.position;

        if(playerSide == true)
        {
            from.x -= 5;
        }else
        {
            from.x += 5;
        }

        Vector3 direction = target - from;
        direction.Normalize();
        Quaternion rotation = Quaternion.LookRotation(direction);

        GameObject shot = Instantiate(laser, from, rotation);
        shot.GetComponent<LaserScript>().target = target;
    }
}