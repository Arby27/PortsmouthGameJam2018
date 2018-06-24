using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCollectibles : MonoBehaviour {

    public GameObject[] collectible;

    public int maxCollectibles;
    public GameObject[] collectibleArray;
    public static int currentCollectibles;
	// Use this for initialization
	void Start () {
        collectibleArray = new GameObject[maxCollectibles];
	}
	
	// Update is called once per frame
    void Update () {
        if (currentCollectibles < maxCollectibles)
        {
            SpawnCollectible();
        }
       
	}

    void SpawnCollectible()
    {
        StartCoroutine(WaitRand());
        
            GameObject collectibleInst = Instantiate(collectible[Random.Range(0,collectible.Length)]);
            collectibleArray[currentCollectibles] = collectibleInst;
            collectibleArray[currentCollectibles].transform.rotation = Random.rotation;
            collectibleArray[currentCollectibles].GetComponent<Rigidbody>().AddRelativeForce(new Vector3(Random.Range(3f, 10f), 0, Random.Range(3f, 10f)));
            currentCollectibles++;  
    }
  

    IEnumerator WaitRand()
    {
        float waitTime = Random.Range(0.1f, 1f);
        yield return new WaitForSeconds(waitTime);
    }
}
