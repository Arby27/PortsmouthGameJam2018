using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {


    bool[] joined = new bool[4];
    string[] controllerNames = new string[4];
    public static int playerCount = 0;
    public Image[] joinImage;
    public Image[] joinedImage;
    public Image startGame;
    public static int[] playerID;
   
	// Use this for initialization
	void Start () {
		for(int i =0 ; i<4; i++)
        {
            joined[i] = false;
            if (i< Input.GetJoystickNames().Length)
            {
                controllerNames[i] = Input.GetJoystickNames()[i] + i;
            
                print(controllerNames[i]);
            }
            
        }
	}
	
	// Update is called once per frame
	void Update () {

        if (0 < Input.GetJoystickNames().Length)
        {
            if (Input.GetJoystickNames()[0] + 0 == controllerNames[0])
            {
                ControllerControls(0);
            }
        }

        if (1 < Input.GetJoystickNames().Length)
        {
            if (Input.GetJoystickNames()[1] + 1 == controllerNames[1])
            {
                ControllerControls(1);
            }
        }

        if (2 < Input.GetJoystickNames().Length)
        {
            if (Input.GetJoystickNames()[2] + 2 == controllerNames[2])
            {
                ControllerControls(2);
            }
        }

        if (3 < Input.GetJoystickNames().Length)
        {
            if (Input.GetJoystickNames()[3] + 3 == controllerNames[3])
            {
                ControllerControls(3);
            }
        }

          

        
	}


    void ControllerControls(int i)
    {
        if (joined[i] == false)
        {
            if (Input.GetButtonDown("Joy" + i + "XButt"))
            {
                joined[i] = true;
                playerCount++;
            }
        }

            if (joined[i] == true)
            {
                joinImage[i].gameObject.SetActive(false);
                joinedImage[i].gameObject.SetActive(true);
                

            }

            if (Input.GetButtonDown("Joy" + i + "Circle") && joined[i] == true)
            {
                joinImage[i].gameObject.SetActive(true);
                joinedImage[i].gameObject.SetActive(false);
                playerCount--;
                joined[i] = false;
            }

            if (playerCount >= 2)
            {
                startGame.gameObject.SetActive(true);
            }
            else
            {
                startGame.gameObject.SetActive(false);

            }

            if (startGame.isActiveAndEnabled)
            {
                if (Input.GetButtonDown("Joy" + i + "Start"))
                {
                    SceneManager.LoadScene(1);
                }
            }
        
    }

}
