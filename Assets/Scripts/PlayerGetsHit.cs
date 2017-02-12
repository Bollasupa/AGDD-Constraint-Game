using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGetsHit : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameObject.Find("_Manager").GetComponent<ChangeSceneScript>().ChangeSceneTo("EndScene");
    }
}
