using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject playerObject;
    //public float moveSpeed = 0.02f;
    public Text counter;
    public Text Timer;
	public Image reloadBarP1, reloadBarP2;

    public List<GameObject> waves;
    public List<float> waveTimes;

    public GameObject flipper;


    private GameObject crosshair;
    private float CountDownValue;
    private float TimeAtStartScene;
    private float countDown = 4;
    private GameObject player1, player2;
    private Player playerScript1, playerScript2;

    private bool gameActive = false;
    private float CurrentTime;
    private float Minutes { get { return Mathf.Floor(CurrentTime / 60f); } }
    private float Seconds { get { return Mathf.Floor(CurrentTime % 60f); } }

    private void Start()
    {
        crosshair = GameObject.FindGameObjectWithTag("Crosshair"); 
        player1 = Instantiate(playerObject);
        player2 = Instantiate(playerObject);

        player1.tag = "Player1";
        player2.tag = "Player2";

        playerScript1 = player1.GetComponent<Player>();
        playerScript2 = player2.GetComponent<Player>();

        playerScript1.SetKeys(KeyCode.A, KeyCode.S, KeyCode.D);
        playerScript2.SetKeys(KeyCode.J, KeyCode.K, KeyCode.L);
		playerScript1.reloadBar = reloadBarP1;
		playerScript2.reloadBar = reloadBarP2;
        playerScript1.playerSide = true;
        playerScript2.playerSide = false;

        playerScript1.crosshair = crosshair;
        playerScript2.crosshair = crosshair;

        playerScript1.axis = Vector3.forward;
        playerScript2.axis = Vector3.right;

        IEnumerator gameLoop = GameLoop();
        StartCoroutine(gameLoop);

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
        if (CurrentTime < 0.1f && gameActive == true)
        {
            SceneManager.LoadScene("WinScene");
            gameActive = false;
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }

    }

    private IEnumerator GameLoop()
    {
        yield return new WaitForSeconds(3);

        int flipperSeat = 5;

        for(int i = 0; i < flipperSeat; i++)
        {
            Instantiate(waves[i]);
            yield return new WaitForSeconds(waveTimes[i]);
        }


        //dirty hack to save time on the flipper things, 
        //but flipper will only be called once so fuck it
        GameObject theFlipper = Instantiate(flipper);

        float waitingForFlipperTime = 0f;

        while (theFlipper.activeInHierarchy)        {
            waitingForFlipperTime += Time.deltaTime;
            yield return new WaitForSeconds(0.1f);  
            if(waitingForFlipperTime > 5)
            {
                break;
            } 
        }

        Color temp;
        Renderer X = crosshair.transform.GetChild(0).GetComponent<Renderer>();
        Renderer Y = crosshair.transform.GetChild(1).GetComponent<Renderer>();
        temp = X.material.color;
        X.material.color = Y.material.color;
        Y.material.color = temp;



        //Debug.Log(waves.Count);
        for (int i = flipperSeat; i < waves.Count; i++)
        {
            Instantiate(waves[i]);
            yield return new WaitForSeconds(waveTimes[i]);
        }

    }





}