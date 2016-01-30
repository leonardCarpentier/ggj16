using UnityEngine;
using System.Collections;

public class Plant{

	//private Attachment rootAttachment;


	string binomialGenus;
	string binomialSpecies;

    Attachment root;


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
