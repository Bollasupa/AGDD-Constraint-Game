using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject playerObject;
    public float moveSpeed = 0.02f;
    public GameObject basicEnemy;
    public int basicEnemyPoolSize;
    public Text counter;
    public Text Timer;

    private bool gameHasBegun = false;
    private float CountDownValue;
    private float TimeAtStartScene;
    private float timer = 120;
    private float countDown = 4;
    private GameObject player1, player2;
    private Player playerScript1, playerScript2;

    private bool gameActive = false;
    private float CurrentTime;
    private float Minutes { get { return Mathf.Floor(CurrentTime / 60f); } }
    private float Seconds { get { return Mathf.Floor(CurrentTime % 60f); } }

    private void Start()
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
    private void Update()
    {
        if (gameActive == true)
        {
            CurrentTime -= Time.deltaTime;
            if(Seconds < 10)
            {
                Timer.text = "" + Minutes + ":" + "0" + Seconds;
            }
            else
            {
                Timer.text = "" + Minutes + ":" + Seconds;
            }
            if (Seconds <= 30)
            {
                Timer.color = new Color(255, 0, 0);
            }

        }
        if (countDown <= 0.3 && gameActive == false)
        {   
            counter.gameObject.SetActive(false);
            CurrentTime = 120f;
            Time.timeScale = 1;
            gameActive = true;  
        }
        else
        {
            countDown -= Time.deltaTime;
            counter.text = countDown.ToString();
        }
        if (timer <= 0.3 && gameActive == true)
        {
           // End Game 
           //Score?
            gameActive = false;
        }

    }



}