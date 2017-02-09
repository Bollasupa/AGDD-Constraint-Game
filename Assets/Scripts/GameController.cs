using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject playerObject;
    public float moveSpeed = 0.02f;

    private GameObject player1, player2;
    private Player playerScript1, playerScript2;


    // Use this for initialization
    void Start()
    {
        GameObject crosshair = GameObject.FindGameObjectWithTag("Crosshair");

        player1 = Instantiate(playerObject);
        player2 = Instantiate(playerObject);

        playerScript1 = player1.GetComponent<Player>();
        playerScript2 = player2.GetComponent<Player>();

        playerScript1.SetKeys(KeyCode.A, KeyCode.S, KeyCode.D);
        playerScript2.SetKeys(KeyCode.J, KeyCode.K, KeyCode.L);

        playerScript1.crosshair = crosshair;
        playerScript2.crosshair = crosshair;

        playerScript1.axis = Vector3.forward;
        playerScript2.axis = Vector3.right;

    }
}