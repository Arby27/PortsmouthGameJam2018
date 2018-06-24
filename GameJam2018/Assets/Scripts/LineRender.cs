using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRender : MonoBehaviour {
    
    public LineRenderer _lineRenderer;

    public float x;
    public float y = 0f;
    public float z;
    public int sections;
    float angle = 10.0f;
    public float radius;
   

    public static LineRender pubLine;

    private void Awake()
    {
        pubLine = this;
         _lineRenderer = GetComponent<LineRenderer>();
        _lineRenderer.material = new Material(Shader.Find("Particles/VertexLit Blended"));
        _lineRenderer.positionCount = sections + 1;
        _lineRenderer.startWidth = 0f;
        _lineRenderer.endWidth = 0f;
        for (int i = 0; i < (sections + 1); i++)
        {
            x = Mathf.Sin(Mathf.Deg2Rad * angle) * radius;
            y = Mathf.Cos(Mathf.Deg2Rad * angle) * radius;

            _lineRenderer.SetPosition(i, new Vector3(x, z, y));
            angle += (360f / sections);
        }

        pubLine = this;
    }

    // Use this for initialization
    void Start () {
       
       

    }
	
	// Update is called once per frame
	void Update () {
        
	}
}
