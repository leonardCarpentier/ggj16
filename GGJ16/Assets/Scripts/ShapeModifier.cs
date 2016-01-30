using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class ShapeModifier : MonoBehaviour {

    public AnimationCurve shaftCurve;
    public float width = 50f;
    public float heigth = 100f;

    private List<Vector3> initialMesh;

    void Start () {
        initialMesh = new List<Vector3>();

        Mesh mesh = GetComponent<MeshFilter>().mesh;
        
        for(int i = 0; i < mesh.vertices.Length; i++) {
            Vector3 v = mesh.vertices[i];
            initialMesh.Add(new Vector3(v.x, v.y, v.z));
        }

        initialMesh.Sort((v1, v2) => v1.z.CompareTo(v2.z));

        for (int i = 0; i < initialMesh.Count; i++) {
            Debug.Log(initialMesh[i]);
        }
    }
	
	// Update is called once per frame
	void Update () {
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        Vector3[] vertices = initialMesh.ToArray();
        int halfPoints = vertices.Length / 2;
        for (int i = 0; i < vertices.Length; i++) {
            int sideFactor = i <= halfPoints ? 1 : -1; // This factor helps to draw the plant with one single stroke
            float percentOfCompletion = ((float)(i % halfPoints)) / ((float)halfPoints - 1f); // Percentage of completion of a single side

            if (sideFactor > 0) // Right side of the plant
                vertices[i] -= Vector3.forward * width;
            else // Left side of the plant
                vertices[i] += Vector3.forward * width;
        }

        mesh.vertices = vertices;
    }
}
