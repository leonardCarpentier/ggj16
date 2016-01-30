using UnityEngine;
using System.Collections;
using UnityEditor;

public class ShaftPlane : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        float width = HandleUtility.GetHandleSize(Vector3.zero) * 0.1f;
        Handles.DrawBezier(transform.position,
                    Vector3.zero,
                    Vector3.up,
                    -Vector3.up,
                    Color.red,
                    null,
                    width);
    }
}
