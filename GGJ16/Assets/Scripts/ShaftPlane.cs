using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShaftPlane : MonoBehaviour {

    public AnimationCurve shaftCurve;
    public const int NUMBER_OF_VERTICES = 50;
    public float width = 50f;
    public float heigth = 100f;

    // Use this for initialization
    void Start() {

        // Create the vertices of the plant
        List<Vector2> vertices2D = new List<Vector2>();
        int halfPoints = NUMBER_OF_VERTICES / 2; // Number of points for one side of the plant
        for (int i = 0; i < NUMBER_OF_VERTICES; i++) {
            int sideFactor = i < halfPoints ? 1 : -1; // This factor helps to draw the plant with one single stroke
            float percentOfCompletion = ((float)(i % halfPoints)) / ((float)halfPoints - 1f); // Percentage of completion of a single side

            if(sideFactor > 0) // Right side of the plant
                vertices2D.Add(new Vector2(shaftCurve.Evaluate(percentOfCompletion) * width * sideFactor, heigth * percentOfCompletion));
            else // Left side of the plant
                vertices2D.Add(new Vector2(shaftCurve.Evaluate(1 - percentOfCompletion) * width * sideFactor, heigth * (1 - percentOfCompletion)));
        }

        // Use the triangulator to get indices for creating triangles
        Triangulator tr = new Triangulator(vertices2D.ToArray());
        int[] indices = tr.Triangulate();

        // Create the Vector3 vertices
        Vector3[] vertices = new Vector3[vertices2D.Count];
        for (int i = 0; i < vertices.Length; i++) {
            vertices[i] = new Vector3(vertices2D[i].x, vertices2D[i].y, 0);
        }

        // Create the mesh
        Mesh msh = new Mesh();
        msh.vertices = vertices;
        msh.triangles = indices;

        Vector2[] uvs = new Vector2[vertices.Length];

        for (int i = 0; i < uvs.Length; i++)
        {
            uvs[i] = new Vector2(vertices[i].x, vertices[i].z);
        }
        msh.uv = uvs;

        msh.RecalculateNormals();
        msh.RecalculateBounds();
        msh.Optimize();

        // Set up game object with mesh;
        MeshFilter filter = GetComponent<MeshFilter>();
        filter.mesh = msh;


    }
}
