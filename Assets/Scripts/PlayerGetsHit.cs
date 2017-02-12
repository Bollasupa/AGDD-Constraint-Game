using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGetsHit : MonoBehaviour
{

    //private void OnCollisionEnter(Collision collision)
    //{
    //    Debug.Log("craaaaaaaaaaaahshhhhhh boooom");
    //    GameObject.Find("_Manager").GetComponent<ChangeSceneScript>().ChangeSceneTo("EndScene");
    //}

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("craaaaaaaaaaaahshhhhhh boooom");
        GameObject.Find("_Manager").GetComponent<ChangeSceneScript>().ChangeSceneTo("EndScene");
    }
}
