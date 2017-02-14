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
		if (!SceneManager.GetActiveScene ().name.Equals ("Level01")) {
			if (Input.GetKeyDown (KeyCode.Space)) {
				SceneManager.LoadScene ("Level01");
			}
			if (SceneManager.GetActiveScene ().name.Equals ("EndScene") || SceneManager.GetActiveScene ().name.Equals ("WinScene")) {
				if (Input.GetKeyDown (KeyCode.R)) {
					SceneManager.LoadScene ("Level01");
				}
				if (Input.GetKeyDown (KeyCode.Escape)) {
					Application.Quit ();
				}
			}
		}
	}
}
