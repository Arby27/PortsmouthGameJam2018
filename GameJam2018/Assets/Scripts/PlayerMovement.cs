using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

  
   


    public GameObject[] bucket;
    public static  string[] controllerNames = new string[4];
    public GameObject[] rocketFire;
    GameObject RocketFireinst;

    

	// Use this for initialization
	void Start () {
      
       //transform.parent = drill.transform;

       for (int i = 0; i < 4; i++)
       {
           if (i < Input.GetJoystickNames().Length)
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
                Extend(0);
                if (PowerUps.playerPowerUp != null)
                {
                    if (PowerUps.playerPowerUp.rocket == true)
                    {
                        Fire(0);
                    }
                }
            }
        }
        if (1 < Input.GetJoystickNames().Length)
        {
            if (Input.GetJoystickNames()[1] + 1 == controllerNames[1])
            {
               
                Extend(1);
                if (PowerUps.playerPowerUp != null)
                {
                    if (PowerUps.playerPowerUp.rocket == true)
                    {
                        Fire(1);
                    }
                }
            }
        }
        if (2 < Input.GetJoystickNames().Length)
        {
            if (Input.GetJoystickNames()[2] + 2 == controllerNames[2])
            {
               
                Extend(2);
                if (PowerUps.playerPowerUp != null)
                {
                    if (PowerUps.playerPowerUp.rocket == true)
                    {
                        Fire(2);
                    }
                }
            }
        }
        if (3 < Input.GetJoystickNames().Length)
        {
            if (Input.GetJoystickNames()[3] + 3 == controllerNames[3])
            {
               
                Extend(3);
                if (PowerUps.playerPowerUp != null)
                {
                    if (PowerUps.playerPowerUp.rocket == true)
                    {
                        Fire(3);
                    }
                }
            }
        }
    }


    void Extend(int i)
    {
            if (Input.GetButtonDown("Joy" + i + "XButt"))
            {
               
                bucket[i].transform.localScale = new Vector3(bucket[i].transform.localScale.x, bucket[i].transform.localScale.y, (bucket[i].transform.localScale.z * 2));
                bucket[i].transform.position = bucket[i].transform.position + bucket[i].transform.forward;

            }
        
        
            if (Input.GetButtonUp("Joy" + i + "XButt"))
            {
               
                bucket[i].transform.localScale = new Vector3(bucket[i].transform.localScale.x, bucket[i].transform.localScale.y, (bucket[i].transform.localScale.z / 2));
                bucket[i].transform.position = bucket[i].transform.position - bucket[i].transform.forward;
            }    
    }

    void Fire(int i)
    {
        if(Input.GetButtonDown("Joy" + i + "Circle"))
        {
            RocketFireinst = Instantiate(rocketFire[i],this.gameObject.transform);
            RocketFireinst.transform.localScale = new Vector3(0.254f, 0.254f, 0.254f);
            RocketFireinst.transform.parent = null;
            RocketFireinst.transform.Rotate(new Vector3(0, 90, 0));
            RocketFireinst.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward *2 * Time.deltaTime);
            PowerUps.playerPowerUp.rocket = false;
        }
    }
     

   

}
