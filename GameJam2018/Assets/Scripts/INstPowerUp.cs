using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class INstPowerUp : MonoBehaviour
{
   
    public static int playerNotFrozen = -1;

    GameObject[] Player = new GameObject[4];

    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            Player[i] = GameObject.FindGameObjectWithTag("Player" + i);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Bucket")
        {
            if (col.gameObject.transform.parent.tag == "Player0")
            {
                Debug.Log(col.gameObject.transform.parent.tag.ToString());
                for (int i = 0; i < 4; i++)
                {
                    if (Player[i] != null)
                    {
                        playerNotFrozen = 0;
                        
                        Player[i].GetComponentInChildren<PowerUps>().freeze = true;
                        if (col.gameObject.GetComponent<PowerUps>() != null)
                        {
                            col.gameObject.GetComponent<PowerUps>().freeze = false;
                        }
                        else
                        {
                            Debug.Log("Uhh we dont have a PowerUps component");
                        }
                    }
                }
            }
        }
        //if (col.gameObject.tag == "Bucket")
        //{
        //    if(col.gameObject.transform.parent.tag == "Player0")
        //    {

        //            if (Player[i] != null)
        //            {   

        //                //Player[0].GetComponentInChildren<PowerUps>().freeze = false;
        //                Debug.Log(col.gameObject.transform.parent.name);


        //            }
        //        }
        //    }
        //if (col.gameObject.transform.parent.tag == "Player1")
        //{
        //    for (int i = 0; i < 4; i++)
        //    {
        //        if (Player[i] != null)
        //        {
        //            Player[i].GetComponentInChildren<PowerUps>().freeze = true;
        //            Player[1].GetComponentInChildren<PowerUps>().freeze = false;

        //        }
        //    }
        //}
        //if (col.gameObject.transform.parent.tag == "Player2")
        //{
        //    for (int i = 0; i < 4; i++)
        //    {
        //        if (Player[i] != null)
        //        {
        //            Player[i].GetComponentInChildren<PowerUps>().freeze = true;
        //            Player[2].GetComponentInChildren<PowerUps>().freeze = false;

        //        }
        //    }
        //}
        //if (col.gameObject.transform.parent.tag == "Player3")
        //{
        //    for (int i = 0; i < 4; i++)
        //    {
        //        if (Player[i] != null)
        //        {
        //            Player[i].GetComponentInChildren<PowerUps>().freeze = true;
        //            Player[3].GetComponentInChildren<PowerUps>().freeze = false;

        //        }
        //    }
        //}
    }
}
