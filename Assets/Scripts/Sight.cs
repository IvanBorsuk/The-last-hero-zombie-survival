using System;
using System.Collections;
using System.Collections.Generic;
using System.Security;
using UnityEngine;

public class Sight : MonoBehaviour
{
    
    [Header("Sight setting")]
    public float distanse;
    void Start()
    {
       DrawSight();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void DrawSight()
    {
        Mesh mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
       

        Vector3[] vertices = new Vector3[6];
        Vector2[] uv = new Vector2[6];
        int[] triangels = new int[6];
        Vector3 origine = Vector3.zero;

        vertices[0] = -Vector3.zero;
        vertices[1] = new Vector3(distanse,0);
        vertices[2] = new Vector3(0,-distanse);
        vertices[3] = -Vector3.zero;
        vertices[4] = new Vector3(distanse,0);
        vertices[5] = new Vector3(0,-distanse);

        triangels[0] = 0;
        triangels[1] = 1;
        triangels[2] = 2;

        triangels[3] = 0;
        triangels[4] = 1;
        triangels[5] = 2;
       
        

        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangels; 
       // mesh.colors = Color.Lerp(Color.red, Color.green, distanse);
        
    }
}
