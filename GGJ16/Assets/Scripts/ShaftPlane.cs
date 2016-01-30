using UnityEngine;
using System.Collections;
public class ShaftPlane : MonoBehaviour {

    public AnimationCurve shaftCurve;
    public float width = 50f;
    public float heigth = 100f;

    // Use this for initialization
    void Start() {
        // Create Vector2 vertices
        Vector2[] vertices2D = new Vector2[] {
            // Right side:
            new Vector2(shaftCurve.Evaluate(0f)*width, 0f),
            new Vector2(shaftCurve.Evaluate(0.5f)*width, heigth / 2f),
            new Vector2(shaftCurve.Evaluate(1f)*width, heigth),
            // Left side:
            new Vector2(-shaftCurve.Evaluate(1f)*width, heigth),
            new Vector2(-shaftCurve.Evaluate(0.5f)*width, heigth / 2f),
            new Vector2(-shaftCurve.Evaluate(0f)*width, 0f),
        };

        for (int i = 0; i < vertices2D.Length; i++) {
            Debug.Log(vertices2D[i]);
        }

        // Use the triangulator to get indices for creating triangles
        Triangulator tr = new Triangulator(vertices2D);
        int[] indices = tr.Triangulate();

        // Create the Vector3 vertices
        Vector3[] vertices = new Vector3[vertices2D.Length];
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
        gameObject.AddComponent(typeof(MeshRenderer));
        MeshFilter filter = gameObject.AddComponent(typeof(MeshFilter)) as MeshFilter;
        filter.mesh = msh;
    }
}
