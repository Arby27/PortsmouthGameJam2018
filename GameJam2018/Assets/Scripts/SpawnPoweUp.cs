using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoweUp : MonoBehaviour {

    public GameObject[] powerUps;

    GameObject powerUpinst;
    public static int powerUpLimit = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (powerUpLimit < 5)
        {
            StartCoroutine(randomwSpawnTime());
            powerUpLimit++;
            if (powerUpinst != null)
            {
                powerUpinst.transform.rotation = Random.rotation;
                powerUpinst.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(Random.Range(3f, 10f), 0, Random.Range(3f, 10f)));
            }
        }
        

	}

    IEnumerator randomwSpawnTime()
    {
        float rand = Random.Range(3f, 5f);
        yield return new WaitForSeconds(rand);
        powerUpinst = Instantiate(powerUps[Random.Range(0, powerUps.Length)]);
        

        

    }

}
