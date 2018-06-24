using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTransform : MonoBehaviour {

    public GameObject movingObj;
    public float maxScale;
    public float minScale = 0.01f;
    public float angle;
    GameObject[] spectrumArray = new GameObject[AudioData.sampleAmount];



	// Use this for initialization
	void Start () {

        for (int i = 0; i < AudioData.sampleAmount; i++)
        {
            angle = i * 30;
            GameObject movingObjInst = Instantiate(movingObj);
            movingObjInst.transform.position = this.transform.position;
            movingObjInst.transform.parent = this.transform;
            movingObjInst.name = "Spectrum Part :" + i;
            movingObjInst.transform.position = CircleCreate(new Vector3(transform.position.x,transform.position.y + 87f, transform.position.z), 205, angle);
            spectrumArray[i] = movingObjInst;
        }
		
	}
	
	// Update is called once per frame
	void Update () {
        for (int i = 0; i < AudioData.sampleAmount; i++)
        {
            if (spectrumArray != null)
            {
                spectrumArray[i].transform.localScale = new Vector3(1,1, (AudioData.samples[i] * (Random.Range(minScale,maxScale)) + 2));
                spectrumArray[i].GetComponent<BoxCollider>().size = spectrumArray[i].transform.localScale / 2;
            }
        }
	}

    Vector3 CircleCreate(Vector3 Center, int radius, float angle)
    {
        float x = Center.x + radius * Mathf.Sin(Mathf.Rad2Deg * angle);
        float y = Center.y;
        float z = Center.z + radius * Mathf.Cos(Mathf.Rad2Deg * angle);
        Vector3 pos = new Vector3(x, y, z);
        return pos;
    }

}
