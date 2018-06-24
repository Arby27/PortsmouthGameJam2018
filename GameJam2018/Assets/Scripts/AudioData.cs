using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioData : MonoBehaviour {

    public static int sampleAmount = 512;
    public AudioSource song;
    public static float[] samples = new float[sampleAmount];

	// Use this for initialization
	void Start () {
        song.gameObject.GetComponent<AudioSource>();
        if (song == null)
        {
            song.gameObject.AddComponent<AudioSource>();
        }
	}
	
	// Update is called once per frame
	void Update () {
        SpectrumData();
	}

    void SpectrumData()
    {
        song.GetOutputData(samples, 0);
    }
}
