using UnityEngine;
using System.Collections;

public class LeonardDebugCtrl : MonoBehaviour {

    public Plant yoloPlante;

	// Use this for initialization
	void Start () {
        yoloPlante.Grow();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.F))
        {
            //Here
        }
	}
}
