using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleDespawn : MonoBehaviour {


    void Update()
    {
        ForceAdd();
    }

    void ForceAdd()
    {
        if(this.gameObject.GetComponent<Rigidbody>().velocity.x < 2.0f || this.gameObject.GetComponent<Rigidbody>().velocity.z < 2.0f)
        {
            this.gameObject.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(Random.Range(3f, 10f), 0f, Random.Range(3f, 10f)));
        }
    }

/*void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Bucket" )
        { 
            CreateCollectibles.currentCollectibles--;
            Destroy(this.gameObject);
            
        }
    }*/
}
