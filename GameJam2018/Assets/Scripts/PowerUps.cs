using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour {

    public static PowerUps playerPowerUp;
    
    public bool times2 = false;
    public bool rocket = false;
    public bool freeze = false;
  

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

   void OnCollisionEnter(Collision col)
    {
       if(col.gameObject.tag == "times2")
       {
           times2 = true;
           playerPowerUp = this;
           SpawnPoweUp.powerUpLimit--;
           Destroy(col.gameObject);
       }
       if (rocket == false)
       {
           if (col.gameObject.tag == "rocket")
           {
               rocket = true;
               playerPowerUp = this;
               SpawnPoweUp.powerUpLimit--;
               Destroy(col.gameObject);
           }
       }

       if(freeze == false)
       {
           if(col.gameObject.tag == "freeze")
           {
              
               SpawnPoweUp.powerUpLimit--;
               Destroy(col.gameObject);
               
           }
       }
    }

    public enum PowerUpTypes
    {
        doubleScore,
        rocket,
        freeze,
        collider
    }
}
