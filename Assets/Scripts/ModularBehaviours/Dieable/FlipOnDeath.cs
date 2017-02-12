using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipOnDeath : MonoBehaviour, IDieable {
    public void Die()
    {
        Player player1 = GameObject.FindGameObjectWithTag("Player1").GetComponent<Player>();
        Player player2 = GameObject.FindGameObjectWithTag("Player2").GetComponent<Player>();

        Vector3 temp;
        temp = player1.axis;
        player1.axis = player2.axis;
        player2.axis = temp;

        this.gameObject.SetActive(false);
    }
}
