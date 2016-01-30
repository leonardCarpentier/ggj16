using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShaftPlane : MonoBehaviour {

    public AnimationCurve shaftCurve;
    public const int NUMBER_OF_VERTICES = 600;
    public float width = 50f;
    public float heigth = 100f;

    // Use this for initialization
    void Start() {
        // Create Vector2 vertices

        List<Vector2> vertices2D = new List<Vector2>();
        int halfPoints = NUMBER_OF_VERTICES / 2;
        for (int i = 0; i < NUMBER_OF_VERTICES; i++) {
            int sideFactor = i < halfPoints ? 1 : -1;
            
            float percentOfCompletion = ((float)(i % halfPoints)) / ((float)halfPoints - 1f);
            if(sideFactor > 0)
                vertices2D.Add(new Vector2(shaftCurve.Evaluate(percentOfCompletion) * width * sideFactor, heigth * percentOfCompletion));
            else
                vertices2D.Add(new Vector2(shaftCurve.Evaluate(1 - percentOfCompletion) * width * sideFactor, heigth * (1 - percentOfCompletion)));

            Debug.Log(vertices2D[i]);
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
        msh.RecalculateNormals();
        msh.RecalculateBounds();

        // Set up game object with mesh;
        MeshFilter filter = GetComponent<MeshFilter>();
        filter.mesh = msh;
    }
}
