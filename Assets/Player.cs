using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player {

	public KeyCode button1, button2, button3;

	public Player(){}

	public void SetKeys(KeyCode but1, KeyCode but2, KeyCode but3){
		button1 = but1;
		button2 = but2;
		button3 = but3;
	}


}
