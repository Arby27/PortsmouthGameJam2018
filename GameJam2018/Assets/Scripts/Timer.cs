using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour {

    int countdown = 3;
    int timeRemaining = 60;
    int player1Score;
    int player2Score;
    int player3Score;
    int player4Score;
    int first;
    int second;
    int third;
    int fourth;

    public GameObject[] Players;
    public Camera Player1Cam;

    public Text remainingTime;
    public Text countdownText;
    public Text[] playerScore;
    public GameObject GameOver;
	// Use this for initialization
	void Start () {
        StartCoroutine(TimeRemaining());
        Time.timeScale = 1;
        GameOver.SetActive(false);
        
        
	}
	
	// Update is called once per frame
	void Update () {
        
        remainingTime.text = "Time Remaining: " + timeRemaining;

        if(timeRemaining <= 0)
        {
            Time.timeScale = 0;
        }

        if (Time.timeScale == 0)
        {


            GameOver.SetActive(true);


            if (Input.GetButton("Joy0Circle") || Input.GetButton("Joy1Circle") || Input.GetButton("Joy2Circle") || Input.GetButton("Joy3Circle"))
            {
                Time.timeScale = 1.0f;
                MainMenu.playerCount = 0;
                CreateCollectibles.currentCollectibles = 0;
                SpawnPoweUp.powerUpLimit = 0;
                SceneManager.LoadScene(0);
            }


        }

    }

    IEnumerator TimeRemaining()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            timeRemaining--;
        }
    }
}
