using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableOneByOne : MonoBehaviour {

    public float timer;

	void Start () {
        IEnumerator spawn = Spawn();
        StartCoroutine(spawn);
	}
	
	
	IEnumerator Spawn()
    {
        foreach(Transform childTransform in transform)
        {
            childTransform.gameObject.SetActive(true);
            yield return new WaitForSeconds(timer);
        }
    }
}
