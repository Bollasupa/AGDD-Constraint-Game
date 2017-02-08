using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairScript : MonoBehaviour {


	private Transform XLine, YLine, Cube;
	private Player player1, player2;
	// Use this for initialization
	void Start () {
		XLine = gameObject.transform.GetChild (0);
		YLine = gameObject.transform.GetChild (1);
		Cube = gameObject.transform.GetChild (2);
		player1 = new Player();
		player2 = new Player();
		player1.SetKeys(KeyCode.A, KeyCode.S, KeyCode.D);
		player2.SetKeys(KeyCode.J, KeyCode.K, KeyCode.L);
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKey (player1.button1)) {
			XLine.position -= new Vector3(0.02f, 0f, 0f);
			Cube.position -= new Vector3(0.02f, 0f, 0f);
		}
		else if (Input.GetKey (player1.button3)) {
			XLine.position += new Vector3(0.02f, 0f, 0f);
			Cube.position += new Vector3(0.02f, 0f, 0f);
		}
		if (Input.GetKey (player2.button3)) {
			YLine.position -= new Vector3(0f, 0f, 0.01f);
			Cube.position -= new Vector3(0f, 0f, 0.01f);
		}
		else if (Input.GetKey (player2.button1)) {
			YLine.position += new Vector3(0f, 0f, 0.01f);
			Cube.position += new Vector3(0f, 0f, 0.01f);
		}
		if (Input.GetKeyDown (KeyCode.Space)) {
			SwapKeys ();
		}
	}

	void SwapKeys(){
		if (player1.button1 == KeyCode.A) {
			player1.SetKeys(KeyCode.J, KeyCode.K, KeyCode.L);
			player2.SetKeys(KeyCode.A, KeyCode.S, KeyCode.D);
		} else {
			player1.SetKeys(KeyCode.A, KeyCode.S, KeyCode.D);
			player2.SetKeys(KeyCode.J, KeyCode.K, KeyCode.L);
		}
	}
}
