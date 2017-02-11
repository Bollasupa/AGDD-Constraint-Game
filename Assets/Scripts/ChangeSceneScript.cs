using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneScript : MonoBehaviour {
	
	public void ChangeSceneTo (string scene) {
		//if (Input.GetKeyDown (KeyCode.Space)) {
			//Scene level01 = SceneManager.GetSceneByName (scene);
		SceneManager.LoadScene(scene);
		//}
	}

	void Update(){
		if (Input.GetKeyDown (KeyCode.Space)) {
			SceneManager.LoadScene("Level01");
		}
	}
}
