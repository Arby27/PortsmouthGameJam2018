using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour {

    int score;
    int multiplyer = 1;
    public Text playerScore;
    public static Text[] savedScore = new Text[4];
    string[] controllerNames = new string[4];



    public GameObject[] Players;


 
    public Text playerScores;
 
    

    void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            if (i < Input.GetJoystickNames().Length)
            {
                controllerNames[i] = Input.GetJoystickNames()[i] + i;
                print(controllerNames[i]);
            }
        }

        if (0 < Input.GetJoystickNames().Length)
        {
            if (Input.GetJoystickNames()[0] + 0 == controllerNames[0])
            {
                savedScore[0] = playerScore;
            }
        }
        if (1 < Input.GetJoystickNames().Length)
        {
            if (Input.GetJoystickNames()[1] + 1 == controllerNames[1])
            {
                savedScore[1] = playerScore;
            }
        }
        if (2 < Input.GetJoystickNames().Length)
        {
            if (Input.GetJoystickNames()[2] + 2 == controllerNames[2])
            {
                savedScore[2] = playerScore;
            }
        }
        if (3 < Input.GetJoystickNames().Length)
        {
            if (Input.GetJoystickNames()[3] + 3 == controllerNames[3])
            {
                savedScore[3] = playerScore;
            }
        }
        


    }

    void Update()
    {
        if (Time.timeScale == 0)
        {
            
           
               
            //playerScores.text = score.ToString();
            

            if (Input.GetButton("Joy0Circle") || Input.GetButton("Joy1Circle") || Input.GetButton("Joy2Circle") || Input.GetButton("Joy3Circle"))
            {
                Time.timeScale = 1.0f;
                MainMenu.playerCount = 0;
                CreateCollectibles.currentCollectibles = 0;
                SpawnPoweUp.powerUpLimit = 0;
                SceneManager.LoadScene(0);
            }

      
        }
        if (PowerUps.playerPowerUp != null)
        {
            if (PowerUps.playerPowerUp.times2 == true)
            {
                multiplyer = 2;
                StartCoroutine(powerUpLength());
            }
        }

        playerScore.text = "Score: " + score.ToString();
        
        
    }


    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Aluminium")
        {
            score = score + 5 * multiplyer;
            CreateCollectibles.currentCollectibles--;
            Destroy(col.gameObject);
        }

        if (col.gameObject.tag == "Copper")
        {
            score = score + 10 * multiplyer;
            CreateCollectibles.currentCollectibles--;
            Destroy(col.gameObject);
        }

        if (col.gameObject.tag == "Iron")
        {
            score = score + 15 * multiplyer;
            CreateCollectibles.currentCollectibles--;
            Destroy(col.gameObject);
        }

        if (col.gameObject.tag == "Gold")
        {
            score = score + 25 * multiplyer;
            CreateCollectibles.currentCollectibles--;
            Destroy(col.gameObject);
        }

        if (col.gameObject.tag == "Purple")
        {
            score = score + 50 * multiplyer;
            CreateCollectibles.currentCollectibles--;
            Destroy(col.gameObject);
        }

        
        //print(this.gameObject.name + " " + score);
    }


    IEnumerator powerUpLength()
    {
        yield return new WaitForSeconds(10);
        PowerUps.playerPowerUp.times2 = false;
    }
}
