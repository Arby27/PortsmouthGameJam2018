using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitScreen : MonoBehaviour {


    public GameObject[] PlayerObj;
    public GameObject[] PlayerObjInst;

    public GameObject[] PlayerInst = new GameObject[4];
   

  

    public float[] angle = new float[4];
    
    public float radius;

    float xPos;
    float zPos;
    string[] controllerNames = new string[4];

	// Use this for initialization
	void Start () {
        print(MainMenu.playerCount);
        if (MainMenu.playerCount == 2)
        {
            for (int i = 0; i < 2; i++)
            {
                PlayerObjInst[i] = Instantiate(PlayerObj[i]);
                PlayerInst[i] = GameObject.FindGameObjectWithTag("Player" + i);
                print(PlayerInst[i].name);
           
          
                //StartCoroutine(SetSpawn(PlayerObjInst[i],i));
            }

            PlayerObjInst[0].GetComponentInChildren<Camera>().rect = new Rect(0.0f,0.5f,1.0f,0.5f);
            PlayerObjInst[1].GetComponentInChildren<Camera>().rect = new Rect(new Vector2(0, 0.0f), new Vector2(1.0f, 0.5f));

        }

        if (MainMenu.playerCount == 3)
        {
            for (int i = 0; i < 3; i++)
            {
                PlayerObjInst[i] = Instantiate(PlayerObj[i]);
                PlayerInst[i] = GameObject.FindGameObjectWithTag("Player" + i);
                print(PlayerInst[i].name);
             
            }

            PlayerObjInst[0].GetComponentInChildren<Camera>().rect = new Rect(new Vector2(0.0f, 0.5f), new Vector2(1.0f, 0.5f));
            PlayerObjInst[1].GetComponentInChildren<Camera>().rect = new Rect(new Vector2(0.0f, 0.0f), new Vector2(0.5f, 0.5f));
            PlayerObjInst[2].GetComponentInChildren<Camera>().rect = new Rect(new Vector2(0.5f, 0.0f), new Vector2(0.5f, 0.5f));

        }

        if (MainMenu.playerCount == 4)
        {
            for (int i = 0; i < 4; i++)
            {
                PlayerObjInst[i] = Instantiate(PlayerObj[i]);
                PlayerInst[i] = GameObject.FindGameObjectWithTag("Player" + i);
                print(PlayerInst[i].name);
             
            }

            PlayerObjInst[0].GetComponentInChildren<Camera>().rect = new Rect(new Vector2(0.0f, 0.5f), new Vector2(0.5f, 0.5f));
            PlayerObjInst[1].GetComponentInChildren<Camera>().rect = new Rect(new Vector2(0.5f, 0.5f), new Vector2(0.5f, 0.5f));
            PlayerObjInst[2].GetComponentInChildren<Camera>().rect = new Rect(new Vector2(0.0f, 0.0f), new Vector2(0.5f, 0.5f));
            PlayerObjInst[3].GetComponentInChildren<Camera>().rect = new Rect(new Vector2(0.5f, 0.0f), new Vector2(0.5f, 0.5f));

        }

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
                Movement(0);
                //Extend(0);
            }
        }
        if (1 < Input.GetJoystickNames().Length)
        {
            if (Input.GetJoystickNames()[1] + 1 == controllerNames[1])
            {
                Movement(1);
               // Extend(1);
            }
        }
        if (2 < Input.GetJoystickNames().Length)
        {
            if (Input.GetJoystickNames()[2] + 2 == controllerNames[2])
            {
                Movement(2);
               // Extend(2);
            }
        }
        if (3 < Input.GetJoystickNames().Length)
        {
            if (Input.GetJoystickNames()[3] + 3 == controllerNames[3])
            {
                Movement(3);
               // Extend(3);
            }
        }
      
	}



    void Movement(int i)
    {
        float translation = Input.GetAxis("Joy" + i + "X") * Time.deltaTime;

       for(int j= 0; j <4; j++)
       {
           if (PlayerInst[j] != null)
           {
               if (PlayerInst[j].GetComponentInChildren<PowerUps>().freeze == true)
               {
                   if(j == INstPowerUp.playerNotFrozen)
                   {
                       PlayerInst[j].GetComponentInChildren < PowerUps>().freeze = false;
                   }
                   else
                   {
                       StartCoroutine(FreezeWait(j));
                       //translation = 0;
                       if (PlayerObjInst[j] != null)
                       {
                           PlayerObjInst[j].transform.position = PlayerObjInst[j].transform.position;
                       }
                   }
               }
           }
       }
        if (PlayerObjInst[i] != null)
        {

            xPos = (radius * Mathf.Sin(Mathf.Rad2Deg * angle[i]));
            zPos = (radius * Mathf.Cos(Mathf.Rad2Deg * angle[i]));

            PlayerObjInst[i].transform.position = Vector3.zero + new Vector3(xPos, 0, zPos);
            PlayerObjInst[i].transform.LookAt(this.transform);

            angle[i] += translation * 0.03f;
        }
        
    }

   

    Vector3 DistToPoint(Transform Origin, Vector3 pos)
    {
        Vector3 relativePos = Vector3.zero;
        Vector3 dist = pos - Origin.position;

        relativePos.x = Vector3.Dot(dist, Origin.right.normalized);
        relativePos.y = Vector3.Dot(dist, Origin.up.normalized);
        relativePos.z = Vector3.Dot(dist, Origin.forward.normalized);

        return relativePos;
    }




    IEnumerator SetSpawn(GameObject player,int i)
    {
       
        yield return new WaitForSeconds(1);
        player.transform.position = LineRender.pubLine._lineRenderer.GetPosition(i *3);
        
    }

    IEnumerator FreezeWait(int i)
    {
        yield return new WaitForSeconds(1.5f);
        PlayerInst[i].GetComponentInChildren<PowerUps>().freeze = false;
    }
}
