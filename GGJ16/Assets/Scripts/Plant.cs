using UnityEngine;
using System.Collections;

public class Plant : MonoBehaviour {

	//private Attachment rootAttachment;

	string binomialGenus;
	string binomialSpecies;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public void Grow(){
		//Find an empty attachment slot and grow a new shaft on it
	}

	public void Harvest(){
		//remove a fruit and return a seed
	}

	public string Name{
		get
    {
        return this.binomialGenus+" "+this.binomialSpecies;
    }
    set
    {
        this.binomialSpecies = value;
    }
	}
}
