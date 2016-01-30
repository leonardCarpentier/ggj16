using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Shaft : MonoBehaviour {

	public List<GameObject> attachmentSlots = new List<GameObject>();

	// Use this for initialization
	void Start () {
        for (int i = 0; i < attachmentSlots.Count; i++)
        {
            attachmentSlots[i].SetActive(false);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
