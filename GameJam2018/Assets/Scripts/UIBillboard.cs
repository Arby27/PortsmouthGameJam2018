using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBillboard : MonoBehaviour {

    public GameObject timer;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timer.transform.LookAt(this.gameObject.transform);
	}
}
